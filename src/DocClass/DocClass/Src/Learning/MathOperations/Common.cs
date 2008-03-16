using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    public static class Common
    {
        #region Private And Public Static Fields

        private static Random RndObject = new Random();
        public const double MachineEpsilon = 5E-16;
        public const double MaxRealNumber = 1E300;
        public const double MinRealNumber = 1E-300;

        #endregion

        #region Public Methods

        public static double RandomReal()
        {
            return RndObject.NextDouble();
        }

        public static int RandomInteger(int N)
        {
            return RndObject.Next(N);
        }

        public static double Sqr(double X)
        {
            return X * X;
        }

        #endregion
    }
}
