using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
