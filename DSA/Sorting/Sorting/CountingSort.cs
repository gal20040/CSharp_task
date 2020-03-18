﻿using System;
using System.Collections.Generic;

namespace Sorting
{
    public class CountingSort
    {
        public int[] Sort(int[] array)
        {
            throw new NotImplementedException();
        }

        public int[] Sort(Dictionary<int, int> possibleValues, int[] array)
        {
            if (array.Length == 0) return array;

            foreach (var number in array)
            {
                if (!possibleValues.ContainsKey(number))
                {
                    throw new Exception($"{nameof(possibleValues)} не содержит число из {nameof(array)}: {number}");
                }

                possibleValues[number]++;
            }

            var i = 0;
            int counter;
            int value;
            foreach (var number in possibleValues)
            {
                value = number.Key;
                counter = number.Value;
                while (counter > 0)
                {
                    array[i] = value;
                    counter--;
                    i++;
                }
            }

            return array;
        }

        public int[] Sort(int[] possibleValues, int[] array)
        {
            var numbers = PrepareNumbers(possibleValues);
            return Sort(numbers, array);
        }

        public Dictionary<int, int> PrepareNumbers(int[] possibleValues)
        {
            const int initialCount = 0;

            var numbers = new Dictionary<int, int>();

            if (possibleValues.Length == 0) return numbers;

            var minNumber = possibleValues[0];
            numbers.Add(possibleValues[0], initialCount);

            for (int i = 1; i < possibleValues.Length; i++)
            {
                var number = possibleValues[i];
                if (number <= minNumber)
                {
                    throw new Exception($"Массив {nameof(possibleValues)} должен содержать сортированные по возврастанию уникальные значения.");
                }

                numbers.Add(number, 0);
            }

            return numbers;
        }
    }
}