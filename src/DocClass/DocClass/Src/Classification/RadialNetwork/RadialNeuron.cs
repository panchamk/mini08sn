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
        private double[] sigma;
        private int vectorSize;
        private static Random r = new Random();

        /// <summary>
        /// Wspolczynnik uczenia sieci
        /// </summary>
        public const double eta = 0.03;

        //sigma dla funkcji gaussa

        #endregion

        #region accessors

        private int VectorSize
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
                    RandomizeCells();
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
            VectorSize = input.Length;
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region private methods


        /// <summary>
        /// Losuje wartosci CellCenter, czyli srodki komorek oraz wspolczynniki szerokosci komorek
        /// </summary>
        private void RandomizeCells()
        {
            cellCenter = new double[VectorSize];
            sigma = new double[VectorSize];
            for (int i = 0; i < VectorSize; i++)
            {
                cellCenter[i] = r.NextDouble();
                sigma[i] = r.NextDouble();

            }
            //TODO: rozwiazac kwestie szerokoscie zakresu losowania srodkow komorek
        }

        
        #endregion

        #region public methods

        public void CorrectFactors(double[] c, double[] sigma)
        {
            for (int i = 0; i < c.Length; i++)
            {
                cellCenter[i] -= RadialNeuron.eta * c[i];
                this.sigma[i] -= RadialNeuron.eta * sigma[i];
            }
            
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
                result += (x[ii] - CellCenter[ii]) * (x[ii] - CellCenter[ii]) / sigma[ii] / sigma[ii];
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
        public double u3(double[] x, int t)
        {
            return (x[t] - cellCenter[t]) * (x[t] - cellCenter[t]) / sigma[t] / sigma[t] / sigma[t];
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
        public double u(double[] x, int k)
        {
            return (x[k] - cellCenter[k]) / sigma[k] / sigma[k];
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
            VectorSize = x.Length;
            if (x.Length != CellCenter.Length)
                throw new IncompatibleArrayLength();
            int len = x.Length;

            for (int i = 0; i < len; i++)
            {
                result += (CellCenter[i] - x[i]) * (CellCenter[i] - x[i]) / sigma[i] / sigma[i];
            }
            result /= -2;
            return Math.Pow(Math.E, result);
        }


        #endregion

        public override string ToString()
        {
            String result = String.Empty;
            for (int i = 0; i < CellCenter.Length; i++)
            {
                result += "Center[" + i + "]=" + cellCenter[i];
                result += "\nSigma[" + i + "]=" + this.sigma[i] + "\n";
            }
            return result;
        }
    }
}
