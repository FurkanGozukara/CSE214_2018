using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Generate_All_Matrix_Combinations
{
    class Program
    {
        static Dictionary<string, List<string>> AllCombinations = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            List<string> seed = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6" };

            for (int i = 2; i < seed.Count; i++)
            {
                StringBuilder tempBuilder = new StringBuilder();

                for (int k = 0; k < seed.Count; k++)
                {
                    if ((k + i) <= seed.Count)
                    {
                        for (int c = 0; c < i; c++)
                        {

                        }
                    }
                    else
                    {
                      
                    }
                }
            }


            var subLists = returnChances(0, 5, 3, seed);
        }

        static List<List<string>> returnChances(int begin, int end, int length, List<string> source)
        {
            List<List<string>> returnList = new List<List<string>>();
            for (int i = begin; i <= end; i++)
            {
                List<string> tempList = new List<string>();
                if (i + length > (end + 1))
                {
                    returnList.AddRange(returnChances(i, end, (end - i) + 1, source));
                }
                else
                {

                    for (int k = 0; k < length; k++)
                    {
                        tempList.Add(source[i + k]);
                    }
                }
                returnList.Add(tempList);
            }
            return returnList;
        }
    }
}
