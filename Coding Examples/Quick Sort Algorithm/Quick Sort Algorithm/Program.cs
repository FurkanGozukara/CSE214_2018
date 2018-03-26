using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quick_Sort_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an unsorted array of string elements

            int[] unsortedInt = { 110,40, 20, 10,10, 80, 60, 50, 7, 30, 100 };

            IComparable[] transformedList = unsortedInt.Cast<IComparable>().ToArray();

            int[] unsortedInt2 = { -1, 40, 20, 10, 10, 80, 60, 50, 7, 30, 100 };

            IComparable[] transformedList2 = unsortedInt2.Cast<IComparable>().ToArray();

            Quicksort(transformedList2, 0, transformedList2.Length - 1);

            //QuicksortWithMedian(transformedList, 0, unsortedInt.Length - 1);

            string[] unsorted = { "z", "e", "e", "x", "c", "m", "q", "a" };

            // Print the unsorted array
            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }

            Console.WriteLine();

            // Sort the array
            Quicksort(unsorted, 0, unsorted.Length - 1);

            // Print the sorted array
            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            Console.WriteLine("Quick Sort Call...");
            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
            int too_Big_Index = left + 1, too_Small_Index = right;

            int pivotIndex = left;

            IComparable pivot = elements[pivotIndex];

            while (too_Small_Index >= too_Big_Index)
            {
                while (elements[too_Big_Index].CompareTo(pivot) <= 0)
                {
                    too_Big_Index++;

                    //print debug
                    int irCounter = 0;
                    foreach (var item in elements)
                    {
                        if (irCounter == pivotIndex)
                        {
                            Console.Write("pivot(" + item + ")" + " ");
                        }
                        else
                        if (irCounter == too_Big_Index)
                        {
                            Console.Write("TBI(" + item + ")" + " ");
                        }
                        else
                            Console.Write(item + " ");
                        irCounter++;
                    }
                    Console.WriteLine();
                    //print debug

              

                    if (too_Big_Index >= right)
                    {
                        break;
                    }
                }

                while (elements[too_Small_Index].CompareTo(pivot) > 0)
                {
                    too_Small_Index--;
                    //print debug
                    int irCounter = 0;
                    foreach (var item in elements)
                    {
                        if (irCounter == pivotIndex)
                        {
                            Console.Write("pivot(" + item + ")" + " ");
                        }
                        else
                        if (irCounter == too_Small_Index)
                        {
                            Console.Write("TSI(" + item + ")" + " ");
                        }
                        else
                            Console.Write(item + " ");


                        irCounter++;
                    }
                    Console.WriteLine();
                    //print debug
                 
                }

                if (too_Big_Index < too_Small_Index)
                {
                    // Swap
                    Console.WriteLine($"swap too_big_index({elements[too_Big_Index]}) with too_small_index({elements[too_Small_Index]})");

                    swap(elements, too_Small_Index, too_Big_Index);

                    foreach (var item in elements)
                    {
                        Console.Write(item + " ");
                    }
                    Console.Write("\n");
                }
            }

            swap(elements, too_Small_Index, pivotIndex);

            // Recursive calls
            if (too_Small_Index < right)
            {
                Quicksort(elements, too_Small_Index+1, right);
            }

            if (too_Small_Index-1 > left)
            {
                Quicksort(elements, left, too_Small_Index - 1);
            }
        }


        public static void manualSort(IComparable[] elements, int left, int right)
        {
            int size = right - left + 1;
            if (size <= 1)
                return;
            if (size == 2)
            {
                if (elements[left].CompareTo(elements[right]) > 0)
                    swap(elements, left, right);
                return;
            }
            else
            {
                if (elements[left].CompareTo(elements[right - 1]) > 0)
                    swap(elements, left, right - 1);
                if (elements[left].CompareTo(elements[right]) > 0)
                    swap(elements, left, right);
                if (elements[right - 1].CompareTo(elements[right]) > 0)
                    swap(elements, right - 1, right);
            }
        }

        public static void QuicksortWithMedian(IComparable[] elements, int left, int right)
        {
            int size = right - left + 1;
            if (size <= 3)
                manualSort(elements, left, right);
            else
            {
                IComparable median = medianOf3(elements, left, right);
                int partition = partitionIt(elements, left, right, median);
                QuicksortWithMedian(elements, left, partition - 1);
                QuicksortWithMedian(elements, partition + 1, right);
            }
        }

        public static IComparable medianOf3(IComparable[] elements, int left, int right)
        {
            int center = (left + right) / 2;

            if (elements[left].CompareTo(elements[center]) > 0)
            {
                swap(elements, left, center);
            }
            if (elements[left].CompareTo(elements[right]) > 0)
            {
                swap(elements, left, right);
            }
            if (elements[center].CompareTo(elements[right]) > 0)
            {
                swap(elements, center, right);
            }
            swap(elements, center, right - 1);

            return elements[right - 1];
        }

        public static void swap(IComparable[] array, int dex1, int dex2)
        {
            IComparable temp = array[dex1];
            array[dex1] = array[dex2];
            array[dex2] = temp;
        }

        public static int partitionIt(IComparable[] elements, int left, int right, IComparable pivot)
        {
            int leftPtr = left;
            int rightPtr = right - 1;

            while (true)
            {
                while (elements[++leftPtr].CompareTo(pivot) < 0)
                    ;
                while (elements[--rightPtr].CompareTo(pivot) > 0)
                    ;
                if (leftPtr >= rightPtr)
                    break;
                else
                    swap(elements, leftPtr, rightPtr);
            }
            swap(elements, leftPtr, right - 1);
            return leftPtr;
        }
    }
}
