using System;

namespace DocClass.Src.Learning.MathOperations
{
    public static class BdSvd
    {
        #region Public Methods

        /*************************************************************************
        Singular value decomposition of a bidiagonal matrix (extended algorithm)

        The algorithm performs the singular value decomposition  of  a  bidiagonal
        matrix B (upper or lower) representing it as B = Q*S*P^T, where Q and  P -
        orthogonal matrices, S - diagonal matrix with non-negative elements on the
        main diagonal, in descending order.

        The  algorithm  finds  singular  values.  In  addition,  the algorithm can
        calculate  matrices  Q  and P (more precisely, not the matrices, but their
        product  with  given  matrices U and VT - U*Q and (P^T)*VT)).  Of  course,
        matrices U and VT can be of any type, including identity. Furthermore, the
        algorithm can calculate Q'*C (this product is calculated more  effectively
        than U*Q,  because  this calculation operates with rows instead  of matrix
        columns).

        The feature of the algorithm is its ability to find  all  singular  values
        including those which are arbitrarily close to 0  with  relative  accuracy
        close to  machine precision. If the parameter IsFractionalAccuracyRequired
        is set to True, all singular values will have high relative accuracy close
        to machine precision. If the parameter is set to False, only  the  biggest
        singular value will have relative accuracy  close  to  machine  precision.
        The absolute error of other singular values is equal to the absolute error
        of the biggest singular value.

        Input parameters:
            D       -   main diagonal of matrix B.
                        Array whose index ranges within [1..N].
            E       -   superdiagonal (or subdiagonal) of matrix B.
                        Array whose index ranges within [1..N-1].
            N       -   size of matrix B.
            IsUpper -   True, if the matrix is upper bidiagonal.
            IsFractionalAccuracyRequired -
                        accuracy to search singular values with.
            U       -   matrix to be multiplied by Q.
                        Array whose indexes range within [1..NRU, 1..N].
                        The matrix can be bigger, in that case only the  submatrix
                        [1..NRU, 1..N] will be multiplied by Q.
            NRU     -   number of rows in matrix U.
            C       -   matrix to be multiplied by Q'.
                        Array whose indexes range within [1..N, 1..NCC].
                        The matrix can be bigger, in that case only the  submatrix
                        [1..N, 1..NCC] will be multiplied by Q'.
            NCC     -   number of columns in matrix C.
            VT      -   matrix to be multiplied by P^T.
                        Array whose indexes range within [1..N, 1..NCVT].
                        The matrix can be bigger, in that case only the  submatrix
                        [1..N, 1..NCVT] will be multiplied by P^T.
            NCVT    -   number of columns in matrix VT.

        Output parameters:
            D       -   singular values of matrix B in descending order.
            U       -   if NRU>0, contains matrix U*Q.
            VT      -   if NCVT>0, contains matrix (P^T)*VT.
            C       -   if NCC>0, contains matrix Q'*C.

        Result:
            True, if the algorithm has converged.
            False, if the algorithm hasn't converged (rare case).

        Additional information:
            The type of convergence is controlled by the internal  parameter  TOL.
            If the parameter is greater than 0, the singular values will have
            relative accuracy TOL. If TOL<0, the singular values will have
            absolute accuracy ABS(TOL)*norm(B).
            By default, |TOL| falls within the range of 10*Epsilon and 100*Epsilon,
            where Epsilon is the machine precision. It is not  recommended  to  use
            TOL less than 10*Epsilon since this will  considerably  slow  down  the
            algorithm and may not lead to error decreasing.
        History:
            * 31 March, 2007.
                changed MAXITR from 6 to 12.

          -- LAPACK routine (version 3.0) --
             Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
             Courant Institute, Argonne National Lab, and Rice University
             October 31, 1999.
        *************************************************************************/
        public static bool BidiagonalSVDDecomposition(ref double[] d,
            double[] e,
            int n,
            bool isupper,
            bool isfractionalaccuracyrequired,
            ref double[,] u,
            int nru,
            ref double[,] c,
            int ncc,
            ref double[,] vt,
            int ncvt)
        {
            bool result = new bool();
            int i = 0;
            int idir = 0;
            int isub = 0;
            int iter = 0;
            int j = 0;
            int ll = 0;
            int lll = 0;
            int m = 0;
            int maxit = 0;
            int oldll = 0;
            int oldm = 0;
            double abse = 0;
            double abss = 0;
            double cosl = 0;
            double cosr = 0;
            double cs = 0;
            double eps = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            double mu = 0;
            double oldcs = 0;
            double oldsn = 0;
            double r = 0;
            double shift = 0;
            double sigmn = 0;
            double sigmx = 0;
            double sinl = 0;
            double sinr = 0;
            double sll = 0;
            double smax = 0;
            double smin = 0;
            double sminl = 0;
            double sminlo = 0;
            double sminoa = 0;
            double sn = 0;
            double thresh = 0;
            double tol = 0;
            double tolmul = 0;
            double unfl = 0;
            double[] work0 = new double[0];
            double[] work1 = new double[0];
            double[] work2 = new double[0];
            double[] work3 = new double[0];
            int maxitr = 0;
            bool matrixsplitflag = new bool();
            bool iterflag = new bool();
            double[] utemp = new double[0];
            double[] vttemp = new double[0];
            double[] ctemp = new double[0];
            double[] etemp = new double[0];
            //bool rightside = new bool();
            bool fwddir = new bool();
            double tmp = 0;
            int mm1 = 0;
            bool bchangedir = new bool();
            int i_ = 0;

            e = (double[])e.Clone();

            result = true;
            if (n == 0)
            {
                return result;
            }
            if (n == 1)
            {
                if (d[1] < 0)
                {
                    d[1] = -d[1];
                    if (ncvt > 0)
                    {
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[1, i_] = -1 * vt[1, i_];
                        }
                    }
                }
                return result;
            }

