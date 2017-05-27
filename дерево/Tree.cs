using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace дерево
{

    public abstract class Tree<T> where T:IComparable<T>
    {
        public Node<T> root;
        public int count;
        public Tree()
        {
            root = null;
            count = 0;
        }
        public bool IsEmpty()
        {
            if (count == 0) return false;
            else return true;
        }
        public void Clear()
        {
            root = null;
        }
    }
}
