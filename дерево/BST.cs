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
        /// <summary>
        /// добавление новой вершины в дереве
        /// </summary>
        /// <param name="data">данные для хранения</param>
        /// <returns>-1 если левая, 1 если правая и 0 если добавлена</returns>
        public int AddNode(T data)
        {
            int direction = 0;
            BinTreeNodes<T> temp = new BinTreeNodes<T>();
            if (!NodeExists(ref temp,data))
            {
                BinTreeNodes<T> newnode = new BinTreeNodes<T>(data);
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
                    while (newnode > current && current.right != null
                        || newnode < current && current.left != null)
                    {
                        if (newnode > current)
                            current = current.right;
                        else current = current.left;

                    }
                    //создание новой вершины
                    newnode.left = null;
                    newnode.right = null;
                    newnode.parent = current;
                    // добавление на правое поддереве
                    if (newnode > current )
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
                    BinTreeNodes<T>lchild = node.left;
                    BinTreeNodes<T>rchild = node.right;
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
                        BinTreeNodes<T> current = lchild.right;
                        while (current.right != null) current = current.right;
                        node.data = current.data;
                        current = null;
                        deletion_state = 4;
                    }
                    else
                    {
                        BinTreeNodes<T> current = lchild.left;
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
    }

    public class SplayTree<T> : DynamicBST<T> where T: IComparable<T>
    {
        private int version = 0;
        new public void AddNode(T data)
        {
           
            BinTreeNodes<T> newnode = new BinTreeNodes<T>(data);
            if (count == 0)
            {
                version++;
                root = new BinTreeNodes<T>(data);
                count++;
                return;
            }
            if (!NodeExists(ref newnode, data))
            {
                newnode = new BinTreeNodes<T>(data);
                Splay(data);
                if (newnode < root)
                {
                    newnode.left = root.left;
                    newnode.right = root;
                    root.left = null;
                }
                else
                {
                    newnode.right = root.right;
                    newnode.left = root;
                    root.right = null;
                }
                root = newnode;
                count++;
                Splay(data);
                version++;
            }
        }
        private void Splay(T data)
        {
            BinTreeNodes<T> l, r, t, y, header, node;
            l = r = header = new BinTreeNodes<T>(default(T));
            t = this.root;
            node = new BinTreeNodes<T>(data);
            while (true)
            {
                if (node < t)
                {
                    if (t.left == null) break;
                    if (node < t.left)
                    {
                        y = t.left;
                        t.left = y.right;
                        y.right = t;
                        t = y;
                        if (t.left == null) break;
                    }
                    r.left = t;
                    r = t;
                    t = t.left;
                }
                else if (node > t)
                {
                    if (t.right == null) break;
                    if (node > t.right)
                    {
                        y = t.right;
                        t.right = y.left;
                        y.left = t;
                        t = y;
                        if (t.right == null) break;
                    }
                    l.right = t;
                    l = t;
                    t = t.right;
                }
                else
                {
                    break;
                }
            }
            l.right = t.left;
            r.left = t.right;
            t.left = header.right;
            t.right = header.left;
            this.root = t;
        }

        new public bool DeleteNode(T data)
        {
            BinTreeNodes<T> node = new BinTreeNodes<T>(data);
            if (count == 0)
            {
                return false;
            }

            this.Splay(data);
            if (node != root)
            {
                return false;
            }

            if (root.left == null)
            {
                root = root.right;
            }
            else
            {
                BinTreeNodes<T> swap = root.right;
                root = this.root.left;
                Splay(data);
                root.right = swap;
            }
            version++;
            count--;
            return true;
        }    
    }
    public class Treap<T> : DynamicBST<T> where T : IComparable<T>
    {
        Random random = new Random();
        new public int AddNode(T data)
        {
            Add(ref root, data);
            return 0;
        }

        void Add(ref BinTreeNodes<T> node, T data)
        {
            BinTreeNodes<T> newnode = new BinTreeNodes<T>(data);
            if (node == null)
            {
                node = new BinTreeNodes<T>(data);
                node.balance = random.Next();
                count++;
                return;
            }
            if (newnode < node)
            {
                Add(ref node.left, data);
                if (node.left.balance > node.balance)
                {
                    var x = node.left;
                    node.left = x.right;
                    x.right = node;
                    node = x;
                }
            }
            else if (newnode > node)
            {
                Add(ref node.right, data);
                if (node.balance < node.right.balance)
                {
                    var x = node.right;
                    node.right = x.left;
                    x.left = node;
                    node = x;
                }
            }
            else node.data = data;
        }
        static void Reorder(ref BinTreeNodes<T> node, BinTreeNodes<T> left, BinTreeNodes<T> right)
        {
            if (left == null)
            {
                node = right;
                return;
            }
            if (right == null)
            {
                node = left;
                return;
            }
            if (left.balance > right.balance)
            {
                node = left;
                Reorder(ref node.right, node.right, right);
            }
            else
            {
                node = right;
                Reorder(ref node.left, left, node.left);
            }
        }

        new public bool DeleteNode(T data)
        {
            return Remove(ref root, data);
        }

        bool Remove(ref BinTreeNodes<T> node, T data)
        {
            BinTreeNodes<T> datanode = new BinTreeNodes<T>(data);
            if (node == null)
                return false;
            if (datanode < node) return Remove(ref node.left, data);
            if (datanode > node) return Remove(ref node.right, data);

            if (node.left != null)
            {
                if (node.right != null) Reorder(ref node, node.left, node.right);
                else node = node.left;
            }
            else node = node.right;

            count--;
            return true;
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
