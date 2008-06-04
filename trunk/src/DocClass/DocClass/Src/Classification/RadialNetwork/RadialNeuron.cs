using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Exceptions;
using System.Diagnostics;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.RadialNetwork
{
    [Serializable]
    class RadialNeuron : INeuron
    {
        #region private members

        private double[] cellCenter;
        private double[] sigma;
        private double[] prevCellCenter;
        private double[] prevSigma;
        private int vectorSize;
        private static Random r = new Random();
        int number;

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
            Debug.WriteLine("Losowanie centrow");
            for (int i = 0; i < VectorSize; i++)
            {
                cellCenter[i] = r.NextDouble();
                sigma[i] = r.NextDouble();
                Debug.Write(String.Format("Wsp[{0}] = {1,5:F2}, S[{2}] = {3,5:F2}", i, cellCenter[i], i ,sigma[i]));
            }
            //TODO: rozwiazac kwestie szerokoscie zakresu losowania srodkow komorek
        }

        /// <summary>
        /// Losowanie polozenia komorki w przedziale [min, max]
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void RandomizeCells(double[] min, double[] max, int neuronNumber)
        {
            cellCenter = new double[min.Length];
            this.number = neuronNumber;
            
            sigma = new double[min.Length];
            for (int i = 0; i < min.Length; i++)
            {
                cellCenter[i] = min[i] + r.NextDouble() * Math.Abs(max[i] - min[i]);
                sigma[i] = r.NextDouble()*(Math.Abs(max[i] - min[i])+1);
            }
            //TODO: rozwiazac kwestie szerokoscie zakresu losowania srodkow komorek
            this.ToString();
        }

       
        #endregion

        #region public methods

        public void CorrectFactors(double[] c, double[] s)
        {
            this.prevCellCenter = new double[cellCenter.Length];
            this.prevSigma = new double[sigma.Length];
            for (int i = 0; i < c.Length; i++)
            {
                this.prevCellCenter[i] = this.cellCenter[i];
                this.prevSigma[i] = this.sigma[i];
                this.cellCenter[i] -= RadialNeuron.eta * c[i];//-
                this.sigma[i] -= RadialNeuron.eta * s[i];//-
            }
            
        }

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

        /// <summary>
        /// Ustawia poczatkowy punkt srodkowy neuronu
        /// </summary>
        /// <param name="newCellCenter">Wspolrzedne punktu</param>
        public void SetCellCenter(double[] newCellCenter)
        {
            this.cellCenter = newCellCenter;
        }

        public override string ToString()
        {
            Debug.WriteLine("\n\nNeuron "+ number);
            for (int i = 0; i < cellCenter.Length; i++)
            {
                Debug.Write(String.Format("Wsp[{0}] = {1,5:F2}\t", i, cellCenter[i]));
            }
            Debug.WriteLine("");
            for (int i = 0; i < cellCenter.Length; i++)
            {
                Debug.Write(String.Format("S[{0}]   = {1,5:F2}\t", i, sigma[i]));
            }
            Debug.WriteLine("");
            Debug.WriteLine("Nalezy do grupy " + TestDocument.classBelonings(new List<double>(cellCenter)).ToString());
            return null;
        }

        //dodałem Tomek
        public static RadialNeuron TestSave()
        {
            RadialNeuron rn = new RadialNeuron();
            rn.cellCenter = new double[1] { 1.0 };
            rn.VectorSize = 1;
            rn.sigma = new double[1] { 1.0 };

            Console.Out.WriteLine("  " + rn.CellCenter[0]);
            Console.Out.WriteLine("  " + rn.VectorSize);
            Console.Out.WriteLine("  " + rn.sigma[0]);
            return rn;
        }
        //dodałem Tomek
        public static void TestLoad(RadialNeuron rn)
        {

            Console.Out.WriteLine("  " + rn.CellCenter[0]);
            Console.Out.WriteLine("  " + rn.VectorSize);
            Console.Out.WriteLine("  " + rn.sigma[0]);
        }

        #region INeuron Members


        public void BackToPrevWeights()
        {
            for (int i = 0; i < this.sigma.Length; i++)
            {
                this.cellCenter[i] = this.prevCellCenter[i];
                this.sigma[i] = this.prevSigma[i];
            }
        }

        #endregion
    }
}
