using System;
using System.Collections.Generic;

namespace Bucket_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstToBeSorted = new List<int> { 32, 11, 2, 4, 123, 55,57,66,61,60,69, 11, 44, 25, 25, 77 };
            Console.WriteLine(string.Join(" , ", lstToBeSorted));
            lstToBeSorted = BucketSort(lstToBeSorted.ToArray());
            Console.WriteLine(string.Join(" , ", lstToBeSorted));
            Console.ReadLine();
        }

        static List<int> BucketSort(params int[] arr)
        {
            List<int> result = new List<int>();

            //bucket size
            int bucketSize = 10;

            int max = arr[0];
            foreach (var item in arr)
            {
                if (item > max)
                    max = item;
            }

            //Create buckets
            List<int>[] buckets = new List<int>[(max / bucketSize) + 1];
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new List<int>();

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < arr.Length; i++)
            {
                int buckitChoice = (arr[i] / bucketSize);
                buckets[buckitChoice].Add(arr[i]);
            }

            //Sort each bucket and add it to the result List
            //Each sublist is sorted using Bubblesort, but you could substitute any sorting algo you would like
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.WriteLine("bucket " + i + " pre sort: " + string.Join(" , ", buckets[i]));
                InsertionSort(buckets[i]);
                result.AddRange(buckets[i]);
                Console.WriteLine("bucket " + i + " post sort: " + string.Join(" , ", buckets[i]));
            }
            return result;
        }

        static void InsertionSort(List<int> lstToBeSorted)
        {
            for (int j = 1; j < lstToBeSorted.Count; j++)
            {
                var Key = lstToBeSorted[j];
                var i = j - 1;

                while (i >= 0 && lstToBeSorted[i] > Key)
                {
                    lstToBeSorted[i + 1] = lstToBeSorted[i];
                    i--;
                }

                lstToBeSorted[i + 1] = Key;
            }
        }
    }
}
