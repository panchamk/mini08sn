using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DocClass.src.classification.radialNetwork
{
    class LinearNeuron : INeuron
    {
        #region static members
        public const double TRESHOLD = 0.5;
        #endregion

        #region private members

        List<double> weigths;

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

        #region constructors

        public LinearNeuron()
        {
            weigths = new List<double>();
        }

        #endregion

    }
}
