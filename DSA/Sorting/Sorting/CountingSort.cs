using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class CountingSort
    {
        /// <summary>Начальное значение кол-ва чисел в словаре</summary>
        private const int zeroValue = 0;

        public void Sort(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var possibleValues = GetPossibleValues(array);

            Sort(possibleValues, array);
        }

        /// <summary>
        /// Преобразует входной массив в коллекцию пар<число, zeroValue>, где ключи-числа не повторяются, а zeroValue = 0.
        /// </summary>
        /// <param name="array">Входной массив чисел (числа могут повторяться).</param>
        /// <returns></returns>
        public Dictionary<int, int> GetPossibleValues(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var possibleValuesSet = new SortedSet<int>(); //todo переделать на свой SortedSet

            foreach (var item in array)
            {
                //составить упорядоченный список уникальных значений
                //если такое значение уже есть, то ничего не добавляется
                possibleValuesSet.Add(item);
            }

            var possibleValues = new Dictionary<int, int>();

            foreach (var item in possibleValuesSet)
            {
                possibleValues.Add(item, zeroValue);
            }

            return possibleValues;
        }

        public void Sort(Dictionary<int, int> possibleValues, int[] array)
        {
            if (possibleValues == null) throw new ArgumentNullException(nameof(possibleValues));
            if (array == null) throw new ArgumentNullException(nameof(array));

            if (array.Length == 0) return;

            ResetValuesToZero(possibleValues);

            foreach (var number in array)
            {
                if (!possibleValues.ContainsKey(number))
                {
                    throw new Exception($"{nameof(possibleValues)} не содержит число из {nameof(array)}: {number}");
                }

                possibleValues[number]++;
            }

            RepopulateArray(possibleValues, array);
        }

        public void ResetValuesToZero(Dictionary<int, int> possibleValues)
        {
            if (possibleValues == null) throw new ArgumentNullException(nameof(possibleValues));

            foreach (var key in possibleValues.Keys.ToList())
            {
                possibleValues[key] = zeroValue;
            }
        }

        public void RepopulateArray(Dictionary<int, int> possibleValues, int[] array)
        {
            if (possibleValues == null) throw new ArgumentNullException(nameof(possibleValues));
            if (array == null) throw new ArgumentNullException(nameof(array));

            var i = 0;
            int number, counter;

            foreach (var item in possibleValues)
            {
                number = item.Key;
                counter = item.Value;
                while (counter > 0)
                {
                    array[i] = number;
                    counter--;
                    i++;
                }
            }
        }
    }
}