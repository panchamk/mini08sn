using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    class Iteracja
    {
        private int iteracja;
        private double f0;
        private double f1;
        private double f2;
        private double f3;

        public double F0
        {
            get { return f0; }
            set { f0 = value; }
        }

        public double F1
        {
            get { return f1; }
            set { f1 = value; }
        }

        public double F2
        {
            get { return f2; }
            set { f2 = value; }
        }

        public double F3
        {
            get { return f3; }
            set { f3 = value; }
        }

        public int Iter
        {
            get { return iteracja; }
            set { iteracja = value; }
        }
    }
}
