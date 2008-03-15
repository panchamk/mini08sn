using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Exceptions;

namespace DocClass.src.classification.radialNetwork
{
    class RadialNeuron : INeuron
    {
        #region private members

        private double sigma = 0.5;

        #endregion

        #region INeuron Members

        public double Process()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public double SetInput(double[] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        //funkcja gaussa dla neuronu
        //TODO: sprawdzic poprawnosc dzialania
        private double GaussianFunction(double[] x, double[] c)
        {
            double result = 0;
            if (x.Length != c.Length)
                throw new IncompatibleArrayLength();
            int len = x.Length;
            
            for (int i = 0; i < len; i++)
            {
                result += (c[i] - x[i]) * (c[i] - x[i]);
            }
            result /= -2 * sigma * sigma;
            return Math.Pow(Math.E, result);
        }
    }
}
