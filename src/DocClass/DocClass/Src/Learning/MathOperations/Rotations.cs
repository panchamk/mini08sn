﻿using System;

namespace DocClass.Src.Learning.MathOperations
{
    public static class Rotations
    {
        #region Public Methods

        /*************************************************************************
        Application of a sequence of  elementary rotations to a matrix

        The algorithm pre-multiplies the matrix by a sequence of rotation
        transformations which is given by arrays C and S. Depending on the value
        of the IsForward parameter either 1 and 2, 3 and 4 and so on (if IsForward=true)
        rows are rotated, or the rows N and N-1, N-2 and N-3 and so on, are rotated.

        Not the whole matrix but only a part of it is transformed (rows from M1 to
        M2, columns from N1 to N2). Only the elements of this submatrix are changed.

        Input parameters:
            IsForward   -   the sequence of the rotation application.
            M1,M2       -   the range of rows to be transformed.
            N1, N2      -   the range of columns to be transformed.
            C,S         -   transformation coefficients.
                            Array whose index ranges within [1..M2-M1].
            A           -   processed matrix.
            WORK        -   working array whose index ranges within [N1..N2].

        Output parameters:
            A           -   transformed matrix.

        Utility subroutine.
        *************************************************************************/
        public static void ApplyRotationsFromTheLeft(bool isforward,
            int m1,
            int m2,
            int n1,
            int n2,
            ref double[] c,
            ref double[] s,
            ref double[,] a,
            ref double[] work)
        {
            int j = 0;
            int jp1 = 0;
            double ctemp = 0;
            double stemp = 0;
            double temp = 0;
            int i_ = 0;

            if (m1 > m2 | n1 > n2)
            {
                return;
            }

            //
            // Form  P * A
            //
            if (isforward)
            {
                if (n1 != n2)
                {

                    //
                    // Common case: N1<>N2
                    //
                    for (j = m1; j <= m2 - 1; j++)
                    {
                        ctemp = c[j - m1 + 1];
                        stemp = s[j - m1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            jp1 = j + 1;
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                work[i_] = ctemp * a[jp1, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                work[i_] = work[i_] - stemp * a[j, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[j, i_] = ctemp * a[j, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[j, i_] = a[j, i_] + stemp * a[jp1, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[jp1, i_] = work[i_];
                            }
                        }
                    }
                }
                else
                {

                    //
                    // Special case: N1=N2
                    //
                    for (j = m1; j <= m2 - 1; j++)
                    {
                        ctemp = c[j - m1 + 1];
                        stemp = s[j - m1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            temp = a[j + 1, n1];
                            a[j + 1, n1] = ctemp * temp - stemp * a[j, n1];
                            a[j, n1] = stemp * temp + ctemp * a[j, n1];
                        }
                    }
                }
            }
            else
            {
                if (n1 != n2)
                {

                    //
                    // Common case: N1<>N2
                    //
                    for (j = m2 - 1; j >= m1; j--)
                    {
                        ctemp = c[j - m1 + 1];
                        stemp = s[j - m1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            jp1 = j + 1;
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                work[i_] = ctemp * a[jp1, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                work[i_] = work[i_] - stemp * a[j, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[j, i_] = ctemp * a[j, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[j, i_] = a[j, i_] + stemp * a[jp1, i_];
                            }
                            for (i_ = n1; i_ <= n2; i_++)
                            {
                                a[jp1, i_] = work[i_];
                            }
                        }
                    }
                }
                else
                {

                    //
                    // Special case: N1=N2
                    //
                    for (j = m2 - 1; j >= m1; j--)
                    {
                        ctemp = c[j - m1 + 1];
                        stemp = s[j - m1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            temp = a[j + 1, n1];
                            a[j + 1, n1] = ctemp * temp - stemp * a[j, n1];
                            a[j, n1] = stemp * temp + ctemp * a[j, n1];
                        }
                    }
                }
            }
        }


        /*************************************************************************
        Application of a sequence of  elementary rotations to a matrix

        The algorithm post-multiplies the matrix by a sequence of rotation
        transformations which is given by arrays C and S. Depending on the value
        of the IsForward parameter either 1 and 2, 3 and 4 and so on (if IsForward=true)
        rows are rotated, or the rows N and N-1, N-2 and N-3 and so on are rotated.

        Not the whole matrix but only a part of it is transformed (rows from M1
        to M2, columns from N1 to N2). Only the elements of this submatrix are changed.

        Input parameters:
            IsForward   -   the sequence of the rotation application.
            M1,M2       -   the range of rows to be transformed.
            N1, N2      -   the range of columns to be transformed.
            C,S         -   transformation coefficients.
                            Array whose index ranges within [1..N2-N1].
            A           -   processed matrix.
            WORK        -   working array whose index ranges within [M1..M2].

        Output parameters:
            A           -   transformed matrix.

        Utility subroutine.
        *************************************************************************/
        public static void ApplyRotationsFromTheRight(bool isforward,
            int m1,
            int m2,
            int n1,
            int n2,
            ref double[] c,
            ref double[] s,
            ref double[,] a,
            ref double[] work)
        {
            int j = 0;
            int jp1 = 0;
            double ctemp = 0;
            double stemp = 0;
            double temp = 0;
            int i_ = 0;


            //
            // Form A * P'
            //
            if (isforward)
            {
                if (m1 != m2)
                {

                    //
                    // Common case: M1<>M2
                    //
                    for (j = n1; j <= n2 - 1; j++)
                    {
                        ctemp = c[j - n1 + 1];
                        stemp = s[j - n1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            jp1 = j + 1;
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                work[i_] = ctemp * a[i_, jp1];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                work[i_] = work[i_] - stemp * a[i_, j];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, j] = ctemp * a[i_, j];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, j] = a[i_, j] + stemp * a[i_, jp1];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, jp1] = work[i_];
                            }
                        }
                    }
                }
                else
                {

                    //
                    // Special case: M1=M2
                    //
                    for (j = n1; j <= n2 - 1; j++)
                    {
                        ctemp = c[j - n1 + 1];
                        stemp = s[j - n1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            temp = a[m1, j + 1];
                            a[m1, j + 1] = ctemp * temp - stemp * a[m1, j];
                            a[m1, j] = stemp * temp + ctemp * a[m1, j];
                        }
                    }
                }
            }
            else
            {
                if (m1 != m2)
                {

                    //
                    // Common case: M1<>M2
                    //
                    for (j = n2 - 1; j >= n1; j--)
                    {
                        ctemp = c[j - n1 + 1];
                        stemp = s[j - n1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            jp1 = j + 1;
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                work[i_] = ctemp * a[i_, jp1];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                work[i_] = work[i_] - stemp * a[i_, j];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, j] = ctemp * a[i_, j];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, j] = a[i_, j] + stemp * a[i_, jp1];
                            }
                            for (i_ = m1; i_ <= m2; i_++)
                            {
                                a[i_, jp1] = work[i_];
                            }
                        }
                    }
                }
                else
                {

                    //
                    // Special case: M1=M2
                    //
                    for (j = n2 - 1; j >= n1; j--)
                    {
                        ctemp = c[j - n1 + 1];
                        stemp = s[j - n1 + 1];
                        if (ctemp != 1 | stemp != 0)
                        {
                            temp = a[m1, j + 1];
                            a[m1, j + 1] = ctemp * temp - stemp * a[m1, j];
                            a[m1, j] = stemp * temp + ctemp * a[m1, j];
                        }
                    }
                }
            }
        }


        /*************************************************************************
        The subroutine generates the elementary rotation, so that:

        [  CS  SN  ]  .  [ F ]  =  [ R ]
        [ -SN  CS  ]     [ G ]     [ 0 ]

        CS**2 + SN**2 = 1
        *************************************************************************/
        public static void GenerateRotation(double f,
            double g,
            ref double cs,
            ref double sn,
            ref double r)
        {
            double f1 = 0;
            double g1 = 0;

            if (g == 0)
            {
                cs = 1;
                sn = 0;
                r = f;
            }
            else
            {
                if (f == 0)
                {
                    cs = 0;
                    sn = 1;
                    r = g;
                }
                else
                {
                    f1 = f;
                    g1 = g;
                    r = Math.Sqrt(Common.Sqr(f1) + Common.Sqr(g1));
                    cs = f1 / r;
                    sn = g1 / r;
                    if (Math.Abs(f) > Math.Abs(g) & cs < 0)
                    {
                        cs = -cs;
                        sn = -sn;
                        r = -r;
                    }
                }
            }
        }

        #endregion
    }
}
