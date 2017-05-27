using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб_9___Списки;
using дерево;

namespace Tree_Transversal
{
    class ClassWork
    {
        DynamicBST<int> Tree;
        public ClassWork(DynamicBST<int> Tree)
        {
            this.Tree = Tree;
        }
        public int Question18(DynamicBST<int> Tree)
        {
            return InOrder().count;
        }
        public SingleLinkedList<int> Question22()
        {
            return InOrder();
        }
        public DynamicBST<string> Question20(BTreeNode<string> A, DynamicBST<string> B)
        {
            DynamicBST<string> C = new DynamicBST<string>();
            Comparism(C, A.left, B);
            return C;
        }

        

        void Comparism(DynamicBST<string> C, BTreeNode<string> node, DynamicBST<string> B)
        {
            BinTreeNodes<string> node2 = new BinTreeNodes<string>();
            if (node != null)
            {
                if (node.left != null) Comparism(C, node.left, B);
                if (!B.NodeExists( ref node2, node.data)) C.AddNode(node.data);
                if (node.right != null) Comparism(C, node.right, B);
            }
        }
        /// <summary>
        /// обход дерева в симметричном порядке
        /// </summary>
        /// <returns>порядок посещения вершин</returns>
        private SingleLinkedList<int> InOrder()
        {
            SingleLinkedList<int> BST = new SingleLinkedList<int>();
           BinTreeNodes<int> curr = Tree.root;
            InOrderRec(BST, Tree.root);
            return BST;
        }
        /// <summary>
        /// рекурсивная часть обхода дерева в симметричном порядке
        /// </summary>
        /// <param name="BST">список порядок обхода</param>
        /// <param name="node">текущая вершина</param>
        void InOrderRec(SingleLinkedList<int> BST, BinTreeNodes<int> node)
        {
            if (node != null)
            {
                if (node.left != null) InOrderRec(BST, node.left);
                BST.AddLast(node.data);
                if (node.right != null) InOrderRec(BST, node.right);
            }
        }
    }
}
