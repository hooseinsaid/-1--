using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Лаб_9___Списки;

namespace дерево
{
    public class Node<T>where T:IComparable<T>
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
            if (System.Object.ReferenceEquals(node1, node2)) return true;
            else if ((object)node1 == null || (object)node2 == null) return false;
            else return (node1.data.CompareTo(node2.data) == 0)? true:false;
        }
        /// <summary>
        /// переопределение оператоа "!="
        /// </summary>
        /// <param name="node1">параметр 1</param>
        /// <param name="node2">параметр 2</param>
        /// <returns>да если параметр1 не равен параметру 2, иначе нет</returns>
        public static bool operator !=(Node<T> node1, Node<T> node2)
        {
            return node1 == node2? false:true;
        }
        public override bool Equals(object obj)
        {
 	        return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class NodeList<T>: Collection<Node<T>> where T:IComparable<T>
    {
        public NodeList() : base() { }
        public NodeList(int Children_size)
        {
            for (int i = 0; i < Children_size; i++)
                base.Items.Add(default(Node<T>));
        }
        public Node<T> FindNode(T data)
        {
            foreach(Node<T> node in Items)
                if(node.data.Equals(data))return node;
            return null;
        }
    }
    public class BTreeNode<T> :Node<T> where T : IComparable<T>
    {
        public SingleLinkedList<T> value;
        public BTreeNode<T> left, right;
        int minDegree;
        public BTreeNode(int minDegree = 2, BTreeNode<T> left = null, BTreeNode<T> right = null)
            //: base(default(T), left, right)
        {
            this.minDegree = minDegree;
            this.right = right; this.left = left;
            this.value = new SingleLinkedList<T>();
        }
        /// <summary>
        /// Получает дочерний узел, в поддереве которого долежн находится элемент key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BTreeNode<T> SelectChild(T key)
        {
            BTreeNode<T> child = left;
            int i = 0;
            while (i < value.count && child != null && value.ElementAt(i).CompareTo(key) <= 0)
            {
                i++;
                child = child.right;
            }
            return child;
        }
        public bool IsOverflowed()
        {
            return (value.count == 2 * minDegree - 1);
        }
        public bool IsNotFlowed()
        {
            return (value.count < minDegree - 1);
        }
        public int AddData(T key)
        {
            if (value.count == 0)
            {
                value.AddLast(key);
                return 0;
            }
            int i = 0;
            while (i < value.count && value.ElementAt(i).CompareTo(key) <= 0)
            {
                i++;
            }
            value.InsertAt(key,i);
            return i;
        }
        public override string ToString()
        {
            string result = string.Empty;
            for(int i = 0; i < value.count;i++)
            {
                result += value.ElementAt(i) + " ";
            }
            return result;
        }
        public BTreeNode<T> LeftBrother(BTreeNode<T> parent)
        {
            BTreeNode<T> leftBrother = (BTreeNode<T>)parent.left;
            if (leftBrother == null || leftBrother.Equals(this)) return null;
            while (leftBrother.right != null && !leftBrother.right.Equals(this))
            {
                leftBrother = (BTreeNode<T>)leftBrother.right;
            }
            return leftBrother;
        }
        public BTreeNode<T> LastChild()
        {
            if (left == null) return null;
            else
            {
                BTreeNode<T> lastChild = (BTreeNode<T>)left;
                while (lastChild.right != null)
                    lastChild = (BTreeNode<T>)lastChild.right;
                return lastChild;
            }
        }
    }
    public class BinTreeNodes<T>:Node<T>where T:IComparable<T>
    {
        new public BinTreeNodes<T> parent;
        public int balance;
        public BinTreeNodes<T> left;
        public BinTreeNodes<T> right;
        public BinTreeNodes() : base() { }
        public BinTreeNodes(T data) : base(data, null) { }
        public BinTreeNodes(T data, BinTreeNodes<T> left, BinTreeNodes<T> right)
        {
            this.parent = (BinTreeNodes<T>)base.parent;
            base.data = data;
            NodeList<T> Children = new NodeList<T>(2);
            Children[0] = left;
            Children[1] = right;
            base.Children = Children;
            this.left = (BinTreeNodes<T>) base.Children[0];
            this.right = (BinTreeNodes<T>) base.Children[1];

        }
    }
    public class MWayTreeNodes<T> : Node<T>where T : IComparable<T>
    {
        new public MWayTreeNodes<T> parent;
        public int degree;
        public MWayTreeNodes() : base() { }
        public MWayTreeNodes(T data) : base(data, null) { }
       
    }
}
