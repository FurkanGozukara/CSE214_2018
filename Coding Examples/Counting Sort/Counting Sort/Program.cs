using System;

namespace Counting_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 5, 4, 11, 20, 90, -8, 2, 98, 90, -16 };

            int[] sortedArray = CountingSort(arr);
            Console.WriteLine("Sorted Values:");
            for (int i = 0; i < sortedArray.Length; i++)
                Console.WriteLine(sortedArray[i]);

            Console.ReadLine();
        }

        static int[] CountingSort(int[] array)
        {
            Console.Write("array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            Console.WriteLine("min val: {0}, max val: {1}", minVal, maxVal);

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            Console.WriteLine("array of frequences lenght: {0}", counts.Length);
            Console.WriteLine();
            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }
            Console.Write("inited counts array:        ");
            foreach (var item in counts)
            {
                Console.Write(item + " , ");
            }
            Console.WriteLine();

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }
            Console.WriteLine();
            Console.Write("re-calculated counts array: ");
            foreach (var item in counts)
            {
                Console.Write(item + " , ");
            }
            Console.WriteLine();

            Console.WriteLine("minVal = " + minVal);
            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {

                Console.WriteLine("i = " + i);
                Console.WriteLine("array[i] = " + array[i]);
                Console.WriteLine("array[i] - minVal = " + (array[i] - minVal));
                Console.WriteLine("counts[array[i] - minVal] = " + counts[array[i] - minVal]);
                Console.WriteLine($"sortedArray[{counts[array[i] - minVal]}]={array[i]}");
                sortedArray[counts[array[i] - minVal]--] = array[i];

            }

            return sortedArray;
        }
    }
}