            //
            // init
            //
            work0 = new double[n - 1 + 1];
            work1 = new double[n - 1 + 1];
            work2 = new double[n - 1 + 1];
            work3 = new double[n - 1 + 1];
            utemp = new double[Math.Max(nru, 1) + 1];
            vttemp = new double[Math.Max(ncvt, 1) + 1];
            ctemp = new double[Math.Max(ncc, 1) + 1];
            maxitr = 12;
            //rightside = true;
            fwddir = true;

            //
            // resize E from N-1 to N
            //
            etemp = new double[n + 1];
            for (i = 1; i <= n - 1; i++)
            {
                etemp[i] = e[i];
            }
            e = new double[n + 1];
            for (i = 1; i <= n - 1; i++)
            {
                e[i] = etemp[i];
            }
            e[n] = 0;
            idir = 0;

            //
            // Get machine constants
            //
            eps = Common.MachineEpsilon;
            unfl = Common.MinRealNumber;

            //
            // If matrix lower bidiagonal, rotate to be upper bidiagonal
            // by applying Givens rotations on the left
            //
            if (!isupper)
            {
                for (i = 1; i <= n - 1; i++)
                {
                    Rotations.GenerateRotation(d[i], e[i], ref cs, ref sn, ref r);
                    d[i] = r;
                    e[i] = sn * d[i + 1];
                    d[i + 1] = cs * d[i + 1];
                    work0[i] = cs;
                    work1[i] = sn;
                }

                //
                // Update singular vectors if desired
                //
                if (nru > 0)
                {
                    Rotations.ApplyRotationsFromTheRight(fwddir, 1, nru, 1, n, ref work0, ref work1, ref u, ref utemp);
                }
                if (ncc > 0)
                {
                    Rotations.ApplyRotationsFromTheLeft(fwddir, 1, n, 1, ncc, ref work0, ref work1, ref c, ref ctemp);
                }
            }

            //
            // Compute singular values to relative accuracy TOL
            // (By setting TOL to be negative, algorithm will compute
            // singular values to absolute accuracy ABS(TOL)*norm(input matrix))
            //
            tolmul = Math.Max(10, Math.Min(100, Math.Pow(eps, -0.125)));
            tol = tolmul * eps;
            if (!isfractionalaccuracyrequired)
            {
                tol = -tol;
            }

