using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optimal_Matrix_Chain_Multiplication
{
    class Program
    {
        static double[,] MatricesCosts;

        static int RegularCounter = 0;
        static int DynamicCounter = 0;

        static void Main(string[] args)
        {

            List<Tuple<int, int>> matricesLenghts = new List<Tuple<int, int>>();
            matricesLenghts.Add(new Tuple<int, int>(30, 35));
            matricesLenghts.Add(new Tuple<int, int>(35, 15));
            matricesLenghts.Add(new Tuple<int, int>(15, 5));
            matricesLenghts.Add(new Tuple<int, int>(5, 10));
            matricesLenghts.Add(new Tuple<int, int>(10, 20));
            matricesLenghts.Add(new Tuple<int, int>(20, 25));
            matricesLenghts.Add(new Tuple<int, int>(25, 15));
            matricesLenghts.Add(new Tuple<int, int>(15, 45));
            matricesLenghts.Add(new Tuple<int, int>(45, 65));
            matricesLenghts.Add(new Tuple<int, int>(65, 20));

            //matricesLenghts.Add(new Tuple<int, int>(5, 4));
            //matricesLenghts.Add(new Tuple<int, int>(4, 6));
            //matricesLenghts.Add(new Tuple<int, int>(6, 2));
            //matricesLenghts.Add(new Tuple<int, int>(2, 7));

            MatricesCosts = new double[matricesLenghts.Count, matricesLenghts.Count];

            for (int i = 0; i < matricesLenghts.Count; i++)
            {
                for (int k = 0; k < matricesLenghts.Count; k++)
                {
                    MatricesCosts[i, k] = double.MaxValue;
                }
            }

            double[] MatricesP = new double[matricesLenghts.Count + 1];
            MatricesP[0] = matricesLenghts[0].Item1;
            MatricesP[1] = matricesLenghts[0].Item2;
            for (int i = 1; i < matricesLenghts.Count; i++)
            {
                MatricesP[i + 1] = matricesLenghts[i].Item2;
            }

            double minCost = MatrixChainOrder(MatricesP,1, matricesLenghts.Count  );

            double minCostDynamic = MatrixChainOrderDynamic(MatricesP, MatricesP.Length);

            Console.WriteLine("dynamic counter: " + DynamicCounter);
            Console.WriteLine("recursif counter: " + RegularCounter);

            Console.ReadLine();
        }

        static double MatrixChainOrderDynamic(double[] p, int n)
        {

            /* For simplicity of the program, one 
            extra row and one extra column are 
            allocated in m[][]. 0th row and 0th
            column of m[][] are not used */
            double[,] m = new double[n, n];

            int i, j, k, L;
            double q;

            /* m[i,j] = Minimum number of scalar 
            multiplications needed
            to compute the matrix A[i]A[i+1]...A[j]
            = A[i..j] where dimension of A[i] is 
            p[i-1] x p[i] */

            // cost is zero when multiplying 
            // one matrix.
            for (i = 1; i < n; i++)
                m[i, i] = 0;

            // L is chain length.
            for (L = 2; L < n; L++)
            {
                for (i = 1; i < n - L + 1; i++)
                {
                    j = i + L - 1;
                    if (j == n) continue;
                    m[i, j] = int.MaxValue;
                    for (k = i; k <= j - 1; k++)
                    {
                        DynamicCounter++;
                        // q = cost/scalar multiplications
                        q = m[i, k] + m[k + 1, j] +
                                         p[i - 1] * p[k] * p[j];
                        if (q < m[i, j])
                            m[i, j] = q;
                    }
                }
            }

            return m[1, n - 1];
        }

        static double MatrixChainOrder(double[] MatricesP,int i, int j)
        {

            if (i == j)
                return 0;

            double min = double.MaxValue;

            // place parenthesis at different places 
            // between first and last matrix, recursively 
            // calculate count of multiplications for each
            // parenthesis placement and return the 
            // minimum count
            for (int k = i; k < j; k++)
            {
                RegularCounter++;
                double count = MatrixChainOrder(MatricesP, i, k) +
                MatrixChainOrder(MatricesP, k + 1, j) + MatricesP[i - 1]
                                           * MatricesP[k] * MatricesP[j];

                if (count < min)
                    min = count;
            }

            // Return minimum count
            return min;
        }
    }
}



