using System;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Decomposition;

namespace DocClass.Src.Learning.MathOperations
{
    public static class SVD
    {
        #region Public Methods

        /*************************************************************************
        Singular value decomposition of a rectangular matrix.

        The algorithm calculates the singular value decomposition of a matrix of
        size MxN: A = U * S * V^T

        The algorithm finds the singular values and, optionally, matrices U and V^T.
        The algorithm can find both first min(M,N) columns of matrix U and rows of
        matrix V^T (singular vectors), and matrices U and V^T wholly (of sizes MxM
        and NxN respectively).

        Take into account that the subroutine does not return matrix V but V^T.

        Input parameters:
            A           -   matrix to be decomposed.
                            Array whose indexes range within [1..M, 1..N].
            M           -   number of rows in matrix A.
            N           -   number of columns in matrix A.
            UNeeded     -   0, 1 or 2. See the description of the parameter U.
            VTNeeded    -   0, 1 or 2. See the description of the parameter VT.
            AdditionalMemory -
                            If the parameter:
                             * equals 0, the algorithm doesn’t use additional
                               memory (lower requirements, lower performance).
                             * equals 1, the algorithm uses additional
                               memory of size min(M,N)*min(M,N) of real numbers.
                               It often speeds up the algorithm.
                             * equals 2, the algorithm uses additional
                               memory of size M*min(M,N) of real numbers.
                               It allows to get a maximum performance.
                            The recommended value of the parameter is 2.

        Output parameters:
            W           -   contains singular values in descending order.
            U           -   if UNeeded=0, U isn't changed, the left singular vectors
                            are not calculated.
                            if Uneeded=1, U contains left singular vectors (first
                            min(M,N) columns of matrix U). Array whose indexes range
                            within [1..M, 1..Min(M,N)].
                            if UNeeded=2, U contains matrix U wholly. Array whose
                            indexes range within [1..M, 1..M].
            VT          -   if VTNeeded=0, VT isn’t changed, the right singular vectors
                            are not calculated.
                            if VTNeeded=1, VT contains right singular vectors (first
                            min(M,N) rows of matrix V^T). Array whose indexes range
                            within [1..min(M,N), 1..N].
                            if VTNeeded=2, VT contains matrix V^T wholly. Array whose
                            indexes range within [1..N, 1..N].

          -- ALGLIB --
         Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        private static bool Decomposition(double[,] a,
            int m,
            int n,
            int uneeded,
            int vtneeded,
            int additionalmemory,
            ref double[] w,
            ref double[,] u,
            ref double[,] vt)
        {
            bool result = new bool();
            double[] tauq = new double[0];
            double[] taup = new double[0];
            double[] tau = new double[0];
            double[] e = new double[0];
            double[] work = new double[0];
            double[,] t2 = new double[0, 0];
            bool isupper = new bool();
            int minmn = 0;
            int ncu = 0;
            int nrvt = 0;
            int nru = 0;
            int ncvt = 0;
            int i = 0;
            int j = 0;
            //int im1 = 0;
            //double sm = 0;

            a = (double[,])a.Clone();

            result = true;
            if (m == 0 | n == 0)
            {
                return result;
            }
            System.Diagnostics.Debug.Assert(uneeded >= 0 & uneeded <= 2, "SVDDecomposition: wrong parameters!");
            System.Diagnostics.Debug.Assert(vtneeded >= 0 & vtneeded <= 2, "SVDDecomposition: wrong parameters!");
            System.Diagnostics.Debug.Assert(additionalmemory >= 0 & additionalmemory <= 2, "SVDDecomposition: wrong parameters!");

            //
            // initialize
            //
            minmn = Math.Min(m, n);
            w = new double[minmn + 1];
            ncu = 0;
            nru = 0;
            if (uneeded == 1)
            {
                nru = m;
                ncu = minmn;
                u = new double[nru + 1, ncu + 1];
            }
            if (uneeded == 2)
            {
                nru = m;
                ncu = m;
                u = new double[nru + 1, ncu + 1];
            }
            nrvt = 0;
            ncvt = 0;
            if (vtneeded == 1)
            {
                nrvt = minmn;
                ncvt = n;
                vt = new double[nrvt + 1, ncvt + 1];
            }
            if (vtneeded == 2)
            {
                nrvt = n;
                ncvt = n;
                vt = new double[nrvt + 1, ncvt + 1];
            }

            //
            // M much larger than N
            // Use bidiagonal reduction with QR-decomposition
            //
            if (m > 1.6 * n)
            {
                if (uneeded == 0)
                {

                    //
                    // No left singular vectors to be computed
                    //
                    QR.Decomposition(ref a, m, n, ref tau);
                    for (i = 2; i <= n; i++)
                    {
                        for (j = 1; j <= i - 1; j++)
                        {
                            a[i, j] = 0;
                        }
                    }
                    Bidiagonal.ToBidiagonal(ref a, n, n, ref tauq, ref taup);
                    Bidiagonal.UnpackptFromBidiagonal(ref a, n, n, ref taup, nrvt, ref vt);
                    Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, n, n, ref isupper, ref w, ref e);
                    result = BdSvd.BidiagonalSVDDecomposition(ref w, e, n, isupper, false, ref u, 0, ref a, 0, ref vt, ncvt);
                    return result;
                }
                else
                {

                    //
                    // Left singular vectors (may be full matrix U) to be computed
                    //
                    QR.Decomposition(ref a, m, n, ref tau);
                    QR.UnpackqFromQR(ref a, m, n, ref tau, ncu, ref u);
                    for (i = 2; i <= n; i++)
                    {
                        for (j = 1; j <= i - 1; j++)
                        {
                            a[i, j] = 0;
                        }
                    }
                    Bidiagonal.ToBidiagonal(ref a, n, n, ref tauq, ref taup);
                    Bidiagonal.UnpackptFromBidiagonal(ref a, n, n, ref taup, nrvt, ref vt);
                    Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, n, n, ref isupper, ref w, ref e);
                    if (additionalmemory < 1)
                    {

                        //
                        // No additional memory can be used
                        //
                        Bidiagonal.MultiplyByqFromBidiagonal(ref a, n, n, ref tauq, ref u, m, n, true, false);
                        result = BdSvd.BidiagonalSVDDecomposition(ref w, e, n, isupper, false, ref u, m, ref a, 0, ref vt, ncvt);
                    }
                    else
                    {

                        //
                        // Large U. Transforming intermediate matrix T2
                        //
                        work = new double[Math.Max(m, n) + 1];
                        Bidiagonal.UnpackqFromBidiagonal(ref a, n, n, ref tauq, n, ref t2);
                        Blas.CopyMatrix(ref u, 1, m, 1, n, ref a, 1, m, 1, n);
                        Blas.InplaceTranspose(ref t2, 1, n, 1, n, ref work);
                        result = BdSvd.BidiagonalSVDDecomposition(ref w, e, n, isupper, false, ref u, 0, ref t2, n, ref vt, ncvt);
                        Blas.MatrixMatrixMultiply(ref a, 1, m, 1, n, false, ref t2, 1, n, 1, n, true, 1.0, ref u, 1, m, 1, n, 0.0, ref work);
                    }
                    return result;
                }
            }

            //
            // N much larger than M
            // Use bidiagonal reduction with LQ-decomposition
            //
            if (n > 1.6 * m)
            {
                if (vtneeded == 0)
                {

                    //
                    // No right singular vectors to be computed
                    //
                    LQ.Decomposition(ref a, m, n, ref tau);
                    for (i = 1; i <= m - 1; i++)
                    {
                        for (j = i + 1; j <= m; j++)
                        {
                            a[i, j] = 0;
                        }
                    }
                    Bidiagonal.ToBidiagonal(ref a, m, m, ref tauq, ref taup);
                    Bidiagonal.UnpackqFromBidiagonal(ref a, m, m, ref tauq, ncu, ref u);
                    Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, m, m, ref isupper, ref w, ref e);
                    work = new double[m + 1];
                    Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                    result = BdSvd.BidiagonalSVDDecomposition(ref w, e, m, isupper, false, ref a, 0, ref u, nru, ref vt, 0);
                    Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                    return result;
                }
                else
                {

                    //
                    // Right singular vectors (may be full matrix VT) to be computed
                    //
                    LQ.Decomposition(ref a, m, n, ref tau);
                    LQ.UnpackFromLQ(ref a, m, n, ref tau, nrvt, ref vt);
                    for (i = 1; i <= m - 1; i++)
                    {
                        for (j = i + 1; j <= m; j++)
                        {
                            a[i, j] = 0;
                        }
                    }
                    Bidiagonal.ToBidiagonal(ref a, m, m, ref tauq, ref taup);
                    Bidiagonal.UnpackqFromBidiagonal(ref a, m, m, ref tauq, ncu, ref u);
                    Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, m, m, ref isupper, ref w, ref e);
                    work = new double[Math.Max(m, n) + 1];
                    Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                    if (additionalmemory < 1)
                    {

                        //
                        // No additional memory available
                        //
                        Bidiagonal.MultiplyBypFromBidiagonal(ref a, m, m, ref taup, ref vt, m, n, false, true);
                        result = BdSvd.BidiagonalSVDDecomposition(ref w, e, m, isupper, false, ref a, 0, ref u, nru, ref vt, n);
                    }
                    else
                    {

                        //
                        // Large VT. Transforming intermediate matrix T2
                        //
                        Bidiagonal.UnpackptFromBidiagonal(ref a, m, m, ref taup, m, ref t2);
                        result = BdSvd.BidiagonalSVDDecomposition(ref w, e, m, isupper, false, ref a, 0, ref u, nru, ref t2, m);
                        Blas.CopyMatrix(ref vt, 1, m, 1, n, ref a, 1, m, 1, n);
                        Blas.MatrixMatrixMultiply(ref t2, 1, m, 1, m, false, ref a, 1, m, 1, n, false, 1.0, ref vt, 1, m, 1, n, 0.0, ref work);
                    }
                    Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                    return result;
                }
            }

            //
            // M<=N
            // We can use inplace transposition of U to get rid of columnwise operations
            //
            if (m <= n)
            {
                Bidiagonal.ToBidiagonal(ref a, m, n, ref tauq, ref taup);
                Bidiagonal.UnpackqFromBidiagonal(ref a, m, n, ref tauq, ncu, ref u);
                Bidiagonal.UnpackptFromBidiagonal(ref a, m, n, ref taup, nrvt, ref vt);
                Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, m, n, ref isupper, ref w, ref e);
                work = new double[m + 1];
                Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                result = BdSvd.BidiagonalSVDDecomposition(ref w, e, minmn, isupper, false, ref a, 0, ref u, nru, ref vt, ncvt);
                Blas.InplaceTranspose(ref u, 1, nru, 1, ncu, ref work);
                return result;
            }

            //
            // Simple bidiagonal reduction
            //
            Bidiagonal.ToBidiagonal(ref a, m, n, ref tauq, ref taup);
            Bidiagonal.UnpackqFromBidiagonal(ref a, m, n, ref tauq, ncu, ref u);
            Bidiagonal.UnpackptFromBidiagonal(ref a, m, n, ref taup, nrvt, ref vt);
            Bidiagonal.UnpackDiagonalsFromBidiagonal(ref a, m, n, ref isupper, ref w, ref e);
            if (additionalmemory < 2 | uneeded == 0)
            {

                //
                // We cant use additional memory or there is no need in such operations
                //
                result = BdSvd.BidiagonalSVDDecomposition(ref w, e, minmn, isupper, false, ref u, nru, ref a, 0, ref vt, ncvt);
            }
            else
            {

                //
                // We can use additional memory
                //
                t2 = new double[minmn + 1, m + 1];
                Blas.CopyAndTranspose(ref u, 1, m, 1, minmn, ref t2, 1, minmn, 1, m);
                result = BdSvd.BidiagonalSVDDecomposition(ref w, e, minmn, isupper, false, ref u, 0, ref t2, m, ref vt, ncvt);
                Blas.CopyAndTranspose(ref t2, 1, minmn, 1, m, ref u, 1, m, 1, minmn);
            }
            return result;
        }

        /// <summary>
        /// Rozklad macierzy algorytmem SVD.
        /// A = U*W*V^T
        /// </summary>
        /// <param name="a">Rozkladana macierz.</param>
        /// <param name="w">Referencja na wektor w.</param>
        /// <param name="u">Referencja na U.</param>
        /// <param name="vt">Referencja na V^T.</param>
        /// <returns>Jesli macierz mozna rozlozyc zwroci true, w przeciwnym razie false.</returns>
        public static bool Decomposition(double[,] a, ref double[] w, ref double[,] u, ref double[,] vt)
        {
            if (a == null)
                throw new NullReferenceException("Parametr a nie moze byc null !");

            try
            {
                return Decomposition(a, a.GetLength(0) - 1, a.GetLength(1) - 1, 2, 2, 2, ref w, ref u, ref vt);
            }
            catch
            {
                return false;
            }
        }

        public static bool DecompositionByAnalitycs(double[,] a, ref double[,] w, ref double[,] u, ref double[,] vt)
        {
            try
            {
                dnAnalytics.LinearAlgebra.Matrix m = MatrixBuilder.CreateMatrix(a.GetLength(0), a.GetLength(1));
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        m[i, j] = a[i, j];
                Console.WriteLine(m.ToString());
                Svd svd = new Svd(m, true);
                svd.Compute();
                w = svd.W().ToArray();
                u = svd.U().ToArray();
                vt = svd.VT().ToArray();
                return true;
            }
            catch(Exception exc)
            {
                return false;
            }
        }

        #endregion
    }
}
