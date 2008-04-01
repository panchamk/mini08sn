using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Exceptions;

namespace DocClass.Src.Classification.RadialNetwork
{
    class RadialNeuron : INeuron
    {
        #region private members

        private double[] cellCenter;
        private int vectorSize;

        //sigma dla funkcji gaussa
        private double sigma = 0.5;

        #endregion

        #region accessors

        private int VecotrSize
        {
            get
            {
                if (vectorSize > 0)
                    return vectorSize;
                else
                    throw new Exception("Nieznany wymiar wektora");
            }
            set
            {
                if (vectorSize > 0 && value != vectorSize)
                    throw new Exception("Nieprawidlowy wymiar wektora");
                else if (vectorSize == 0)
                    this.vectorSize = value;
            }
        }

        private double[] CellCenter
        {
            get
            {
                if (cellCenter == null)
                    RandomizeCellCenter();
                return cellCenter;
            }
        }


        #endregion

        #region INeuron Members

        public double Process(double[] vector)
        {
            return GaussianFunction(vector);
        }

        public double SetInput(double[] input)
        {
            VecotrSize = input.Length;
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region private methods

        private void RandomizeCellCenter()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            cellCenter = new double[VecotrSize];
            for (int i = 0; i < VecotrSize; i++)
                cellCenter[i] = r.NextDouble();
            //TODO: rozwiazac kwestie szerokoscie zakresu losowania srodkow komorek
        }

        
        #endregion

        #region public methods

        public void CorrectFactors(double c, double sigma)
        {
            //TODO: przemyslec dokladnie to
            throw new NotImplementedException();
        }

        //TODO: do sprawdzenia
        /// <summary>
        /// Funkcja z definicji
        /// Uzywana do poprawy wspolczynnikow warstwy ukrytej neuronow
        /// Licznik w kwadracie
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public double u2(double[] x)
        {
            double result = 0;
            for (int ii = 0; ii < x.Length; ii++)
            {
                result += (x[ii] - cellCenter[ii]) * (x[ii] - cellCenter[ii]) / sigma / sigma;
            }

            return result;
        }

        //TODO: do sprawdzenia
        /// <summary>
        /// Funkcja z definicji
        /// Uzywana do poprawy wspolczynnikow warstwy ukrytej neuronow.
        /// Licznik w kwadracie.
        /// Mianownik w trzeciej potedze
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public double u3(double[] x)
        {
            double result = 0;
            for (int ii = 0; ii < x.Length; ii++)
            {
                result += (x[ii] - cellCenter[ii]) * (x[ii] - cellCenter[ii]) / sigma / sigma;
            }

            return result;
        }

        //TODO: do sprawdzenia
        /// <summary>
        /// Funkcja z definicji
        /// Uzywana do poprawy wspolczynnikow warstwy ukrytej neuronow
        /// Licznik bez kwadratu
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public double u(double[] x)
        {
            double result = 0;
            for (int ii = 0; ii < x.Length; ii++)
            {
                result += (x[ii] - cellCenter[ii]) / sigma / sigma;
            }

            return result;
        }


        /// <summary>
        /// Funkcja fi uzywana przy uczeniu warstwy ukrytej
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public double fi(double u)
        {
            return Math.Pow(Math.E, (-1 / 2 * u));
        }


        //TODO: sprawdzic poprawnosc dzialania
        /// <summary>
        /// Funkcja gaussa dla neuronu
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GaussianFunction(double[] x)
        {
            double result = 0;
            VecotrSize = x.Length;
            if (x.Length != CellCenter.Length)
                throw new IncompatibleArrayLength();
            int len = x.Length;

            for (int i = 0; i < len; i++)
            {
                result += (CellCenter[i] - x[i]) * (CellCenter[i] - x[i]);
            }
            result /= -2 * sigma * sigma;
            return Math.Pow(Math.E, result);
        }


        #endregion
    }
}