            //
            // Compute approximate maximum, minimum singular values
            //
            smax = 0;
            for (i = 1; i <= n; i++)
            {
                smax = Math.Max(smax, Math.Abs(d[i]));
            }
            for (i = 1; i <= n - 1; i++)
            {
                smax = Math.Max(smax, Math.Abs(e[i]));
            }
            sminl = 0;
            if (tol >= 0)
            {

                //
                // Relative accuracy desired
                //
                sminoa = Math.Abs(d[1]);
                if (sminoa != 0)
                {
                    mu = sminoa;
                    for (i = 2; i <= n; i++)
                    {
                        mu = Math.Abs(d[i]) * (mu / (mu + Math.Abs(e[i - 1])));
                        sminoa = Math.Min(sminoa, mu);
                        if (sminoa == 0)
                        {
                            break;
                        }
                    }
                }
                sminoa = sminoa / Math.Sqrt(n);
                thresh = Math.Max(tol * sminoa, maxitr * n * n * unfl);
            }
            else
            {

                //
                // Absolute accuracy desired
                //
                thresh = Math.Max(Math.Abs(tol) * smax, maxitr * n * n * unfl);
            }

            //
            // Prepare for main iteration loop for the singular values
            // (MAXIT is the maximum number of passes through the inner
            // loop permitted before nonconvergence signalled.)
            //
            maxit = maxitr * n * n;
            iter = 0;
            oldll = -1;
            oldm = -1;

            //
            // M points to last element of unconverged part of matrix
            //
            m = n;

