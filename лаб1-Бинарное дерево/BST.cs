using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Лаб_9___Списки;

namespace дерево
{
    /// <summary>
    /// дунамически-реализовано бинарное дерево поиска
    /// </summary>
    /// <typeparam name="T">тип данных которые храняются в дереве</typeparam>
    public class DynamicBST<T>:BinTree<T> where T:IComparable<T>
    {

       // public DynamicBST(T data):base(){ }
        public T data;
        public int count = 0;
        public DynamicBST<T> parent;
        public DynamicBST<T> left;
        public DynamicBST<T> right;
        public DynamicBST()
        {
        }
        public DynamicBST(T data) 
        {
            this.data = data;
        }
        /// <summary>
        /// добавление новой вершины в дереве
        /// </summary>
        /// <param name="data">данные для хранения</param>
        /// <returns>-1 если левая, 1 если правая и 0 если добавлена</returns>
        public int AddNode(T data)
        {
            int direction = 0;
            DynamicBST<T> temp = new DynamicBST<T>();
            BinTreeNodes<T> newnode = new BinTreeNodes<T>(data);
            if (!NodeExists(ref temp,data))
            {
                if (count == 0)//создание корень дерева
                {
                    newnode.left = null;
                    newnode.right = null;
                    newnode.parent = null;
                    root = newnode;
                    count++;
                }
                else //поиск место для добавления
                {
                    BinTreeNodes<T> current = root;
                    while ((data.CompareTo(current.data) > 0 && current.right != null)
                        || (data.CompareTo(current.data) < 0 && current.left != null))
                    {
                        if (data.CompareTo(current.data) > 0)
                            current = current.right;
                        else current = current.left;

                    }
                    //создание новой вершины
                    newnode.left = null;
                    newnode.right = null;
                    newnode.parent = current;
                    // добавление на правое поддереве
                    if (data.CompareTo(current.data) > 0)
                    {
                        current.right = newnode;
                        direction = 1;
                    }
                    //добавление на левое поддереве
                    else
                    {
                        current.left = newnode;
                        direction = -1;
                    }
                    count++;
                }
            }
            return direction;
        }
        /// <summary>
        /// удаление вершины дерева
        /// </summary>
        /// <param name="data">данные на вершине</param>
        public int DeleteNode(T data)
        {
            int deletion_state = 0;
            BinTreeNodes<T> node = new BinTreeNodes<T>();
            if (NodeExists(ref node, data))//проверка на существование вершины
            {
                if (node.right == null)
                {
                    if (node.left != null)// случай когда есть только левой патомок
                    {
                        node.parent.left = node.left;
                        node.left.parent = node.parent;
                        node = null;
                        deletion_state = 1;
                    }
                    else
                    {
                        node = null;// случай когда нет потомков
                        deletion_state = 0;
                    }
                    count--;
                } 
                else if (node.left == null)// случай когда есть только правой патомок
                {
                    node.parent.right = node.right;
                    node.right.parent = node.parent;
                    node = null;
                    deletion_state = 2;
                    count--;
                }
                else if (node.left != null && node.right != null)
                {
                    DynamicBST<T>lchild = node.left;
                    DynamicBST<T>rchild = node.right;
                    // случай когда есть оба потомки но у правого потомка нет 
                    //левого потомка и у левого потомка нет правого потомка
                    if (lchild.right == null && rchild.left == null)
                    {
                        node.data = lchild.data;
                        node.left = lchild.left;
                        if (lchild.left != null) lchild.left.parent = node;
                        lchild = null;
                        deletion_state = 3;
                    }
                    //случай когда у хотя бы один из потомков есть оба потомки
                    else if (lchild.right != null)
                    {
                        DynamicBST<T> current = lchild.right;
                        while (current.right != null) current = current.right;
                        node.data = current.data;
                        current = null;
                        deletion_state = 4;
                    }
                    else
                    {
                        DynamicBST<T> current = lchild.left;
                        while (current.left != null) current = current.left;
                        node.data = current.data;
                        current = null;
                        deletion_state = 5;
                    }
                    count--;
                }
            }
            return deletion_state;
        }
        /// <summary>
        /// поиск и проверки вершины на существование
        /// </summary>
        /// <param name="node">вершина которая найдена</param>
        /// <param name="data">данные в вершине</param>
        /// <returns>истина если найдена иначе ложь</returns>
        public bool NodeExists(ref BinTreeNodes<T> node, T data)
        {
            bool found = false;
            if (count != 0)
            {
                //создание вершины поиска 
                BinTreeNodes<T> temp = root;
                BinTreeNodes<T> searchnode = new BinTreeNodes<T>(data);
                // поиск вершины
                while(temp != null && temp.data.CompareTo(searchnode.data) != 0)
                {
                    if(searchnode.data.CompareTo(temp.data) < 0)
                    {
                        temp = temp.left;
                    }
                    else temp = temp.right;
                }
                if (temp != null)
                {
                    found = true;
                    node = temp;
                }
            }
            return found;
        }
        /// <summary>
        /// обход дерева в прямом порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> PreOrder()
        {
            SingleLinkedList<T> BST = new SingleLinkedList<T>();
            PreOrderRec(BST, root);
            return BST;

        }
        /// <summary>
        /// рекурсивная часть прямого обхода дерева 
        /// </summary>
        /// <param name="BST"> список порядка обхода</param>
        /// <param name="node">текщая вершина</param>
        void PreOrderRec(SingleLinkedList<T> BST, DynamicBST<T> node)
        {
            BST.AddLast(node.data);
            if (node != null)
            {
                if (node.left != null) PreOrderRec(BST, node.left);
                if (node.right != null) PreOrderRec(BST, node.right);
            }
        }
        /// <summary>
        /// обход дерева в симметричном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> InOrder()
        {
            SingleLinkedList<T> BST = new SingleLinkedList<T>();
            DynamicBST<T> curr = root;
            InOrderRec(BST, root);
            return BST;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в симметричном порядке
        /// </summary>
        /// <param name="BST">список порядок обхода</param>
        /// <param name="node">текущая вершина</param>
        void InOrderRec(SingleLinkedList<T> BST, DynamicBST<T> node)
        {
            if (node != null)
            {
                if (node.left != null) InOrderRec(BST, node.left);
                BST.AddLast(node.data);
                if (node.right != null) InOrderRec(BST, node.right);
            }
        }
        /// <summary>
        /// обход дерева в обратном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> PostOrder()
        {
            SingleLinkedList<T> BST = new SingleLinkedList<T>();
            DynamicBST<T> curr = root;
            PostOrderRec(BST, root);
            return BST;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в обратном порядке
        /// </summary>
        /// <param name="BST">список порядок обхода</param>
        /// <param name="node">текущая вершина</param>
        SingleLinkedList<T> PostOrderRec(SingleLinkedList<T> BST, DynamicBST<T> node)
        {
            if (node != null)
            {
                if (node.left != null) PostOrderRec(BST, node.left);
                if (node.right != null) PostOrderRec(BST, node.right);
                BST.AddLast(node.data);
            }
            return BST;
        }
    }
    /// <summary>
    /// реализации бинарного дерева поиска в мвссиве
    /// </summary>
    /// <typeparam name="T">тип данных храняющий в дереве</typeparam>
    public class ArrayBST<T> where T :IComparable<T>
    { 
        public int TreeSize;
        public int count;
        public T[] Btree;
        public ArrayBST(int size)
        {
            TreeSize = size;
            Btree = new T[size];
            count = 0;
            InitArray();
        }
        void InitArray()
        {
            for (int i = 0; i < Btree.Length; i++)
            {
                Btree[i] = default(T);
            }
        }
        /// <summary>
        /// добавление новой вершины в дерево
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(T data)
        {
            int currentindex = 0;
            if (NodeExists(data)) return;
            if (count == 0)
            {
                Btree[0] = data;//добавление корня
                count++;
            }
            else while (currentindex < TreeSize)
                {
                    if (Btree[currentindex].CompareTo(default(T)) == 0)
                    {
                        Btree[currentindex] = data;
                        count++;
                        break;
                    }
                    else if (data.CompareTo(Btree[currentindex]) > 0)// правоое поддерево
                    {
                        currentindex = (2 * currentindex + 2);
                    }
                    else currentindex = (2 * currentindex + 1);//левое поддерево
                }
        }
        /// <summary>
        /// поиск вершины в дереве
        /// </summary>
        /// <param name="data">данная в вершине</param>
        /// <returns>истинна если найдена вершина иначе ложь</returns>
        public bool NodeExists(T data)
        {
            bool found = false;
            int currentindex = 0;
            while (found == false && currentindex < count)
            {
                if (Btree[currentindex].CompareTo(data) == 0)
                {
                    found = true;
                }
                else if (Btree[currentindex].CompareTo(data) > 0) 
                {
                    currentindex = (2 * currentindex + 2);
                }
                else currentindex = (2 * currentindex + 1);
            }
            return found;
        }
        /// <summary>
        /// обход дерева в прямом порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public List<T> PreOrder()
        {
            List<T> orderlist = new List<T>();
            int currentindex = 0;
            PreOrderRec(orderlist, currentindex);
            return orderlist;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в прямом порядке
        /// </summary>
        /// <param name="orderlist">список порядка посещения</param>
        /// <param name="currentindex">текущий индекс в массиве</param>
        /// <returns>порядок посещения</returns>
        List<T> PreOrderRec(List<T> orderlist, int currentindex)
        {
            orderlist.Add(Btree[currentindex]);
            if (currentindex < count)
            {
                PreOrderRec(orderlist, currentindex + 1);                
                PreOrderRec(orderlist, currentindex + 2);
            }
            return orderlist;
        }
        /// <summary>
        /// обход дерева в обратном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public List<T> PostOrder()
        {
            List<T> orderlist = new List<T>();
            int currentindex = 0;
            PostOrderRec(orderlist, currentindex);
            return orderlist;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в обратном порядке
        /// </summary>
        /// <param name="orderlist">список порядка посещения</param>
        /// <param name="currentindex">текущий индекс в массиве</param>
        /// <returns>порядок посещения</returns>
        List<T> PostOrderRec(List<T> orderlist, int currentindex)
        {
            if (currentindex < count)
            {
                PostOrderRec(orderlist, currentindex + 1);
                PostOrderRec(orderlist, currentindex + 2);
                orderlist.Add(Btree[currentindex]);
            }
            return orderlist;
        }
        /// <summary>
        /// обход дерева в симметричном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public List<T> InOrder()
        {
            List<T> orderlist = new List<T>();
            int currentindex = 0;
            InOrderRec(orderlist, currentindex);
            return orderlist;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в симметричном порядке
        /// </summary>
        /// <param name="orderlist">список порядка посещения</param>
        /// <param name="currentindex">текущий индекс в массиве</param>
        /// <returns>порядок посещения</returns>
        List<T> InOrderRec(List<T> orderlist, int currentindex)
        {
            if (currentindex < count)
            {
                InOrderRec(orderlist, currentindex + 1);
                orderlist.Add(Btree[currentindex]);
                InOrderRec(orderlist, currentindex + 2);
            }
            return orderlist;
        }
    }

}
