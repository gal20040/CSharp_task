using System;

namespace CountingSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var unsortedArray = GetArray(16);
        }

        private static int[] GetArray(int count)
        {
            if (count <= 0) throw new Exception($"{nameof(count)} must ne greater than 0.");

            var resArray = new int[count];

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                resArray[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return resArray;
        }
    }
}