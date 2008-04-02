using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DocClass.Src.Classification.RadialNetwork
{
    class LinearNeuron : INeuron
    {
        #region static members
        public const double TRESHOLD = 0.5;
        #endregion

        #region private members

        double[] weigths;

        #endregion

        #region INeuron Members

        public double Process(double[] vector)
        {
            if (weigths == null)
                CreateWeigths(vector.Length);
            double result = 0;
            for (int i = 0; i < weigths.Length; i++)
            {
                result += weigths[i] * vector[i];
            }
            return result;
        }

        private void CreateWeigths(int p)
        {
            this.weigths = new double[p];
        }

        public double SetInput(double[] input)
        {
            this.weigths = new double[input.Length];
            return 0;
        }

        #endregion

        #region setters

        public double[] Weights
        {
            set
            {
                this.weigths = value;
            }
        }

        #endregion
    }
}
