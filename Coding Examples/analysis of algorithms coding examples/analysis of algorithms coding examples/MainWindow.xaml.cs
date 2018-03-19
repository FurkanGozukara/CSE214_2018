using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ders_1_insertion_sort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsertSort_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => {
                insertSort();
            });
        }

        private void insertSort()
        {
            List<int> lstToBeSorted = new List<int> { 32, 11, 2, 4, 123, 55, 11, 44, 25, 25, 77 };

            //Random rr = new Random();
            //for (int i = 0; i < 100000; i++)
            //{
            //    lstToBeSorted.Add(rr.Next());
            //}

            for (int j = 1; j < lstToBeSorted.Count; j++)
            {
                printList($"index j: {j} , index value: {lstToBeSorted[j]}");
                printList($"step: {j - 1} start: ", lstToBeSorted);
                var Key = lstToBeSorted[j];
                var i = j - 1;

                while (i >= 0 && lstToBeSorted[i] > Key)
                {
                    Debug.WriteLine($"{ lstToBeSorted[i]} is shifted with {   lstToBeSorted[i + 1]}");
                    lstToBeSorted[i + 1] = lstToBeSorted[i];
                    i--;
                }

                lstToBeSorted[i + 1] = Key;
                printList($"step: {j - 1} end : ", lstToBeSorted);

                printLabel($"sorting index: {j} / {lstToBeSorted.Count}");
            }
        }

        private void printLabel(string srMsg)
        {
            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                lblMessage.Content = srMsg;
            }));
        }

        private void printList(string message = "", List<int> lstToBePrinted = null)
        {
            List<int> lstTempList = null;

            if(lstToBePrinted!=null)
             lstTempList = new List<int>(lstToBePrinted);
            if (lstTempList != null)
            {
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    string srJoined = string.Join(", ", lstTempList);
                    if (srJoined.Length < 1)
                        srJoined = lstTempList?.FirstOrDefault().ToString();
                    lstView.Items.Add(message + srJoined);
                }));
            }

            else
            {
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    lstView.Items.Add(message);
                }));
            }
        }

        private void btnMergeSort_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => {
                mergeSort();
            });
        }

        private void mergeSort()
        {
            List<int> unsorted = new List<int>();
            List<int> sorted;
        
            unsorted= new List<int> { 32, 11, 2, 4, 123, 55, 11, 44, 25, 25, 77 };

            //Random rr = new Random();
            //for (int i = 0; i < 1000; i++)
            //{
            //    unsorted.Add(rr.Next());
            //}

            irMainListCount = unsorted.Count;

            sorted = MergeSort(unsorted);

            Debug.WriteLine("Sorted array elements: ");
            foreach (int x in sorted)
            {
                Debug.Write(x + " ");
            }
            Debug.Write("\n");
        }

        int irMainListCount = 0;
        int irMergeSortCalls = 0;

        private List<int> MergeSort(List<int> unsorted)
        {
            irMergeSortCalls++;

            printLabel($"Merge Call + Merge Sort : {irMergeSortCalls+irMergeCall} , approximate max call number : {irMainListCount * Math.Log(irMainListCount, 2)}");

            if (unsorted.Count> 0)
                printList($"MergeSort call: {irMergeSortCalls}  List: ",unsorted);

            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }


        int irMergeCall = 0;
        private  List<int> Merge(List<int> left, List<int> right)
        {
            irMergeCall++;

            printList($"Merge Call : {irMergeCall} , Left: ", left);
            printList($"Merge Call : {irMergeCall} , Right: ", right);

            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
