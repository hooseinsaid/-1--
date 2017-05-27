using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб_9___Списки;

namespace Сам_Работа_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> MyList = new DoubleLinkedList<int>();//создание список
            //добавление элементов
            MyList.AddLast(2);
            MyList.AddLast(3);
            MyList.AddLast(6);
            MyList.AddLast(7);
            MyList.AddLast(9);
            MyList.AddLast(1);
            MyList.AddLast(10);
            MyList.PrintNodes();//введение на экране
            Console.WriteLine("\n" + "***************************" + "\n");
            Сам_Работа DoubleElements = new Сам_Работа();
            int last_element = DoubleElements.Element_Doubling(ref MyList);//дублирование
            MyList.PrintNodes();//введение на экране
            Console.WriteLine("\n" + "***************************" + "\n");
            Console.WriteLine("последный элемент равен  " + last_element);//указатель на плследный элемент
            Console.ReadLine();

        }
    }
}
