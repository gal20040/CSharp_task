using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>Сортировка методом простых вставок</summary>
    public class InsertionSort_Simple
    {
        private LinkedList<int> linkedList;

        public void Sort(ref int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            if (array.Length == 0) return;

            linkedList = new LinkedList<int>();

            //перебрать входной массив и добавить числа в связный список
            foreach (var number in array)
            {
                InsertBeforeLesserOrEqual(number);
            }

            //преобразовать список в массив
            array = linkedList.ToArray();
        }

        private void InsertBeforeLesserOrEqual(int number)
        {
            var lesserOrEqual = FindLesserOrEqual(number);

            if (lesserOrEqual == null)
            {
                linkedList.AddFirst(number);
            }
            else
            {
                linkedList.AddAfter(lesserOrEqual, number);
            }
        }

        private LinkedListNode<int> FindLesserOrEqual(int number)
        {
            var current = linkedList.Last;

            while (current != null)
            {
                if (current.Value <= number)
                {
                    break;
                }
                else
                {
                    current = current.Previous;
                }
            }

            return current;
        }
    }
}