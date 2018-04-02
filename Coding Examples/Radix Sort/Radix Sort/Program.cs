using System;

namespace Radix_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //for sorting negative numbers, the array need to be split into positive and negative, each one get sorted as positive, negative one reverse sorted and then 2 need to be merged
            int[] arr = new int[] { 1, 5, 4, 11, 20, 90, 3, 6, 7, 88, 8, 88, 12, 2, 98, 90, 4 };
            Console.WriteLine(string.Join(" , ", arr));
            arr = RadixSort(arr);
            Console.WriteLine(string.Join(" , ", arr));
            Console.ReadLine();
        }

        public static int[] RadixSort(int[] arr)
        {
            int i, max = arr[0];
            int exp = 1;
            int n = arr.Length;
            int[] helperArr = new int[n];
            for (i = 1; i < n; i++)
                if (arr[i] > max)
                    max = arr[i];
            while (max / exp > 0)
            {
                int[] bucket = new int[10];

                for (i = 0; i < n; i++)
                    bucket[(arr[i] / exp) % 10]++;
                for (i = 1; i < bucket.Length; i++)
                    bucket[i] += bucket[i - 1];
                for (i = n - 1; i >= 0; i--)
                    helperArr[--bucket[(arr[i] / exp) % 10]] = arr[i];
                for (i = 0; i < n; i++)
                    arr[i] = helperArr[i];
                exp *= 10;
            }
            return arr;
        }

    }
}
