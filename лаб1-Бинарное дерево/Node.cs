using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace дерево
{
    public class Node<T> where T : IComparable<T>
    {
        public T data;
        public Node<T> parent;
        public NodeList<T> Children;
        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> Children)
        {
            this.data = data;
            this.Children = Children;
        }
        /// <summary>
        /// переопределение оператоа "меньше"
        /// </summary>
        /// <param name="node1">параметр 1</param>
        /// <param name="node2">параметр 2</param>
        /// <returns>да если параметр1 меньше параметр 2, иначе нет</returns>
        public static bool operator <(Node<T> node1, Node<T> node2)
        {
            return node1.data.CompareTo(node2.data) < 0;
        }
        /// <summary>
        ///  переопределение оператоа "больше"
        /// </summary>
        /// <param name="node1">параметр 1</param>
        /// <param name="node2">параметр 2</param>
        /// <returns>да если параметр1 больше параметр 2, иначе нет</returns>
        public static bool operator >(Node<T> node1, Node<T> node2)
        {
            return node1.data.CompareTo(node2.data) > 0;
        }
        /// <summary>
        /// переопределение оператоа "=="
        /// </summary>
        /// <param name="node1">параметр 1</param>
        /// <param name="node2">параметр 2</param>
        /// <returns>да если параметр1 равен параметру 2, иначе нет</returns>
        public static bool operator ==(Node<T> node1, Node<T> node2)
        {
            if (node1.Equals(null) && node2.Equals(null)) return true;
            else if (node1.Equals(null) || node2.Equals(null)) return false;
            else return (node1.data.CompareTo(node2.data) == 0) ? true : false;
        }
        /// <summary>
        /// переопределение оператоа "!="
        /// </summary>
        /// <param name="node1">параметр 1</param>
        /// <param name="node2">параметр 2</param>
        /// <returns>да если параметр1 не равен параметру 2, иначе нет</returns>
        public static bool operator !=(Node<T> node1, Node<T> node2)
        {
            return node1 == node2 ? false : true;
        }
    }
    public class NodeList<T> : Collection<Node<T>> where T : IComparable<T>
    {
        public NodeList() : base() { }
        public NodeList(int Children_size)
        {
            for (int i = 0; i < Children_size; i++)
                base.Items.Add(default(Node<T>));
        }
        public Node<T> FindNode(T data)
        {
            foreach (Node<T> node in Items)
                if (node.data.Equals(data)) return node;
            return null;
        }
    }
    public class BinTreeNodes<T> : Node<T> where T : IComparable<T>
    {
        public BinTreeNodes<T> parent;
        public BinTreeNodes<T> left;
        public BinTreeNodes<T> right;
        public BinTreeNodes() : base() { }
        public BinTreeNodes(T data) : base(data, null) { }
        public BinTreeNodes(T data, BinTreeNodes<T> left, BinTreeNodes<T> right)
        {
            base.data = data;
            parent = (BinTreeNodes<T>)base.parent;
            NodeList<T> Children = new NodeList<T>(2);
            Children[0] = left;
            Children[1] = right;
            base.Children = Children;
            this.left = (BinTreeNodes<T>)base.Children[0];
            this.right = (BinTreeNodes<T>)base.Children[1];

        }

    }
}
