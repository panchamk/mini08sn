using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning;

namespace DocClass.Src.Tests
{
    class DictionaryFake : Dictionary
    {
        int numOfData;
        public DictionaryFake(int num)
        {
            numOfData = num;
            this.learningData = new List<DocClass.Src.Learning.LearningPair>();
        }
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.IDocument> docs)
        {
            Random r = new Random();
            double r1, r2;

            for (int i = 0; i < numOfData; i++)
            {
                Dictionary<String, double> dict = new Dictionary<string,double>();
                dict["0"] = r1 = (r.NextDouble() * 2) - 1;
                dict["1"] = r2 = (r.NextDouble() * 2) - 1;

                LearningPair lp = new LearningPair(dict, (r1*r2<0)? 1 : 0);
                this.learningData.Add(lp);
            }
            return true;
        }
    }
}
