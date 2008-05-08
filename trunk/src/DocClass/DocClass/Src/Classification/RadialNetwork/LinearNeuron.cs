using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DocClass.Src.Classification.RadialNetwork
{
    [Serializable]
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
                if (i == 0)
                    result += weigths[i];
                else
                    result += weigths[i] * vector[i-1];
            }
            return result;
        }

        /// <summary>
        /// Tworzenie wektora wag dla neuronow wyjsciowych
        /// </summary>
        /// <param name="p">Liczba neuronow w wartwie ukrytej</param>
        private void CreateWeigths(int p)
        {
            this.weigths = new double[p];
        }

        #endregion

        #region setters

        public double[] Weights
        {
            set
            {
                this.weigths = value;
            }
            get
            {
                return this.weigths;
            }
        }

        #endregion

        public override string ToString()
        {
            String result = String.Empty;
            for (int i = 0; i < weigths.Length; i++)
            {
                result += "Wagi[" + i + "]=" + this.weigths[i]+ "\n";
            }
            return result;
        }
    }
}
