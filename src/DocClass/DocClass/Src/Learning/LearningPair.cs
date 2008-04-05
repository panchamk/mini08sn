using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Classification;

namespace DocClass.Src.Learning
{
    class LearningPair
    {
        private Dictionary<String, Double> dict;
        private int output;

        public LearningPair(Dictionary<String, Double> d, int o)
        {
            this.dict = d;
            this.output = o;
        }

        public Dictionary<String, Double> Map
        {
            get { return this.dict; }
        }

        public int Output
        {
            get { return this.output; }
        }

        public double[] OutputVector
        {
            get
            {
                double[] output = new double[DocumentClass.CategoriesCount];
                output[this.output] = 1;
                return output;
            }
        }

    }
}
