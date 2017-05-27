using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб_9___Списки;

namespace Сам_Работа_1
{
    class Сам_Работа
    {
        /// <summary>
        /// дублирование нечетных элементов в списке
        /// </summary>
        /// <param name="MyList">список</param>
        /// <returns>последный элемент</returns>
        public int Element_Doubling(ref DoubleLinkedList<int> MyList)
        {
            for (int i = 0; i < MyList.count; i++)
            {
                if (MyList.ElementAt(i) % 2 == 1)//проверка на четность элемента
                {
                    MyList.InsertAt(MyList.ElementAt(i), (i + 1));// дублирование элемента
                    i++;
                }
            }
            return MyList.ElementAt(MyList.count - 1);
        }
    }
}
