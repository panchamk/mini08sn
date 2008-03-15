using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Exceptions;

namespace DocClass.src.classification.radialNetwork
{
    class RadialNeuron : INeuron
    {
        #region private members

       

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

        #region private methods

        #endregion
    }
}
