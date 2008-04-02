using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using DocClass.Src.Learning.MathOperations;
using MatrixBuild = dnAnalytics.LinearAlgebra.MatrixBuilder;
using MatrixDN =  dnAnalytics.LinearAlgebra.Matrix;

namespace DocClass.Src.Tests
{
    [TestFixture]
    public class SVDTest
    {
        [Test]
        public static void Test()
        {
            double[,] a, u = null, vt = null;
            double[] w = null;
            a = new double[5, 6];
            a[1, 1] = 1; a[1, 5] = 2; a[2, 3] = 3; a[4, 2] = 4;
            Console.WriteLine(Matrix.ToString(a, true, true));
            if (SVD.Decomposition(a, ref w, ref u, ref vt))
            {
                Console.WriteLine(Vector.ToString(w, true));
                Console.WriteLine(Matrix.ToString(u, true, true));
                Console.WriteLine(Matrix.ToString(vt, true, true));
            }

            MatrixDN matrixW = CreateMatrix(w, a.GetLength(0), a.GetLength(1));
            Console.WriteLine("Macierz W");
            Console.WriteLine(matrixW.ToString());
            Console.WriteLine();
            MatrixDN matrixU = CreateMatrix(u);
            Console.WriteLine("Macierz U");
            Console.WriteLine(matrixU.ToString());
            Console.WriteLine();
            MatrixDN matrixVT = CreateMatrix(vt);
            Console.WriteLine("Macierz VT");
            Console.WriteLine(matrixVT.ToString());
            Console.WriteLine();
            matrixU = matrixU.Transpose();
            Console.WriteLine("Macierz U - transponowana");
            Console.WriteLine(matrixU.ToString());
            Console.WriteLine();
            matrixVT = matrixVT.Transpose();
            Console.WriteLine("Macierz VT - transponowana(V)");
            Console.WriteLine(matrixVT.ToString());
            Console.WriteLine();
            matrixW = Reciprocal(matrixW);
            Console.WriteLine("Macierz W - transponowana kazdy element odwrocny");
            Console.WriteLine(matrixW.ToString());
            Console.WriteLine();
            MatrixDN mPlus = (matrixVT * matrixW) * matrixU;
            Console.WriteLine("Macierz M PLUS");
            Console.WriteLine(mPlus.ToString());
            Console.WriteLine();

            Console.WriteLine(Matrix.ToString(Pseudoinverse.Solve(a)));

        }

        [Test]
        private static void SVDtest()
        {
            double[,] a = StartMatrix();
            double[,] svdA = Pseudoinverse.Solve(a);
            Console.WriteLine("Macierz wynikowa.");
            Console.WriteLine(Matrix.ToString(svdA));
            svdA = Pseudoinverse.Solve(svdA);
            Console.WriteLine("Macierz po kolejnej operacji SVD wynikowa.");
            Console.WriteLine(Matrix.ToString(svdA));
        }

        private static double[,] StartMatrix()
        {
            int m = 4, n = 5, i, j;
            double[,] a = new double[m + 1, n + 1];
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    a[i, j] = 0;// i + j;
                }
            }
            a[1, 1] = 1; a[1, 5] = 2;
            a[2, 3] = 3;
            a[4, 2] = 4;
            Console.WriteLine("Macierz poddana rozkladowi SVD");
            Console.WriteLine(Matrix.ToString(a));
            return a;
        }

        public static void TestPseudoInverse()
        {
            double[,] a = new double[5, 6];
            a[1, 1] = 1; a[1, 5] = 2; a[2, 3] = 3; a[4, 2] = 4;
            Console.WriteLine(Matrix.ToString(a, true, true));
            double[,] mplus = Pseudoinverse.Solve(a);
            Console.WriteLine();
            Console.WriteLine("Macierz M PLUS");
            Console.WriteLine(Matrix.ToString(mplus));
            Console.WriteLine();

            double[,] newMPLUS = new double[mplus.GetLength(0) + 1, mplus.GetLength(1) + 1];
            for (int i = 1; i < mplus.GetLength(1); i++)
                for (int j = 1; j < mplus.GetLength(0); j++)
                    newMPLUS[i, j] = mplus[i - 1, j - 1];
            Console.WriteLine("Macierz do wyliczenia");
            Console.WriteLine(Matrix.ToString(newMPLUS));
            Console.WriteLine();

            mplus = Pseudoinverse.Solve(newMPLUS);
            Console.WriteLine();
            Console.WriteLine("Macierz (M PLUS)MPLUS");
            Console.WriteLine(Matrix.ToString(mplus));
            Console.WriteLine();

        }

        private static MatrixDN CreateMatrix(double[] diagonal, int lenght0, int lenhgt1)
        {
            MatrixDN matrixW = MatrixBuild.CreateMatrix(lenght0 - 1, lenhgt1 - 1);
            for (int i = 1; i < lenght0; i++)
                for (int j = 1; j < lenhgt1; j++)
                {
                    if (i == j && i < diagonal.Length)
                        matrixW[i - 1, j - 1] = diagonal[i];
                    else
                        matrixW[i - 1, j - 1] = 0;
                }
            return matrixW;
        }

        private static MatrixDN CreateMatrix(double[,] m)
        {
            MatrixDN matrixW = MatrixBuild.CreateMatrix(m.GetLength(0) - 1, m.GetLength(1) - 1);
            for (int i = 1; i < m.GetLength(0); i++)
                for (int j = 1; j < m.GetLength(1); j++)
                {
                    matrixW[i - 1, j - 1] = m[i, j];
                }
            return matrixW;
        }

        private static MatrixDN Reciprocal(MatrixDN matrix)
        {
            matrix = matrix.Transpose();
            for (int j = 0; j < matrix.Columns; j++)
                for (int i = 0; i < matrix.Rows; i++)
                {
                    if (matrix[i, j] != 0)
                        matrix[i, j] = 1 / matrix[i, j];
                }
            return matrix;
        }
    }
}
