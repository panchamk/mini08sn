using System;

namespace DocClass.Src.Learning.MathOperations
{
    public static class QR
    {
        #region Public Methods

        /*************************************************************************
        QR decomposition of a rectangular matrix of size MxN

        Input parameters:
            A   -   matrix A whose indexes range within [1..M, 1..N].
            M   -   number of rows in matrix A.
            N   -   number of columns in matrix A.

        Output parameters:
            A   -   matrices Q and R in compact form (see below).
            Tau -   array of scalar factors which are used to form
                    matrix Q. Array whose index ranges within [1..Min(M,N)].

        Matrix A is represented as A = QR, where Q is an orthogonal matrix of size
        MxM, R - upper triangular (or upper trapezoid) matrix of size M x N.

        The elements of matrix R are located on and above the main diagonal of
        matrix A. The elements which are located in Tau array and below the main
        diagonal of matrix A are used to form matrix Q as follows:

        Matrix Q is represented as a product of elementary reflections

        Q = H(1)*H(2)*...*H(k),

        where k = min(m,n), and each H(i) is in the form

        H(i) = 1 - tau * v * (v^T)

        where tau is a scalar stored in Tau[I]; v - real vector,
        so that v(1:i-1) = 0, v(i) = 1, v(i+1:m) stored in A(i+1:m,i).

          -- LAPACK routine (version 3.0) --
             Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
             Courant Institute, Argonne National Lab, and Rice University
             February 29, 1992
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
            int mmip1 = 0;
            int minmn = 0;
            double tmp = 0;
            int i_ = 0;
            int i1_ = 0;

            minmn = Math.Min(m, n);
            work = new double[n + 1];
            t = new double[m + 1];
            tau = new double[minmn + 1];

            //
            // Test the input arguments
            //
            k = Math.Min(m, n);
            for (i = 1; i <= k; i++)
            {

                //
                // Generate elementary reflector H(i) to annihilate A(i+1:m,i)
                //
                mmip1 = m - i + 1;
                i1_ = (i) - (1);
                for (i_ = 1; i_ <= mmip1; i_++)
                {
                    t[i_] = a[i_ + i1_, i];
                }
                Reflections.GenerateReflection(ref t, mmip1, ref tmp);
                tau[i] = tmp;
                i1_ = (1) - (i);
                for (i_ = i; i_ <= m; i_++)
                {
                    a[i_, i] = t[i_ + i1_];
                }
                t[1] = 1;
                if (i < n)
                {

                    //
                    // Apply H(i) to A(i:m,i+1:n) from the left
                    //
                    Reflections.ApplyReflectionFromTheLeft(ref a, tau[i], ref t, i, m, i + 1, n, ref work);
                }
            }
        }


        /*************************************************************************
        Partial unpacking of matrix Q from the QR decomposition of a matrix A

        Input parameters:
            A       -   matrices Q and R in compact form.
                        Output of QRDecomposition subroutine.
            M       -   number of rows in given matrix A. M>=0.
            N       -   number of columns in given matrix A. N>=0.
            Tau     -   scalar factors which are used to form Q.
                        Output of the QRDecomposition subroutine.
            QColumns -  required number of columns of matrix Q. M>=QColumns>=0.

        Output parameters:
            Q       -   first QColumns columns of matrix Q.
                        Array whose indexes range within [1..M, 1..QColumns].
                        If QColumns=0, the array remains unchanged.

          -- ALGLIB --
             Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        public static void UnpackqFromQR(ref double[,] a,
            int m,
            int n,
            ref double[] tau,
            int qcolumns,
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

            System.Diagnostics.Debug.Assert(qcolumns <= m, "UnpackQFromQR: QColumns>M!");
            if (m == 0 | n == 0 | qcolumns == 0)
            {
                return;
            }

            //
            // init
            //
            minmn = Math.Min(m, n);
            k = Math.Min(minmn, qcolumns);
            q = new double[m + 1, qcolumns + 1];
            v = new double[m + 1];
            work = new double[qcolumns + 1];
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= qcolumns; j++)
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
                vm = m - i + 1;
                i1_ = (i) - (1);
                for (i_ = 1; i_ <= vm; i_++)
                {
                    v[i_] = a[i_ + i1_, i];
                }
                v[1] = 1;
                Reflections.ApplyReflectionFromTheLeft(ref q, tau[i], ref v, i, m, 1, qcolumns, ref work);
            }
        }


        /*************************************************************************
        QR decomposition of a rectangular matrix of size MxN

        It uses QRDecomposition. Q and R are not output in compact form, but as
        separate general matrices. R is filled up by zeros in their corresponding
        positions, and Q is generated as a product of elementary reflections.

          -- ALGLIB --
             Copyright 2005 by Bochkanov Sergey
        *************************************************************************/
        public static void DecompositionUnpacked(double[,] a,
            int m,
            int n,
            ref double[,] q,
            ref double[,] r)
        {
            int i = 0;
            int k = 0;
            double[] tau = new double[0];
            double[] work = new double[0];
            double[] v = new double[0];
            int i_ = 0;

            a = (double[,])a.Clone();

            k = Math.Min(m, n);
            if (n <= 0)
            {
                return;
            }
            work = new double[m + 1];
            v = new double[m + 1];
            q = new double[m + 1, m + 1];
            r = new double[m + 1, n + 1];

            //
            // QRDecomposition
            //
            Decomposition(ref a, m, n, ref tau);

            //
            // R
            //
            for (i = 1; i <= n; i++)
            {
                r[1, i] = 0;
            }
            for (i = 2; i <= m; i++)
            {
                for (i_ = 1; i_ <= n; i_++)
                {
                    r[i, i_] = r[1, i_];
                }
            }
            for (i = 1; i <= k; i++)
            {
                for (i_ = i; i_ <= n; i_++)
                {
                    r[i, i_] = a[i, i_];
                }
            }

            //
            // Q
            //
            UnpackqFromQR(ref a, m, n, ref tau, m, ref q);
        }

        #endregion
    }
}
