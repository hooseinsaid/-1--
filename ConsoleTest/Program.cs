using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб_9___Списки;
using дерево;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Btree_Test();
            AVL_test();
            DynamicBST<int> MyTree = new DynamicBST<int>();
            ArrayBST<int> MyTree1 = new ArrayBST<int>(40);
            MyTree.AddNode(5);
            MyTree.AddNode(7);
            MyTree.AddNode(10);
            MyTree.AddNode(3);
            MyTree.AddNode(8);
            MyTree.AddNode(9);
            MyTree.AddNode(10);
            SingleLinkedList<int> ar = MyTree.InOrder();
            for (int i = 0; i < ar.count; i++)
            {
                Console.WriteLine(ar.ElementAt(i));
            }
            Console.ReadLine();
        }
        /*static void BTree()
        {
            /*BTree<int, string> Mytree = new BTree<int, string>(3);
            Mytree.Insert(3, "Felipe");
            Mytree.Insert(6, "Kenneth");
            Mytree.Insert(3, "Igor");
            Mytree.Insert(3, "Aleksei");
            //for(int i = 0; i < Mytree)/

        }*/
        static void AVL_test()
        {
            Treap<int> Mytree = new Treap<int>();
            Mytree.AddNode(3);
            Mytree.AddNode(6);
            Mytree.AddNode(4);
            Mytree.AddNode(5);
            Mytree.DeleteNode(4);
            BinTreeNodes<int> node = new BinTreeNodes<int>(6);
            Console.WriteLine(Mytree.NodeExists(ref node,4));
            SingleLinkedList<int> tree = Mytree.PreOrder();
            for (int i = 0; i < tree.count; i++) Console.WriteLine(tree.ElementAt(i));
            Console.WriteLine("\n" + Mytree.root.data);
            Console.ReadLine();
        }
        static void Btree_Test()
        {
            BTree<int> Mytree = new BTree<int>();
            Mytree.AddNode(3);
            Mytree.AddNode(6);
            Mytree.AddNode(4);
            Mytree.AddNode(5);
            Mytree.DeleteNode(4);
            BinTreeNodes<int> node = new BinTreeNodes<int>(6);
            //Console.WriteLine(Mytree.NodeExists(ref node, 4));
            //SingleLinkedList<int> tree = Mytree.PreOrder();
            //for (int i = 0; i < tree.count; i++) Console.WriteLine(tree.ElementAt(i));
            Console.WriteLine(Mytree.count);
            Console.ReadLine();
        }
    }
}
