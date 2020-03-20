using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class CountingSort
    {
        public int[] Sort(int[] array)
        {
            var possibleValues = GetPossibleValues(array);

            return Sort(possibleValues, array);
        }

        /// <summary>
        /// Преобразует входной массив в коллекцию пар<число, zeroValue>, где ключи-числа не повторяются, а zeroValue = 0.
        /// </summary>
        /// <param name="array">Входной массив чисел (числа могут повторяться).</param>
        /// <returns></returns>
        public Dictionary<int, int> GetPossibleValues(int[] array)
        {
            var possibleValuesSet = new SortedSet<int>();

            foreach (var item in array)
            {
                //получить упорядоченный список уникальных значений
                //если такое значение уже есть, то ничего не добавляется
                possibleValuesSet.Add(item);
            }

            var possibleValues = new Dictionary<int, int>();
            const int zeroValue = 0; //начальное значение кол-ва чисел в словаре

            foreach (var item in possibleValuesSet)
            {
                possibleValues.Add(item, zeroValue);
            }

            return possibleValues;
        }

        public int[] Sort(Dictionary<int, int> possibleValues, int[] array)
        {
            if (array.Length == 0) return new int[] { };

            ResetValuesToZero(possibleValues);

            foreach (var number in array)
            {
                if (!possibleValues.ContainsKey(number))
                {
                    throw new Exception($"{nameof(possibleValues)} не содержит число из {nameof(array)}: {number}");
                }

                possibleValues[number]++;
            }

            return RepopulateArray(possibleValues, array);
        }

        public void ResetValuesToZero(Dictionary<int, int> possibleValues)
        {
            foreach (var key in possibleValues.Keys.ToList())
            {
                possibleValues[key] = 0;
            }
        }

        public int[] RepopulateArray(Dictionary<int, int> possibleValues, int[] array)
        {
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

            return array;
        }

        public int[] Sort(int[] possibleValues, int[] array)
        {
            var possibleValuesDictionary = GetPossibleValues(possibleValues);
            return Sort(possibleValuesDictionary, array);
        }
    }
}