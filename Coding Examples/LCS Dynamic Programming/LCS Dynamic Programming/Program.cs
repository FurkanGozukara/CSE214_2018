using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCS_Dynamic_Programming
{
    class Program
    {
        static int RecursiveCount = 0;
        static int DynamicCount = 0;

        static void Main(string[] args)
        {
            String s1 = "CGATAATTGAGA";
            String s2 = "GTTCCTAAT";

            //s1 = "ABCDCBA";
            //s2 = "DCBAABC";

             //s1 = "AG";
             //s2 = "GX";

            char[] X = s1.ToCharArray();
            char[] Y = s2.ToCharArray();
            int m = X.Length;
            int n = Y.Length;

            Console.Write("Length of Dynamic LCS is" + " "
                          + LCS_Dynamic(X, Y, m, n)+" operation count: "+ DynamicCount+"\r\n");
            Console.Write("Length of Recursive LCS is" + " "
                   + LCS_Recursive(X, Y, m, n) + " operation count: " + RecursiveCount + "\r\n");
            Console.ReadLine();
        }

        static int LCS_Dynamic(char[] X, char[] Y, int m, int n)
        {
            int[,] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1] 
            in bottom up fashion. Note
            that L[i][j] contains length of 
            LCS of X[0..i-1] and Y[0..j-1] */
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    DynamicCount++;
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = max(L[i - 1, j], L[i, j - 1]);
                }
            }


            // Following code is used to print LCS
            int index = L[m, n];
            int temp = index;

            // Create a character array 
            // to store the lcs string
            char[] lcs = new char[index + 1];

            // Set the terminating character
            lcs[index] = '\0';

            // Start from the right-most-bottom-most corner
            // and one by one store characters in lcs[]
            int k = m, l = n;
            while (k > 0 && l > 0)
            {
                // If current character in X[] and Y 
                // are same, then current character 
                // is part of LCS
                if (X[k - 1] == Y[l - 1])
                {
                    // Put current character in result
                    lcs[index - 1] = X[k - 1];

                    // reduce values of i, j and index
                    k--;
                    l--;
                    index--;
                }

                // If not same, then find the larger of two and
                // go in the direction of larger value
                else if (L[k - 1, l] > L[k, l - 1])
                    k--;
                else
                    l--;
            }

            // Print the lcs
            Console.Write("LCS of " + string.Concat(X) + " and " + string.Concat(Y) + " is ");
            for (int q = 0; q <= temp; q++)
                Console.Write(lcs[q]);

            Console.WriteLine();

            return L[m, n];
        }

  

        /* Returns length of LCS for X[0..m-1], Y[0..n-1] */
        static int LCS_Recursive(char[] X, char[] Y, int m, int n)
        {
            RecursiveCount++;
            if (m == 0 || n == 0)
                return 0;
            if (X[m - 1] == Y[n - 1])
                return 1 + LCS_Recursive(X, Y, m - 1, n - 1);
            else
                return max(LCS_Recursive(X, Y, m, n - 1), LCS_Recursive(X, Y, m - 1, n));
        }

        /* Utility function to get max of 2 integers */
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }


    }
}
