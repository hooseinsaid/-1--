using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace дерево
{
    public abstract class MWayTree<T>: Tree<T> where T:IComparable<T>
    {
        public Stack<Node<T>> path; 
        public Node<T>[] Keys;
        public MWayTree<T>[] Subtrees;
        public int M;
        public MWayTree() { }
        public MWayTree(int M)
        {
            this.M = M;
            if (M < 2) throw new ArgumentException("степень не правильно задана!");
            Keys = new Node<T>[M];
            Subtrees = new MWayTree<T>[M];
            path = new Stack<Node<T>>();
        }
        public int FindIndex(Node<T> node)
        {
            if (IsEmpty() || node < Keys[1]) return 0;
            int left = 1;
            int right = count;
            while (left < right)
            {
                int middle = (left + right + 1) / 2;
                if (node < Keys[middle])
                    right = middle - 1;
                else left = middle;

            }
            return left;
        }
        public Node<T> Find(T data)
        {
            if (IsEmpty()) return null;
            Node<T> node = new Node<T>(data);
            int Index = FindIndex(node);
            if (Index != 0 && node < Keys[Index]) return Keys[Index];
            else return Subtrees[Index].Find(data);                     
        }
        public abstract void AddNode(T data);
        protected abstract void AddRec(Node<T> currItem, T data);
    }
}
