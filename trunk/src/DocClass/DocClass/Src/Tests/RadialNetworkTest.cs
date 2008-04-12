using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DocClass.Src.Classification;
using DocClass.Src.Classification.RadialNetwork;
using DocClass.Src.Dictionaries;
using System.Diagnostics;

namespace DocClass.Src.Tests
{
    [TestFixture]
    public class RadialNetworkTest
    {
        Classificator testedClassificator;
        Dictionary dictionary;
        Random r = new Random();

        [Test]
        public void Tests()
        {
            testedClassificator = new RadialNetwork(12, 2);
            Console.WriteLine("Instance crated");
            Assert.IsNotNull(testedClassificator);
            dictionary = new DictionaryFake(100);
            dictionary.Init(null);
            Console.WriteLine("Instance crated");
            Assert.IsNotNull(testedClassificator);
            DocumentClass.AddClass("zero");
            DocumentClass.AddClass("jeden");
            testedClassificator.Learn(dictionary);
            int counter = 0;
            int total = 100;
            for(int i=0; i<total; i++)
            {
                double[] test = GenTestVector();
                Console.WriteLine(test[0] + " " +test[1]);
                int desired = desiredOutput(test);
                int get = testedClassificator.Classificate(test);
                Console.WriteLine("Spodzienawy wynik: " + desired);
                Console.WriteLine("Otrzymany wynik: " + get);
                if (get == desired)
                {
                    Console.WriteLine("---------------------------------------OK!");
                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Skutecznosc rzedu: " + (double)counter / total * 100);

            
        }

        private int desiredOutput(double[] dict)
        {
            return  (dict[0] < 0.5 && dict[1] > 0.5 || dict[0] > 0.5 && dict[1] < 0.5) ? 1 : 0;
        }

        private double[] GenTestVector()
        {
            
            double r1, r2;

            double[] dict = new double[2];
                dict[0] = r1 = r.NextDouble();
                dict[1] = r2 = r.NextDouble();
            return dict;
                
        }
    }
}
