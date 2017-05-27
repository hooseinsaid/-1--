using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Лаб_9___Списки;

namespace дерево
{
    public abstract class BinTree<T>:Tree<T> where T:IComparable<T>
    {
        public BinTree()
        {
            root = (BinTreeNodes<T>)base.root;
        }
        new public BinTreeNodes<T> root;
        public Node<T> current;
        /// <summary>
        /// обход дерева в прямом порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> PreOrder()
        {
            SingleLinkedList<T> node_list = new SingleLinkedList<T>();
            PreOrderRec(node_list, root);
            return node_list;

        }
        /// <summary>
        /// рекурсивная часть прямого обхода дерева 
        /// </summary>
        /// <param name="node_list"> список порядка обхода</param>
        /// <param name="node">текщая вершина</param>
        void PreOrderRec(SingleLinkedList<T> node_list, BinTreeNodes<T> node)
        {
            node_list.AddLast(node.data);
            if (node != null)
            {
                if (node.left != null) PreOrderRec(node_list, node.left);
                if (node.right != null) PreOrderRec(node_list, node.right);
            }
        }
        /// <summary>
        /// обход дерева в симметричном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> InOrder()
        {
            SingleLinkedList<T> node_list = new SingleLinkedList<T>();
            InOrderRec(node_list, root);
            return node_list;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в симметричном порядке
        /// </summary>
        /// <param name="node_list">список порядок обхода</param>
        /// <param name="node">текущая вершина</param>
        void InOrderRec(SingleLinkedList<T> node_list, BinTreeNodes<T> node)
        {
            if (node != null)
            {
                if (node.left != null) InOrderRec(node_list, node.left);
                node_list.AddLast(node.data);
                if (node.right != null) InOrderRec(node_list, node.right);
            }
        }
        /// <summary>
        /// обход дерева в обратном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        public SingleLinkedList<T> PostOrder()
        {
            SingleLinkedList<T> node_list = new SingleLinkedList<T>();
            PostOrderRec(node_list, root);
            return node_list;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в обратном порядке
        /// </summary>
        /// <param name="node_list">список порядок обхода</param>
        /// <param name="node">текущая вершина</param>
        SingleLinkedList<T> PostOrderRec(SingleLinkedList<T> node_list, BinTreeNodes<T> node)
        {
            if (node != null)
            {
                if (node.left != null) PostOrderRec(node_list, node.left);
                if (node.right != null) PostOrderRec(node_list, node.right);
                node_list.AddLast(node.data);
            }
            return node_list;
        }
        /// <summary>
        /// поиск вершины 
        /// </summary>
        /// <param name="searchpath">путь поиска</param>
        /// <param name="data">данные в вершине</param>
        /// <returns>истина если найдена иначе ложь</returns>
        public BinTreeNodes<T> Search(ref SingleLinkedList<T> searchpath, T data)
        {
            BinTreeNodes<T> res = null;
            BinTreeNodes<T> searchnode = new BinTreeNodes<T>(data);
            if (count != 0)
            {
                //создание вершины поиска 
                BinTreeNodes<T> temp = root;              
                // поиск вершины
                while (temp != null && temp != searchnode)
                {
                    searchpath.AddLast(temp.data);
                    if (searchnode < temp)
                    {
                        temp = temp.left;
                    }
                    else temp = temp.right;
                }
                if (temp != null)
                {
                    res = temp;
                    searchpath.AddLast(temp.data);
                }
            }
            return res;
        }
        /// <summary>
        /// проверка вершины на существование
        /// </summary>
        /// <param name="node">вершина которая найдена</param>
        /// <param name="data">данные в вершине</param>
        /// <returns>истина если найдена иначе ложь</returns>
        public bool NodeExists(ref BinTreeNodes<T> node, T data)
        {
            SingleLinkedList<T> searchpath = new SingleLinkedList<T>();
            node = Search(ref searchpath, data);
            if (node == null) return false;
            else return true;     
        }
    }
}