            //
            // Begin main iteration loop
            //
            while (true)
            {

                //
                // Check for convergence or exceeding iteration count
                //
                if (m <= 1)
                {
                    break;
                }
                if (iter > maxit)
                {
                    result = false;
                    return result;
                }

                //
                // Find diagonal block of matrix to work on
                //
                if (tol < 0 & Math.Abs(d[m]) <= thresh)
                {
                    d[m] = 0;
                }
                smax = Math.Abs(d[m]);
                smin = smax;
                matrixsplitflag = false;
                for (lll = 1; lll <= m - 1; lll++)
                {
                    ll = m - lll;
                    abss = Math.Abs(d[ll]);
                    abse = Math.Abs(e[ll]);
                    if (tol < 0 & abss <= thresh)
                    {
                        d[ll] = 0;
                    }
                    if (abse <= thresh)
                    {
                        matrixsplitflag = true;
                        break;
                    }
                    smin = Math.Min(smin, abss);
                    smax = Math.Max(smax, Math.Max(abss, abse));
                }
                if (!matrixsplitflag)
                {
                    ll = 0;
                }
                else
                {

                    //
                    // Matrix splits since E(LL) = 0
                    //
                    e[ll] = 0;
                    if (ll == m - 1)
                    {

                        //
                        // Convergence of bottom singular value, return to top of loop
                        //
                        m = m - 1;
                        continue;
                    }
                }
                ll = ll + 1;

                //
                // E(LL) through E(M-1) are nonzero, E(LL-1) is zero
                //
                if (ll == m - 1)
                {

                    //
                    // 2 by 2 block, handle separately
                    //
                    Svdv2x2(d[m - 1], e[m - 1], d[m], ref sigmn, ref sigmx, ref sinr, ref cosr, ref sinl, ref cosl);
                    d[m - 1] = sigmx;
                    e[m - 1] = 0;
                    d[m] = sigmn;

                    //
                    // Compute singular vectors, if desired
                    //
                    if (ncvt > 0)
                    {
                        mm1 = m - 1;
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vttemp[i_] = cosr * vt[mm1, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vttemp[i_] = vttemp[i_] + sinr * vt[m, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[m, i_] = cosr * vt[m, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[m, i_] = vt[m, i_] - sinr * vt[mm1, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[mm1, i_] = vttemp[i_];
                        }
                    }
                    if (nru > 0)
                    {
                        mm1 = m - 1;
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            utemp[i_] = cosl * u[i_, mm1];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            utemp[i_] = utemp[i_] + sinl * u[i_, m];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            u[i_, m] = cosl * u[i_, m];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            u[i_, m] = u[i_, m] - sinl * u[i_, mm1];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            u[i_, mm1] = utemp[i_];
                        }
                    }
                    if (ncc > 0)
                    {
                        mm1 = m - 1;
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            ctemp[i_] = cosl * c[mm1, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            ctemp[i_] = ctemp[i_] + sinl * c[m, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            c[m, i_] = cosl * c[m, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            c[m, i_] = c[m, i_] - sinl * c[mm1, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            c[mm1, i_] = ctemp[i_];
                        }
                    }
                    m = m - 2;
                    continue;
                }

                //
                // If working on new submatrix, choose shift direction
                // (from larger end diagonal element towards smaller)
                //
                // Previously was
                //     "if (LL>OLDM) or (M<OLDLL) then"
                // fixed thanks to Michael Rolle < m@rolle.name >
                // Very strange that LAPACK still contains it.
                //
                bchangedir = false;
                if (idir == 1 & Math.Abs(d[ll]) < 1.0E-3 * Math.Abs(d[m]))
                {
                    bchangedir = true;
                }
                if (idir == 2 & Math.Abs(d[m]) < 1.0E-3 * Math.Abs(d[ll]))
                {
                    bchangedir = true;
                }
                if (ll != oldll | m != oldm | bchangedir)
                {
                    if (Math.Abs(d[ll]) >= Math.Abs(d[m]))
                    {

                        //
                        // Chase bulge from top (big end) to bottom (small end)
                        //
                        idir = 1;
                    }
                    else
                    {

                        //
                        // Chase bulge from bottom (big end) to top (small end)
                        //
                        idir = 2;
                    }
                }

                //
                // Apply convergence tests
                //
                if (idir == 1)
                {

                    //
                    // Run convergence test in forward direction
                    // First apply standard test to bottom of matrix
                    //
                    if (Math.Abs(e[m - 1]) <= Math.Abs(tol) * Math.Abs(d[m]) | tol < 0 & Math.Abs(e[m - 1]) <= thresh)
                    {
                        e[m - 1] = 0;
                        continue;
                    }
                    if (tol >= 0)
                    {

                        //
                        // If relative accuracy desired,
                        // apply convergence criterion forward
                        //
                        mu = Math.Abs(d[ll]);
                        sminl = mu;
                        iterflag = false;
                        for (lll = ll; lll <= m - 1; lll++)
                        {
                            if (Math.Abs(e[lll]) <= tol * mu)
                            {
                                e[lll] = 0;
                                iterflag = true;
                                break;
                            }
                            sminlo = sminl;
                            mu = Math.Abs(d[lll + 1]) * (mu / (mu + Math.Abs(e[lll])));
                            sminl = Math.Min(sminl, mu);
                        }
                        if (iterflag)
                        {
                            continue;
                        }
                    }
                }
                else
                {

                    //
                    // Run convergence test in backward direction
                    // First apply standard test to top of matrix
                    //
                    if (Math.Abs(e[ll]) <= Math.Abs(tol) * Math.Abs(d[ll]) | tol < 0 & Math.Abs(e[ll]) <= thresh)
                    {
                        e[ll] = 0;
                        continue;
                    }
                    if (tol >= 0)
                    {

                        //
                        // If relative accuracy desired,
                        // apply convergence criterion backward
                        //
                        mu = Math.Abs(d[m]);
                        sminl = mu;
                        iterflag = false;
                        for (lll = m - 1; lll >= ll; lll--)
                        {
                            if (Math.Abs(e[lll]) <= tol * mu)
                            {
                                e[lll] = 0;
                                iterflag = true;
                                break;
                            }
                            sminlo = sminl;
                            mu = Math.Abs(d[lll]) * (mu / (mu + Math.Abs(e[lll])));
                            sminl = Math.Min(sminl, mu);
                        }
                        if (iterflag)
                        {
                            continue;
                        }
                    }
                }
                oldll = ll;
                oldm = m;

                //
                // Compute shift.  First, test if shifting would ruin relative
                // accuracy, and if so set the shift to zero.
                //
                if (tol >= 0 & n * tol * (sminl / smax) <= Math.Max(eps, 0.01 * tol))
                {

                    //
                    // Use a zero shift to avoid loss of relative accuracy
                    //
                    shift = 0;
                }
                else
                {

                    //
                    // Compute the shift from 2-by-2 block at end of matrix
                    //
                    if (idir == 1)
                    {
                        sll = Math.Abs(d[ll]);
                        Svd2x2(d[m - 1], e[m - 1], d[m], ref shift, ref r);
                    }
                    else
                    {
                        sll = Math.Abs(d[m]);
                        Svd2x2(d[ll], e[ll], d[ll + 1], ref shift, ref r);
                    }

                    //
                    // Test if shift negligible, and if so set to zero
                    //
                    if (sll > 0)
                    {
                        if (Common.Sqr(shift / sll) < eps)
                        {
                            shift = 0;
                        }
                    }
                }

                //
                // Increment iteration count
                //
                iter = iter + m - ll;

                //
                // If SHIFT = 0, do simplified QR iteration
                //
                if (shift == 0)
                {
                    if (idir == 1)
                    {

                        //
                        // Chase bulge from top to bottom
                        // Save cosines and sines for later singular vector updates
                        //
                        cs = 1;
                        oldcs = 1;
                        for (i = ll; i <= m - 1; i++)
                        {
                            Rotations.GenerateRotation(d[i] * cs, e[i], ref cs, ref sn, ref r);
                            if (i > ll)
                            {
                                e[i - 1] = oldsn * r;
                            }
                            Rotations.GenerateRotation(oldcs * r, d[i + 1] * sn, ref oldcs, ref oldsn, ref tmp);
                            d[i] = tmp;
                            work0[i - ll + 1] = cs;
                            work1[i - ll + 1] = sn;
                            work2[i - ll + 1] = oldcs;
                            work3[i - ll + 1] = oldsn;
                        }
                        h = d[m] * cs;
                        d[m] = h * oldcs;
                        e[m - 1] = h * oldsn;

                        //
                        // Update singular vectors
                        //
                        if (ncvt > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(fwddir, ll, m, 1, ncvt, ref work0, ref work1, ref vt, ref vttemp);
                        }
                        if (nru > 0)
                        {
                            Rotations.ApplyRotationsFromTheRight(fwddir, 1, nru, ll, m, ref work2, ref work3, ref u, ref utemp);
                        }
                        if (ncc > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(fwddir, ll, m, 1, ncc, ref work2, ref work3, ref c, ref ctemp);
                        }

                        //
                        // Test convergence
                        //
                        if (Math.Abs(e[m - 1]) <= thresh)
                        {
                            e[m - 1] = 0;
                        }
                    }
                    else
                    {

                        //
                        // Chase bulge from bottom to top
                        // Save cosines and sines for later singular vector updates
                        //
                        cs = 1;
                        oldcs = 1;
                        for (i = m; i >= ll + 1; i--)
                        {
                            Rotations.GenerateRotation(d[i] * cs, e[i - 1], ref cs, ref sn, ref r);
                            if (i < m)
                            {
                                e[i] = oldsn * r;
                            }
                            Rotations.GenerateRotation(oldcs * r, d[i - 1] * sn, ref oldcs, ref oldsn, ref tmp);
                            d[i] = tmp;
                            work0[i - ll] = cs;
                            work1[i - ll] = -sn;
                            work2[i - ll] = oldcs;
                            work3[i - ll] = -oldsn;
                        }
                        h = d[ll] * cs;
                        d[ll] = h * oldcs;
                        e[ll] = h * oldsn;

                        //
                        // Update singular vectors
                        //
                        if (ncvt > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(!fwddir, ll, m, 1, ncvt, ref work2, ref work3, ref vt, ref vttemp);
                        }
                        if (nru > 0)
                        {
                            Rotations.ApplyRotationsFromTheRight(!fwddir, 1, nru, ll, m, ref work0, ref work1, ref u, ref utemp);
                        }
                        if (ncc > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(!fwddir, ll, m, 1, ncc, ref work0, ref work1, ref c, ref ctemp);
                        }

                        //
                        // Test convergence
                        //
                        if (Math.Abs(e[ll]) <= thresh)
                        {
                            e[ll] = 0;
                        }
                    }
                }
                else
                {

                    //
                    // Use nonzero shift
                    //
                    if (idir == 1)
                    {

                        //
                        // Chase bulge from top to bottom
                        // Save cosines and sines for later singular vector updates
                        //
                        f = (Math.Abs(d[ll]) - shift) * (ExtSignBdsqr(1, d[ll]) + shift / d[ll]);
                        g = e[ll];
                        for (i = ll; i <= m - 1; i++)
                        {
                            Rotations.GenerateRotation(f, g, ref cosr, ref sinr, ref r);
                            if (i > ll)
                            {
                                e[i - 1] = r;
                            }
                            f = cosr * d[i] + sinr * e[i];
                            e[i] = cosr * e[i] - sinr * d[i];
                            g = sinr * d[i + 1];
                            d[i + 1] = cosr * d[i + 1];
                            Rotations.GenerateRotation(f, g, ref cosl, ref sinl, ref r);
                            d[i] = r;
                            f = cosl * e[i] + sinl * d[i + 1];
                            d[i + 1] = cosl * d[i + 1] - sinl * e[i];
                            if (i < m - 1)
                            {
                                g = sinl * e[i + 1];
                                e[i + 1] = cosl * e[i + 1];
                            }
                            work0[i - ll + 1] = cosr;
                            work1[i - ll + 1] = sinr;
                            work2[i - ll + 1] = cosl;
                            work3[i - ll + 1] = sinl;
                        }
                        e[m - 1] = f;

                        //
                        // Update singular vectors
                        //
                        if (ncvt > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(fwddir, ll, m, 1, ncvt, ref work0, ref work1, ref vt, ref vttemp);
                        }
                        if (nru > 0)
                        {
                            Rotations.ApplyRotationsFromTheRight(fwddir, 1, nru, ll, m, ref work2, ref work3, ref u, ref utemp);
                        }
                        if (ncc > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(fwddir, ll, m, 1, ncc, ref work2, ref work3, ref c, ref ctemp);
                        }

                        //
                        // Test convergence
                        //
                        if (Math.Abs(e[m - 1]) <= thresh)
                        {
                            e[m - 1] = 0;
                        }
                    }
                    else
                    {

                        //
                        // Chase bulge from bottom to top
                        // Save cosines and sines for later singular vector updates
                        //
                        f = (Math.Abs(d[m]) - shift) * (ExtSignBdsqr(1, d[m]) + shift / d[m]);
                        g = e[m - 1];
                        for (i = m; i >= ll + 1; i--)
                        {
                            Rotations.GenerateRotation(f, g, ref cosr, ref sinr, ref r);
                            if (i < m)
                            {
                                e[i] = r;
                            }
                            f = cosr * d[i] + sinr * e[i - 1];
                            e[i - 1] = cosr * e[i - 1] - sinr * d[i];
                            g = sinr * d[i - 1];
                            d[i - 1] = cosr * d[i - 1];
                            Rotations.GenerateRotation(f, g, ref cosl, ref sinl, ref r);
                            d[i] = r;
                            f = cosl * e[i - 1] + sinl * d[i - 1];
                            d[i - 1] = cosl * d[i - 1] - sinl * e[i - 1];
                            if (i > ll + 1)
                            {
                                g = sinl * e[i - 2];
                                e[i - 2] = cosl * e[i - 2];
                            }
                            work0[i - ll] = cosr;
                            work1[i - ll] = -sinr;
                            work2[i - ll] = cosl;
                            work3[i - ll] = -sinl;
                        }
                        e[ll] = f;

                        //
                        // Test convergence
                        //
                        if (Math.Abs(e[ll]) <= thresh)
                        {
                            e[ll] = 0;
                        }

                        //
                        // Update singular vectors if desired
                        //
                        if (ncvt > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(!fwddir, ll, m, 1, ncvt, ref work2, ref work3, ref vt, ref vttemp);
                        }
                        if (nru > 0)
                        {
                            Rotations.ApplyRotationsFromTheRight(!fwddir, 1, nru, ll, m, ref work0, ref work1, ref u, ref utemp);
                        }
                        if (ncc > 0)
                        {
                            Rotations.ApplyRotationsFromTheLeft(!fwddir, ll, m, 1, ncc, ref work0, ref work1, ref c, ref ctemp);
                        }
                    }
                }

                //
                // QR iteration finished, go back and check convergence
                //
                continue;
            }

            //
            // All singular values converged, so make them positive
            //
            for (i = 1; i <= n; i++)
            {
                if (d[i] < 0)
                {
                    d[i] = -d[i];

                    //
                    // Change sign of singular vectors, if desired
                    //
                    if (ncvt > 0)
                    {
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[i, i_] = -1 * vt[i, i_];
                        }
                    }
                }
            }

            //
            // Sort the singular values into decreasing order (insertion sort on
            // singular values, but only one transposition per singular vector)
            //
            for (i = 1; i <= n - 1; i++)
            {

                //
                // Scan for smallest D(I)
                //
                isub = 1;
                smin = d[1];
                for (j = 2; j <= n + 1 - i; j++)
                {
                    if (d[j] <= smin)
                    {
                        isub = j;
                        smin = d[j];
                    }
                }
                if (isub != n + 1 - i)
                {

                    //
                    // Swap singular values and vectors
                    //
                    d[isub] = d[n + 1 - i];
                    d[n + 1 - i] = smin;
                    if (ncvt > 0)
                    {
                        j = n + 1 - i;
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vttemp[i_] = vt[isub, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[isub, i_] = vt[j, i_];
                        }
                        for (i_ = 1; i_ <= ncvt; i_++)
                        {
                            vt[j, i_] = vttemp[i_];
                        }
                    }
                    if (nru > 0)
                    {
                        j = n + 1 - i;
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            utemp[i_] = u[i_, isub];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            u[i_, isub] = u[i_, j];
                        }
                        for (i_ = 1; i_ <= nru; i_++)
                        {
                            u[i_, j] = utemp[i_];
                        }
                    }
                    if (ncc > 0)
                    {
                        j = n + 1 - i;
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            ctemp[i_] = c[isub, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            c[isub, i_] = c[j, i_];
                        }
                        for (i_ = 1; i_ <= ncc; i_++)
                        {
                            c[j, i_] = ctemp[i_];
                        }
                    }
                }
            }
            return result;
        }


        private static double ExtSignBdsqr(double a,
            double b)
        {
            double result = 0;

            if (b >= 0)
            {
                result = Math.Abs(a);
            }
            else
            {
                result = -Math.Abs(a);
            }
            return result;
        }


        private static void Svd2x2(double f,
            double g,
            double h,
            ref double ssmin,
            ref double ssmax)
        {
            double aas = 0;
            double at = 0;
            double au = 0;
            double c = 0;
            double fa = 0;
            double fhmn = 0;
            double fhmx = 0;
            double ga = 0;
            double ha = 0;

            fa = Math.Abs(f);
            ga = Math.Abs(g);
            ha = Math.Abs(h);
            fhmn = Math.Min(fa, ha);
            fhmx = Math.Max(fa, ha);
            if (fhmn == 0)
            {
                ssmin = 0;
                if (fhmx == 0)
                {
                    ssmax = ga;
                }
                else
                {
                    ssmax = Math.Max(fhmx, ga) * Math.Sqrt(1 + Common.Sqr(Math.Min(fhmx, ga) / Math.Max(fhmx, ga)));
                }
            }
            else
            {
                if (ga < fhmx)
                {
                    aas = 1 + fhmn / fhmx;
                    at = (fhmx - fhmn) / fhmx;
                    au = Common.Sqr(ga / fhmx);
                    c = 2 / (Math.Sqrt(aas * aas + au) + Math.Sqrt(at * at + au));
                    ssmin = fhmn * c;
                    ssmax = fhmx / c;
                }
                else
                {
                    au = fhmx / ga;
                    if (au == 0)
                    {

                        //
                        // Avoid possible harmful underflow if exponent range
                        // asymmetric (true SSMIN may not underflow even if
                        // AU underflows)
                        //
                        ssmin = fhmn * fhmx / ga;
                        ssmax = ga;
                    }
                    else
                    {
                        aas = 1 + fhmn / fhmx;
                        at = (fhmx - fhmn) / fhmx;
                        c = 1 / (Math.Sqrt(1 + Common.Sqr(aas * au)) + Math.Sqrt(1 + Common.Sqr(at * au)));
                        ssmin = fhmn * c * au;
                        ssmin = ssmin + ssmin;
                        ssmax = ga / (c + c);
                    }
                }
            }
        }


        private static void Svdv2x2(double f,
            double g,
            double h,
            ref double ssmin,
            ref double ssmax,
            ref double snr,
            ref double csr,
            ref double snl,
            ref double csl)
        {
            bool gasmal = new bool();
            bool swp = new bool();
            int pmax = 0;
            double a = 0;
            double clt = 0;
            double crt = 0;
            double d = 0;
            double fa = 0;
            double ft = 0;
            double ga = 0;
            double gt = 0;
            double ha = 0;
            double ht = 0;
            double l = 0;
            double m = 0;
            double mm = 0;
            double r = 0;
            double s = 0;
            double slt = 0;
            double srt = 0;
            double t = 0;
            double temp = 0;
            double tsign = 0;
            double tt = 0;
            double v = 0;

            ft = f;
            fa = Math.Abs(ft);
            ht = h;
            ha = Math.Abs(h);

            //
            // PMAX points to the maximum absolute element of matrix
            //  PMAX = 1 if F largest in absolute values
            //  PMAX = 2 if G largest in absolute values
            //  PMAX = 3 if H largest in absolute values
            //
            pmax = 1;
            swp = ha > fa;
            if (swp)
            {

                //
                // Now FA .ge. HA
                //
                pmax = 3;
                temp = ft;
                ft = ht;
                ht = temp;
                temp = fa;
                fa = ha;
                ha = temp;
            }
            gt = g;
            ga = Math.Abs(gt);
            if (ga == 0)
            {

                //
                // Diagonal matrix
                //
                ssmin = ha;
                ssmax = fa;
                clt = 1;
                crt = 1;
                slt = 0;
                srt = 0;
            }
            else
            {
                gasmal = true;
                if (ga > fa)
                {
                    pmax = 2;
                    if (fa / ga < Common.MachineEpsilon)
                    {

                        //
                        // Case of very large GA
                        //
                        gasmal = false;
                        ssmax = ga;
                        if (ha > 1)
                        {
                            v = ga / ha;
                            ssmin = fa / v;
                        }
                        else
                        {
                            v = fa / ga;
                            ssmin = v * ha;
                        }
                        clt = 1;
                        slt = ht / gt;
                        srt = 1;
                        crt = ft / gt;
                    }
                }
                if (gasmal)
                {

                    //
                    // Normal case
                    //
                    d = fa - ha;
                    if (d == fa)
                    {
                        l = 1;
                    }
                    else
                    {
                        l = d / fa;
                    }
                    m = gt / ft;
                    t = 2 - l;
                    mm = m * m;
                    tt = t * t;
                    s = Math.Sqrt(tt + mm);
                    if (l == 0)
                    {
                        r = Math.Abs(m);
                    }
                    else
                    {
                        r = Math.Sqrt(l * l + mm);
                    }
                    a = 0.5 * (s + r);
                    ssmin = ha / a;
                    ssmax = fa * a;
                    if (mm == 0)
                    {

                        //
                        // Note that M is very tiny
                        //
                        if (l == 0)
                        {
                            t = ExtSignBdsqr(2, ft) * ExtSignBdsqr(1, gt);
                        }
                        else
                        {
                            t = gt / ExtSignBdsqr(d, ft) + m / t;
                        }
                    }
                    else
                    {
                        t = (m / (s + t) + m / (r + l)) * (1 + a);
                    }
                    l = Math.Sqrt(t * t + 4);
                    crt = 2 / l;
                    srt = t / l;
                    clt = (crt + srt * m) / a;
                    v = ht / ft;
                    slt = v * srt / a;
                }
            }
            if (swp)
            {
                csl = srt;
                snl = crt;
                csr = slt;
                snr = clt;
            }
            else
            {
                csl = clt;
                snl = slt;
                csr = crt;
                snr = srt;
            }

            //
            // Correct signs of SSMAX and SSMIN
            //
            if (pmax == 1)
            {
                tsign = ExtSignBdsqr(1, csr) * ExtSignBdsqr(1, csl) * ExtSignBdsqr(1, f);
            }
            if (pmax == 2)
            {
                tsign = ExtSignBdsqr(1, snr) * ExtSignBdsqr(1, csl) * ExtSignBdsqr(1, g);
            }
            if (pmax == 3)
            {
                tsign = ExtSignBdsqr(1, snr) * ExtSignBdsqr(1, snl) * ExtSignBdsqr(1, h);
            }
            ssmax = ExtSignBdsqr(ssmax, tsign);
            ssmin = ExtSignBdsqr(ssmin, tsign * ExtSignBdsqr(1, f) * ExtSignBdsqr(1, h));
        }

        #endregion
    }
}
