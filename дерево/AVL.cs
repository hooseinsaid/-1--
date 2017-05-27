using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Лаб_9___Списки;

namespace дерево
{
    public class AVL<T> : BinTree<T> where T : IComparable<T>
    {
        public AVL()
        {

        }
        /// <summary>
        /// добавление вершины в дерево
        /// </summary>
        /// <param name="data">значение на вершине</param>
        /// <returns>в какое напраление вершина добавлена</returns>
        public int AddNode(T data)
        {
            int direction = 0;
            BinTreeNodes<T> temp = new BinTreeNodes<T>();
            if (!NodeExists(ref temp, data))
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
                    while ((newnode > current && current.right != null)
                        || (newnode < current && current.left != null))
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
                    if (newnode > current)
                    {
                        current.right = newnode;
                        direction = 1;
                        InsertBalance(newnode, -1);
                    }
                    //добавление на левое поддереве
                    else
                    {
                        current.left = newnode;
                        direction = -1;
                        InsertBalance(newnode, 1);
                    }
                    count++;
                }
            }
            return direction;
        }
        /// <summary>
        /// добавление баланса
        /// </summary>
        /// <param name="node">вершина</param>
        /// <param name="balance">значение баланса вершины</param>
        private void InsertBalance(BinTreeNodes<T> node, int balance)
        {
            while (node != null)
            {
                balance = (node.balance += balance);

                if (balance == 0)
                {
                    return;
                }
                else if (balance == 2)
                {
                    if (node.left.balance == 1)
                    {
                        RotateRight(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }

                    return;
                }
                else if (balance == -2)
                {
                    if (node.right.balance == -1)
                    {
                        RotateLeft(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }

                    return;
                }

                if (node.parent != null)
                {
                    balance = node.parent.left == node ? 1 : -1;
                }

                node = node.parent;
            }
        }
        /// <summary>
        /// левое вращение
        /// </summary>
        /// <param name="node">вершина для вращения </param>
        /// <returns></returns>
        private BinTreeNodes<T> RotateLeft(BinTreeNodes<T> node)
        {
            BinTreeNodes<T> right = node.right;
            BinTreeNodes<T> rightLeft = right.left;
            BinTreeNodes<T> parent = node.parent;

            right.parent = parent;
            right.left = node;
            node.right = rightLeft;
            node.parent = right;

            if (rightLeft != null)
            {
                rightLeft.parent = node;
            }

            if (node == root)
            {
                root = right;
            }
            else if (parent.right == node)
            {
                parent.right = right;
            }
            else
            {
                parent.left = right;
            }

            right.balance++;
            node.balance = -right.balance;

            return right;
        }
        /// <summary>
        /// правое вращение
        /// </summary>
        /// <param name="node">вершина для вращения</param>
        /// <returns></returns>
        private BinTreeNodes<T> RotateRight(BinTreeNodes<T> node)
        {
            BinTreeNodes<T> left = node.left;
            BinTreeNodes<T> leftRight = left.right;
            BinTreeNodes<T> parent = node.parent;

            left.parent = parent;
            left.right = node;
            node.left = leftRight;
            node.parent = left;

            if (leftRight != null)
            {
                leftRight.parent = node;
            }

            if (node == root)
            {
                root = left;
            }
            else if (parent.left == node)
            {
                parent.left = left;
            }
            else
            {
                parent.right = left;
            }

            left.balance--;
            node.balance = -left.balance;

            return left;
        }
        /// <summary>
        /// Левое_правое вращение
        /// </summary>
        /// <param name="node">вершина для вращения</param>
        /// <returns></returns>
        private BinTreeNodes<T> RotateLeftRight(BinTreeNodes<T> node)
        {
            BinTreeNodes<T> left = node.left;
            BinTreeNodes<T> leftRight = left.right;
            BinTreeNodes<T> parent = node.parent;
            BinTreeNodes<T> leftRightRight = leftRight.right;
            BinTreeNodes<T> leftRightLeft = leftRight.left;

            leftRight.parent = parent;
            node.left = leftRightRight;
            left.right = leftRightLeft;
            leftRight.left = left;
            leftRight.right = node;
            left.parent = leftRight;
            node.parent = leftRight;

            if (leftRightRight != null)
            {
                leftRightRight.parent = node;
            }

            if (leftRightLeft != null)
            {
                leftRightLeft.parent = left;
            }

            if (node == root)
            {
                root = leftRight;
            }
            else if (parent.left == node)
            {
                parent.left = leftRight;
            }
            else
            {
                parent.right = leftRight;
            }

            if (leftRight.balance == -1)
            {
                node.balance = 0;
                left.balance = 1;
            }
            else if (leftRight.balance == 0)
            {
                node.balance = 0;
                left.balance = 0;
            }
            else
            {
                node.balance = -1;
                left.balance = 0;
            }

            leftRight.balance = 0;

            return leftRight;
        }
        /// <summary>
        /// Правое-Левое вращение 
        /// </summary>
        /// <param name="node">вершина для вращения</param>
        /// <returns></returns>
        private BinTreeNodes<T> RotateRightLeft(BinTreeNodes<T> node)
        {
            BinTreeNodes<T> right = node.right;
            BinTreeNodes<T> rightLeft = right.left;
            BinTreeNodes<T> parent = node.parent;
            BinTreeNodes<T> rightLeftLeft = rightLeft.left;
            BinTreeNodes<T> rightLeftRight = rightLeft.right;
            rightLeft.parent = parent;
            node.right = rightLeftLeft;
            right.left = rightLeftRight;
            rightLeft.right = right;
            rightLeft.left = node;
            right.parent = rightLeft;
            node.parent = rightLeft;

            if (rightLeftLeft != null)
            {
                rightLeftLeft.parent = node;
            }

            if (rightLeftRight != null)
            {
                rightLeftRight.parent = right;
            }

            if (node == root)
            {
                root = rightLeft;
            }
            else if (parent.right == node)
            {
                parent.right = rightLeft;
            }
            else
            {
                parent.left = rightLeft;
            }

            if (rightLeft.balance == 1)
            {
                node.balance = 0;
                right.balance = -1;
            }
            else if (rightLeft.balance == 0)
            {
                node.balance = 0;
                right.balance = 0;
            }
            else
            {
                node.balance = 1;
                right.balance = 0;
            }

            rightLeft.balance = 0;

            return rightLeft;
        }
        /// <summary>
        /// удалить вершину
        /// </summary>
        /// <param name="data">значение на вершине</param>
        /// <returns></returns>
        public bool DeleteNode(T data)
        {
            BinTreeNodes<T> temp = root;
            BinTreeNodes<T> node = new BinTreeNodes<T>(data);

            while (temp != null)
            {
                if (node < temp)
                {
                    temp = temp.left;
                }
                else if (node > temp)
                {
                    temp = temp.right;
                }
                else
                {
                    BinTreeNodes<T> left = temp.left;
                    BinTreeNodes<T> right = temp.right;

                    if (left == null)
                    {
                        if (right == null)
                        {
                            if (temp == root)
                            {
                                root = null;
                            }
                            else
                            {
                                BinTreeNodes<T> parent = temp.parent;

                                if (parent.left == temp)
                                {
                                    parent.left = null;

                                    DeleteBalance(parent, -1);
                                }
                                else
                                {
                                    parent.right = null;

                                    DeleteBalance(parent, 1);
                                }
                            }
                        }
                        else
                        {
                            Replace(temp, right);

                            DeleteBalance(temp, 0);
                        }
                    }
                    else if (right == null)
                    {
                        Replace(temp, left);

                        DeleteBalance(temp, 0);
                    }
                    else
                    {
                        BinTreeNodes<T> successor = right;

                        if (successor.left == null)
                        {
                            BinTreeNodes<T> parent = temp.parent;

                            successor.parent = parent;
                            successor.left = left;
                            successor.balance = temp.balance;

                            if (left != null)
                            {
                                left.parent = successor;
                            }

                            if (temp == root)
                            {
                                root = successor;
                            }
                            else
                            {
                                if (parent.left == temp)
                                {
                                    parent.left = successor;
                                }
                                else
                                {
                                    parent.right = successor;
                                }
                            }

                            DeleteBalance(successor, 1);
                        }
                        else
                        {
                            while (successor.left != null)
                            {
                                successor = successor.left;
                            }

                            BinTreeNodes<T> parent = temp.parent;
                            BinTreeNodes<T> successorParent = successor.parent;
                            BinTreeNodes<T> successorRight = successor.right;

                            if (successorParent.left == successor)
                            {
                                successorParent.left = successorRight;
                            }
                            else
                            {
                                successorParent.right = successorRight;
                            }

                            if (successorRight != null)
                            {
                                successorRight.parent = successorParent;
                            }

                            successor.parent = parent;
                            successor.left = left;
                            successor.balance = temp.balance;
                            successor.right = right;
                            right.parent = successor;

                            if (left != null)
                            {
                                left.parent = successor;
                            }

                            if (temp == root)
                            {
                                root = successor;
                            }
                            else
                            {
                                if (parent.left == temp)
                                {
                                    parent.left = successor;
                                }
                                else
                                {
                                    parent.right = successor;
                                }
                            }

                            DeleteBalance(successorParent, -1);
                        }
                    }

                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Удаление баланса
        /// </summary>
        /// <param name="node">вершина</param>
        /// <param name="balance">значение баланса вершины</param>
        private void DeleteBalance(BinTreeNodes<T> node, int balance)
        {
            while (node != null)
            {
                balance = (node.balance += balance);

                if (balance == 2)
                {
                    if (node.left.balance >= 0)
                    {
                        node = RotateRight(node);

                        if (node.balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateLeftRight(node);
                    }
                }
                else if (balance == -2)
                {
                    if (node.right.balance <= 0)
                    {
                        node = RotateLeft(node);

                        if (node.balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateRightLeft(node);
                    }
                }
                else if (balance != 0)
                {
                    return;
                }

                BinTreeNodes<T> parent = node.parent;

                if (parent != null)
                {
                    balance = parent.left == node ? -1 : 1;
                }

                node = parent;
            }
        }
        /// <summary>
        /// заменить значение вершины
        /// </summary>
        /// <param name="target">вершина для замены</param>
        /// <param name="source">вершина содержащое значение для замены</param>
        private static void Replace(BinTreeNodes<T> target, BinTreeNodes<T> source)
        {
            BinTreeNodes<T> left = source.left;
            BinTreeNodes<T> right = source.right;

            target.balance = source.balance;
            target.data = source.data;
            target.left = left;
            target.right = right;

            if (left != null)
            {
                left.parent = target;
            }

            if (right != null)
            {
                right.parent = target;
            }
        }
        /// <summary>
        /// пойск вершин в дереве
        /// </summary>
        /// <param name="data">значение вершины</param>
        /// <returns>истинна если есть; ложь если нет</returns>
        public bool Search(T data)
        {
            BinTreeNodes<T> temp = root;
            BinTreeNodes<T> node = new BinTreeNodes<T>(data);

            while (temp != null)
            {
                if (node < temp)
                {
                    temp = temp.left;
                }
                else if (node > temp)
                {
                    temp = temp.right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
        public int Tree_Copy(BinTreeNodes<T> Copy_root)
        {
            int dir = 0;
            if (root == null)
            {
                root = new BinTreeNodes<T>(Copy_root.data);
                count++;
            }
            else
            {
                BinTreeNodes<T> Current = root;
                T data = Copy_root.data;
                while (((Copy_root > Current) && (Current.right != null)) || ((Copy_root < Current) && (Current.left != null)))
                {
                    if (Copy_root > Current)
                    {
                        //Copy_root = Copy_root.right;
                        Current = Current.right;
                    }
                    else
                    {

                        //Copy_root = Copy_root.left;
                        Current = Current.left;
                    }
                }
                BinTreeNodes<T> newN = new BinTreeNodes<T>(Copy_root.data);
                newN.left = null;
                newN.right = null;
                newN.parent = Current;
                count++;
                if (Copy_root != Current)
                {
                    if (Copy_root > Current)
                    {
                        //newN.parent = Current;
                        Current.right = newN;

                        dir = 1;
                        count++;
                    }

                    else
                    {
                        //newN.parent = Current;
                        Current.left = newN;
                        dir = -1;
                        count++;
                    }
                }
            }
            return dir;
        }
    }       
}
