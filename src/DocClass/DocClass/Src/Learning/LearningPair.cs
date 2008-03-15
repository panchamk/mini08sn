using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Learning
{
    class LearningPair
    {
        private double[] vector;
        private double output;

        public LearningPair(double[] v, int o)
        {
            this.vector = v;
            this.output = o;
        }

        public double[] Vector
        {
            get { return this.vector; }
        }

        public double Output
        {
            get { return this.output; }
        }

    }
}
