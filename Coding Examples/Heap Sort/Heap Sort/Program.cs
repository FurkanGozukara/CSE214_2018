using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Heap_Sort
{
    class Program
    {
        static int bigArraySize = 100000;

        static void Main(string[] args)
        {
            int[] arr = { 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            // int[] arr = { 16, 4, 10, 14, 7, 9, 3, 2, -2, 3, 5, -1, 5, 6, 6, 3, -2, 8, 1 };

            int[] bigArr = new int[bigArraySize];
            int[] bigArr2 = new int[bigArraySize];
            int[] bigArr3 = new int[bigArraySize];
            Random myRand = new Random();
            for (int i = 0; i < bigArraySize - 1; i++)
            {
                bigArr[i] = myRand.Next();
            }

            Array.Copy(bigArr, bigArr2, bigArr.Length);
            Array.Copy(bigArr, bigArr3, bigArr.Length);

            File.WriteAllLines("bigArr unsorted.txt", bigArr.Select(pr => pr.ToString()));
            File.WriteAllLines("bigArr2 unsorted.txt", bigArr2.Select(pr => pr.ToString()));
            File.WriteAllLines("bigArr3 unsorted.txt", bigArr3.Select(pr => pr.ToString()));

            Stopwatch stopwatch = new Stopwatch();

            HeapSort hs = new HeapSort();

            stopwatch.Start();
            hs.PerformHeapSort(bigArr);
            stopwatch.Stop();

            Console.WriteLine("heapsort first sort " + stopwatch.ElapsedMilliseconds + " ms ");
            File.WriteAllLines("heapsort bigArr sorted 1.txt", bigArr.Select(pr => pr.ToString()));

            int irRand = myRand.Next();

            bigArr[bigArraySize - 1] = irRand;

            stopwatch.Reset();

            stopwatch.Start();
            hs.PerformHeapSort(bigArr);
            stopwatch.Stop();

            Console.WriteLine("heapsort final sort " + stopwatch.ElapsedMilliseconds + " ms ");
            File.WriteAllLines("heapsort bigArr sorted 2.txt", bigArr.Select(pr => pr.ToString()));

            stopwatch.Reset();

            stopwatch.Start();
            insertionSort(bigArr2);
            stopwatch.Stop();

            Console.WriteLine("insertion sort first sort "+ stopwatch.ElapsedMilliseconds + " ms ");

            File.WriteAllLines("insertion first sort.txt", bigArr2.Select(pr => pr.ToString()));

            bigArr2[bigArraySize - 1] = irRand;

            stopwatch.Reset();

            stopwatch.Start();
            insertionSort(bigArr2);
            stopwatch.Stop();

            Console.WriteLine("insertion final sort " + stopwatch.ElapsedMilliseconds + " ms ");
            File.WriteAllLines("final insertion sort.txt", bigArr2.Select(pr => pr.ToString()));

            stopwatch.Reset();

            SortedSet<int> sortedSet = new SortedSet<int>();
            stopwatch.Start();     
            foreach (var item in bigArr3)
            {
                sortedSet.Add(item);
            }
            stopwatch.Stop();

            Console.WriteLine("sorted list first sort " + stopwatch.ElapsedMilliseconds + " ms ");
            File.WriteAllLines("sorted list first.txt", sortedSet.Select(pr => pr.ToString()));

            stopwatch.Reset();

            stopwatch.Start();
            sortedSet.Add(irRand);
            stopwatch.Stop();

            Console.WriteLine("sorted list add 1 item " + stopwatch.ElapsedMilliseconds + " ms ");
            File.WriteAllLines("sorted_list_2.txt", sortedSet.Select(pr => pr.ToString()));

            hs.MaxHeapify(arr, 1);
            hs.DisplayArray(arr);
            hs.PerformHeapSort(arr);
            Console.ReadLine();
        }

        static void insertionSort(int[] lstToBeSorted)
        {
            for (int j = 1; j < lstToBeSorted.Length; j++)
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

        class HeapSort
        {
            private int heapSize;

            public void initHeapSize(int lenght)
            {
                heapSize = lenght - 1;
            }

            private void BuildMaxHeap(int[] arr)
            {
                initHeapSize(arr.Length);
                for (int i = heapSize / 2; i >= 0; i--)
                {
                    MaxHeapify(arr, i);
                }
            }

            private void Swap(int[] arr, int x, int y)//function to swap elements
            {
                int temp = arr[x];
                arr[x] = arr[y];
                arr[y] = temp;
            }
            public void MaxHeapify(int[] arr, int index)
            {
                int left = 2 * index;
                int right = 2 * index + 1;
                int largest = index;

                if (left <= heapSize && arr[left] > arr[index])
                {
                    largest = left;
                }

                if (right <= heapSize && arr[right] > arr[largest])
                {
                    largest = right;
                }

                if (largest != index)
                {
                    Swap(arr, index, largest);
                    MaxHeapify(arr, largest);
                }
            }
            public void PerformHeapSort(int[] arr, bool dontHeapAgain = false)
            {
                if (dontHeapAgain == false)
                    BuildMaxHeap(arr);
                else
                    initHeapSize(arr.Length);
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    Swap(arr, 0, i);
                    heapSize--;
                    MaxHeapify(arr, 0);
                }
                DisplayArray(arr);
            }

            public void DisplayArray(int[] arr)
            {
                return;
                for (int i = 0; i < arr.Length; i++)
                { Console.Write("[{0}]", arr[i]); }
                Console.WriteLine();
            }
        }
    }
}
