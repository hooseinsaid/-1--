using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дерево;
using Лаб_9___Списки;

namespace Tree_Transversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Trasversal();
        }
       
        static void Trasversal()
        {
            DynamicBST<int> test_tree = new DynamicBST<int>();
            test_tree.AddNode(0);
            test_tree.AddNode(9);
            test_tree.AddNode(13);
            test_tree.AddNode(11);
            test_tree.AddNode(-9);
            test_tree.AddNode(-12);
            test_tree.AddNode(-4);
            test_tree.AddNode(-6);
            test_tree.AddNode(-2);
            SingleLinkedList<int> Pre_order = test_tree.PreOrder();
            SingleLinkedList<int> In_order = test_tree.InOrder();
            SingleLinkedList<int> Post_order = test_tree.PostOrder();
            Console.WriteLine("****************************Pre-Order Transversal********************");
            for (int i = 0; i < Pre_order.count; i++)
            {
                Console.WriteLine(Pre_order.ElementAt(i));
            }
            Console.WriteLine("****************************In-Order Transversal********************");
            for (int i = 0; i < In_order.count; i++)
            {
                Console.WriteLine(In_order.ElementAt(i));
            }
            Console.WriteLine("****************************Post-Order Transversal********************");
            for (int i = 0; i < Post_order.count; i++)
            {
                Console.WriteLine(Post_order.ElementAt(i));
            }
            Console.ReadLine();
        }
    }
}
