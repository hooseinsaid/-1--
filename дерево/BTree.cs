using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace дерево
{
    public class BTree<T> : MWayTree<T> where T : IComparable<T>
    {
        int minDegree;
        const double nul = 0;
        public new BTreeNode<T> root;
        public BTree()//: //base()
        {
            root = (BTreeNode<T>)base.root;
            minDegree = 2;
        }
        
        public BTree(int minDegree): base(minDegree)
        {
            root = (BTreeNode<T>)base.root; ;
            this.minDegree = minDegree;
        }
        public BTree(ICollection<T> collection, int minDegree)
        {
            this.minDegree = minDegree;
            root = new BTreeNode<T>(minDegree);
            foreach (T item in collection)
                this.AddNode(item);
        }
        public override void AddNode(T data)
        {
            AddRec(new BTreeNode<T>(2), data);
        }
        protected override void AddRec(Node<T> currItem, T data)
        {
            BTreeNode<T> item = (BTreeNode<T>)currItem;
            BTreeNode<T> parent = null;
            AddRec(ref item, ref parent, data);
        }
        protected void AddRec(ref BTreeNode<T> currItem, ref BTreeNode<T> parent, T data)
        {
            if(currItem.left != null)
            {
                BTreeNode<T> child = currItem.SelectChild(data);
                AddRec(ref child, ref currItem, data);
            }
            else 
            {
                currItem.AddData(data);
            }
            if(currItem.IsOverflowed())
            {
                T migratingKey = Split(ref currItem, ref parent);
                if (parent == null)
                {
                    parent = new BTreeNode<T>(minDegree);
                    parent.left = currItem;
                    root = parent;
                }
                parent.AddData(migratingKey);
            }
        }
        private T Split(ref BTreeNode<T> currItem, ref BTreeNode<T> parent)
        {
            BTreeNode<T> right = new BTreeNode<T>(minDegree);
            for(int i = currItem.value.count - 1; i > minDegree - 1; i--)
            {
                right.value.AddLast(currItem.value[i]);
                currItem.value.RemoveAt(currItem.value.count - 1);
            }
            right.right = currItem.right;
            currItem.right = right;
            int j = 0;
            BTreeNode<T> child = currItem.left;
            if (child != null)
            {
                BTreeNode<T> childLeft = currItem.left;
                while (j != minDegree) //оставляем от [0; t-1] ссылки у левого 
                {
                    childLeft = child;
                    child = child.right;
                    j++;
                }

                right.left = child; //остальные даём правому
                childLeft.right = null;
            }
            T item = currItem.value[minDegree - 1];
            currItem.value.RemoveAt(minDegree - 1);
            return item; //возвращаем серединное значение
        }
        /*protected override BTreeItem<T> Find(BTreeItem<T> currItem, T key)
        {
            return Find((BTreeItem<T>)currItem, key);
        }*/
        private BTreeNode<T> Find(BTreeNode<T> currItem, T key)
        {
            path.Push(currItem);
            if (currItem == null) return null;
            else
            {
                if (currItem.value.Contains(key)) return currItem;
                else return Find(currItem.SelectChild(key), key);
            }
        }

        public void DeleteNode(T data)
        {
            BTreeNode<T> currItem = root;
            BTreeNode<T> parent = null;
            Stack<BTreeNode<T>> stack = new Stack<BTreeNode<T>>();
            stack.Push(currItem);
            while (stack.Peek() != null && !stack.Peek().value.Contains(data)) //ищем элемент
                stack.Push(stack.Peek().SelectChild(data));
            if (stack.Peek() == null) //если элемент не найден
                return;
            else //элемент найден
            {
                BTreeNode<T> child = new BTreeNode<T>();
                if (stack.Peek().left == null) //если лист
                {
                    stack.Peek().value.Delete(data); //удаляем элемент
                    child = stack.Pop();
                }
                else
                {
                    BTreeNode<T> remItem = stack.Peek(); //сохраняем элемент
                    child = (BTreeNode<T>)remItem.left;
                    while (child != null) //ищем элемент, содержащий мнимальное значение
                    {
                        stack.Push(child);
                        child = (BTreeNode<T>)child.left;
                    }
                    child = stack.Pop();
                    T min = child.value[0];
                    child.value.Delete(min);
                    remItem.value.InsertAt(min,remItem.value.IndexOf(data)); //заменяем удаляемый ключ на минимум
                }
                if (stack.Count != 0) parent = stack.Pop();
                {
                    while (stack.Count > 0)
                    {                       
                        if (child.IsNotFlowed()) SolveNotFlowed(ref parent, ref child);
                        child = parent;
                        parent = stack.Pop();
                    }
                }
                if (child.IsNotFlowed()) SolveNotFlowed(ref parent, ref child);
                if (parent.value.count == 0 && parent == root)
                {
                    root = parent.left;
                }
            }
        }
        private void Merge(ref BTreeNode<T> parent, ref BTreeNode<T> left, ref BTreeNode<T> right)
        {
            BTreeNode<T> currChild = (BTreeNode<T>)parent.left;
            int i = -1;
            while (currChild != right)
            {
                currChild = (BTreeNode<T>)currChild.right;
                i++;
            }
            T parentSep = parent.value[i]; //разделитель родителя
            for(int j = 0; j < right.value.count; j++)
                left.value[left.value.count] = right.value[j]; //копируем значения узла
            BTreeNode<T> lastLeftChild = left.LastChild();
            if (lastLeftChild != null)
            {
                lastLeftChild.right = right.left;//копируем ссылки на детей
            }
            left.AddData(parentSep);
            parent.value.Delete(parentSep); //в родителе стало на 1 меньше узлов
            left.right = right.right; //остаётся только левый сын
            right = null;
        }
        private void SolveNotFlowed(ref BTreeNode<T> parent, ref BTreeNode<T> child)
        {
            BTreeNode<T> leftBrother = child.LeftBrother(parent);
            if (leftBrother != null)
            {
                if (leftBrother.value.count >= minDegree)
                {
                    BTreeNode<T> currChild = (BTreeNode<T>)parent.left;
                    int i = -1;
                    while (currChild!=child)
                    {
                        currChild = (BTreeNode<T>)currChild.right;
                        i++;
                    }
                    BTreeNode<T> lastLeftChild = leftBrother.LastChild();
                    lastLeftChild.LeftBrother(parent).right = null;
                    lastLeftChild.right = child.left;
                    child.left = lastLeftChild;
                    T parentSep = parent.value[i]; //элемент разделющий двух братьев
                    T leftSep = leftBrother.value[leftBrother.value.count - 1]; //разделитель из левого брата
                    leftBrother.value.Delete(leftSep);
                    parent.value[i] = leftSep; //разделитель родителя = разделитель брата
                    child.AddData(parentSep); //разделитель брата добавляется в незаполненный элемент
                    return;
                }
            }
            BTreeNode<T> rightBrother = (BTreeNode<T>)child.right;
            {
                if (rightBrother != null)
                {
                    if(rightBrother.value.count >= minDegree)
                    {
                        BTreeNode<T> currChild = (BTreeNode<T>)parent.left;
                        int i = -1;
                        while (currChild != rightBrother)
                        {
                            currChild = (BTreeNode<T>)currChild.right;
                            i++;
                        }
                        BTreeNode<T> leftlastChild = child.LastChild();
                        BTreeNode<T> rightFirstChild = (BTreeNode<T>)rightBrother.left;
                        rightBrother.left = rightFirstChild.right;
                        rightFirstChild.right = null;
                        leftlastChild.right = rightFirstChild;
                        T parentSep = parent.value[i]; //элемент разделющий двух братьев
                        T rightSep = rightBrother.value[0]; //разделитель из правого брата
                        rightBrother.value.Delete(rightSep);
                        parent.value[i] = rightSep; //разделитель родителя = разделитель брата
                        child.AddData(parentSep); //разделитель брата добавляется в незаполненный элемент
                        return;
                    }
                }
            }
            if (leftBrother != null)
            {
                Merge(ref parent, ref leftBrother, ref child);
                return;
            }
            if (rightBrother != null)
            {
                Merge(ref parent, ref child, ref rightBrother);
                return;
            }
        }

        /*public class BTreeItem<T>:TreeItem<T> where T: IComparable
        {
            public new MyList<T> value;
            int minDegree;
            public BTreeItem(int minDegree = 2, BTreeItem<T> left = null, BTreeItem<T> right = null)
                :base(default(T), left, right)
            {
                this.minDegree = minDegree;
                this.value = new MyList<T>();
            }
            /// <summary>
            /// Получает дочерний узел, в поддереве которого долежн находится элемент key.
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public BTreeItem<T> SelectChild(T key)
            {
                BTreeItem<T> child = (BTreeItem<T>)this.left;
                int i = 0;
                while (i < value.Count && child != null && value[i].CompareTo(key) <= 0)
                {
                    i++;
                    child = (BTreeItem<T>)child.right;
                }
                return child;
            }
            public bool IsOverflowed()
            {
                return (value.Count == 2 * minDegree - 1);
            }
            public bool IsNotFlowed()
            {
                return (value.Count < minDegree - 1);
            }
            public int AddKey(T key)
            {
                if (value.Count == 0)
                {
                    value.Add(key);
                    return 0;
                }
                int i = 0;
                while (i < value.Count && value[i].CompareTo(key) <= 0)
                {
                    i++;
                }
                value.Insert(i, key);
                return i;
            }
            public override string ToString()
            {
                string result = string.Empty;
                foreach (T item in value)
                {
                    result += item + " ";
                }
                return result;
            }
            public BTreeItem<T> LeftBrother(BTreeItem<T> parent)
            {
                BTreeItem<T> leftBrother = (BTreeItem<T>)parent.left;
                if (leftBrother == null || leftBrother.Equals(this)) return null;
                while (leftBrother.right != null && !leftBrother.right.Equals(this))
                {
                    leftBrother = (BTreeItem<T>)leftBrother.right;
                }
                return leftBrother;
            }
            public override bool Equals(object obj)
            {
                BTreeItem<T> item = obj as BTreeItem<T>;
                if (item != null)
                {
                    if (this.minDegree != item.minDegree) return false;
                    if (!this.value.Equals(item.value)) return false;
                    return true;
                }
                return false;
            }
            public BTreeItem<T> LastChild()
            {
                if (left == null) return null;
                else
                {
                    BTreeItem<T> lastChild = (BTreeItem<T>)left;
                    while (lastChild.right != null)
                        lastChild = (BTreeItem<T>)lastChild.right;
                    return lastChild;
                }
            }
        }
        /*new public Btree<T>[] Subtrees;
        public Btree<T> parent;
        public Btree()
        {
            Subtrees = (Btree<T>[])base.Subtrees;
        }
        public Btree(int M) : base(M) { }
        public void AttachSubtree(int i, MWayTree<T> arg)
        {
            Btree<T> btree = (Btree<T>)arg;
            Subtrees[i] = btree;
            btree.parent = this;
        }
        public void AddNode(T data)
        {
            Node<T> newnode = new Node<T>(data);
            if (count == 0)
            {
                if (parent == null)
                {
                    AttachSubtree(0, new Btree<T>(M));
                    Keys[1] = newnode;
                    AttachSubtree(1, new Btree<T>(M));
                    count = 1;
                }
                else parent.AddPair(data, new Btree<T>(M));
            }
            else
            {
                int index = FindIndex(newnode);
                if (!(index != 0 && newnode == Keys[index]))
                    Subtrees[index].AddNode(data);  
            }
        }
        public void AddPair(T data, Btree<T> child)
        {
            //int index = FindIndex()
        }*/
    }
}
