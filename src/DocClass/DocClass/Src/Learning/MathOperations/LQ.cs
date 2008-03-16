using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    public static class LQ
    {
        #region Public Methods

        /*************************************************************************
        LQ decomposition of a rectangular matrix of size MxN

        Input parameters:
            A   -   matrix A whose indexes range within [1..M, 1..N].
            M   -   number of rows in matrix A.
            N   -   number of columns in matrix A.

        Output parameters:
            A   -   matrices L and Q in compact form (see below)
            Tau -   array of scalar factors which are used to form
                    matrix Q. Array whose index ranges within [1..Min(M,N)].

        Matrix A is represented as A = LQ, where Q is an orthogonal matrix of size
        MxM, L - lower triangular (or lower trapezoid) matrix of size M x N.

        The elements of matrix L are located on and below the main diagonal of
        matrix A. The elements which are located in Tau array and above the main
        diagonal of matrix A are used to form matrix Q as follows:

        Matrix Q is represented as a product of elementary reflections

        Q = H(k)*H(k-1)*...*H(2)*H(1),

        where k = min(m,n), and each H(i) is of the form

        H(i) = 1 - tau * v * (v^T)

        where tau is a scalar stored in Tau[I]; v - real vector,
        so that v(1:i-1) = 0, v(i) = 1, v(i+1:n) stored in A(i,i+1:n).

          -- ALGLIB --
             Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        public static void Decomposition(ref double[,] a,
            int m,
            int n,
            ref double[] tau)
        {
            double[] work = new double[0];
            double[] t = new double[0];
            int i = 0;
            int k = 0;
            int nmip1 = 0;
            int minmn = 0;
            int maxmn = 0;
            double tmp = 0;
            int i_ = 0;
            int i1_ = 0;

            minmn = Math.Min(m, n);
            maxmn = Math.Max(m, n);
            work = new double[m + 1];
            t = new double[n + 1];
            tau = new double[minmn + 1];

            //
            // Test the input arguments
            //
            k = Math.Min(m, n);
            for (i = 1; i <= k; i++)
            {

                //
                // Generate elementary reflector H(i) to annihilate A(i,i+1:n)
                //
                nmip1 = n - i + 1;
                i1_ = (i) - (1);
                for (i_ = 1; i_ <= nmip1; i_++)
                {
                    t[i_] = a[i, i_ + i1_];
                }
                Reflections.GenerateReflection(ref t, nmip1, ref tmp);
                tau[i] = tmp;
                i1_ = (1) - (i);
                for (i_ = i; i_ <= n; i_++)
                {
                    a[i, i_] = t[i_ + i1_];
                }
                t[1] = 1;
                if (i < n)
                {

                    //
                    // Apply H(i) to A(i+1:m,i:n) from the right
                    //
                    Reflections.ApplyReflectionFromTheRight(ref a, tau[i], ref t, i + 1, m, i, n, ref work);
                }
            }
        }


        /*************************************************************************
        Partial unpacking of matrix Q from the LQ decomposition of a matrix A

        Input parameters:
            A       -   matrices L and Q in compact form.
                        Output of LQDecomposition subroutine.
            M       -   number of rows in given matrix A. M>=0.
            N       -   number of columns in given matrix A. N>=0.
            Tau     -   scalar factors which are used to form Q.
                        Output of the LQDecomposition subroutine.
            QRows   -   required number of rows in matrix Q. N>=QRows>=0.

        Output parameters:
            Q       -   first QRows rows of matrix Q. Array whose indexes range
                        within [1..QRows, 1..N]. If QRows=0, the array remains
                        unchanged.

          -- ALGLIB --
             Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        public static void UnpackFromLQ(ref double[,] a,
            int m,
            int n,
            ref double[] tau,
            int qrows,
            ref double[,] q)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int minmn = 0;
            double[] v = new double[0];
            double[] work = new double[0];
            int vm = 0;
            int i_ = 0;
            int i1_ = 0;

            System.Diagnostics.Debug.Assert(qrows <= n, "UnpackQFromLQ: QRows>N!");
            if (m == 0 | n == 0 | qrows == 0)
            {
                return;
            }

            //
            // init
            //
            minmn = Math.Min(m, n);
            k = Math.Min(minmn, qrows);
            q = new double[qrows + 1, n + 1];
            v = new double[n + 1];
            work = new double[qrows + 1];
            for (i = 1; i <= qrows; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (i == j)
                    {
                        q[i, j] = 1;
                    }
                    else
                    {
                        q[i, j] = 0;
                    }
                }
            }

            //
            // unpack Q
            //
            for (i = k; i >= 1; i--)
            {

                //
                // Apply H(i)
                //
                vm = n - i + 1;
                i1_ = (i) - (1);
                for (i_ = 1; i_ <= vm; i_++)
                {
                    v[i_] = a[i, i_ + i1_];
                }
                v[1] = 1;
                Reflections.ApplyReflectionFromTheRight(ref q, tau[i], ref v, 1, qrows, i, n, ref work);
            }
        }


        /*************************************************************************
        LQ decomposition of a rectangular matrix of size MxN

        It uses LQDecomposition. L and Q are not output in compact form, but as
        separate general matrices. L is filled up by zeros in their corresponding
        positions, and Q is generated as a product of elementary reflections.

          -- ALGLIB --
             Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        public static void DecompositionUnpacked(double[,] a,
            int m,
            int n,
            ref double[,] l,
            ref double[,] q)
        {
            int i = 0;
            int j = 0;
            double[] tau = new double[0];

            a = (double[,])a.Clone();

            if (n <= 0)
            {
                return;
            }
            q = new double[n + 1, n + 1];
            l = new double[m + 1, n + 1];

            //
            // LQDecomposition
            //
            Decomposition(ref a, m, n, ref tau);

            //
            // L
            //
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (j > i)
                    {
                        l[i, j] = 0;
                    }
                    else
                    {
                        l[i, j] = a[i, j];
                    }
                }
            }

            //
            // Q
            //
            UnpackFromLQ(ref a, m, n, ref tau, n, ref q);
        }

        #endregion
    }
}
