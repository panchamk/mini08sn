using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    class Pierwiastek
    {
        //privates-----------------------------
        private double liczba;
        private double punktStartowy;
        private double stopien;
        private int liczbaIteracji;

        private double xkf, xk1f;
        private double xkf1, xk1f1;
        private double xkf2, xk1f2;
        private double xkf3, xk1f3;



        //accessors----------------------------
        public double Liczba
        {
            get { return liczba; }
            set { this.liczba = value; }
        }

        public double PunbktStartowy
        {
            get { return punktStartowy; }
            set 
            { 
                this.punktStartowy = value;
                this.xkf = this.xkf1 = this.xkf2 = value;
            }
        }
        
        public double Stopien
        {
            get { return stopien; }
            set { this.stopien = value; }
        }

        public int LiczbaIteracji
        {
            get { return liczbaIteracji; }
            set { this.liczbaIteracji = value; }
        }

        //computes------------------------------

        private double f(double x)
        {
            return System.Math.Pow(x, stopien) - liczba;
        }

        private double f_prim(double x)
        {
            return stopien * Math.Pow(x, stopien - 1);
        }

        private double f_bis(double x)
        {
            return Math.Pow(x, stopien - 2) * stopien * (stopien - 1);
        }

        private double liczF2(double x)
        {
            double x_a, x_2a, licznik, mianownik,
                a = stopien, b = liczba;

            x_a = Math.Pow(x, stopien);
            x_2a = Math.Pow(x, 2 * stopien);
            licznik = 6 * x * (x_2a * (a + 1) - 2 * b * x_a - b * b * a + b * b);
            mianownik = x_2a * (2 * a * a + 6 * a + 4) + 8 * x_a * b * (a * a - 1) + b * b * (2 * a * a - 6 * a + 4);
            return licznik / mianownik;
        }

        //private double liczF3(double x)
        //{
        //    double x_a, x_2a, licznik, mianownik,
        //        a = stopien, b = liczba;

        //    x_a = Math.Pow(x, stopien);
        //    x_2a = Math.Pow(x, 2 * stopien);
        //    licznik = 8 * x * (x_2a * (a + 1) - 2 * b * x_a - b * b * a + b * b);
        //    mianownik = x_2a * (2 * a * a + 6 * a + 4) + 8 * x_a * b * (a * a - 1) + b * b * (2 * a * a - 6 * a + 4);
        //    return licznik / mianownik;
        //}

        private double liczF3(double x)
        {
            double x_a, x_2a, x_3a, licznik, mianownik,
                a = stopien, b = liczba;

            x_a = Math.Pow(x, stopien);
            x_2a = Math.Pow(x, 2 * stopien);
            x_3a = Math.Pow(x, 3 * stopien);
            licznik = -(4 * x * (-b + x_a) * ((2 - 3 * a + a * a) * b * b + 4 * (-1 + a * a) * b * x_a + (2 + 3 * a + a * a) * x_2a));
            mianownik = ((-6 + 11 * a - 6 * a * a + a * a * a) * b * b * b + (18 - 11 * a - 18 * a * a + 11 * a * a * a) * b * b * x_a + (-18 - 11 * a + 18 * a * a + 11 * a * a * a) * b * x_2a + (6 + 11 * a + 6 * a * a + a * a * a) * x_3a);
            return licznik / mianownik;
        }

        public void reset()
        {
        }

        public List<Iteracja> obliczenia()
        {
            xkf = xkf1 = xkf2 = xkf3 = punktStartowy;
            List<Iteracja> result = new List<Iteracja>();
            for(int i = 0; i<liczbaIteracji; i++)
            {
                Iteracja it = new Iteracja();
                it.Iter = i + 1;
                xk1f = xkf - f(xkf) / f_prim(xkf);
                it.F0 = xk1f;

                xk1f1 = xkf1 - ((f(xkf1) * f_prim(xkf1)) / (f_prim(xkf1) * f_prim(xkf1) - ((double)1 / 2) * f(xkf1) * f_bis(xkf1)));
                it.F1 = xk1f1;

                xk1f2 = xkf2 - liczF2(xkf2);
                it.F2 = xk1f2;

                xk1f3 = xkf3 + liczF3(xkf3);
                it.F3 = xk1f3;

                result.Add(it);
                xkf = xk1f;
                xkf1 = xk1f1;
                xkf2 = xk1f2;
                xkf3 = xk1f3;
            }

            return result;
        }

        
    }
}
