using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DocClass.src.classification;
using DocClass.src.classification.radialNetwork;
using DocClass.Src.Dictionaries;
using DocClass.Src.Classification;

namespace DocClass.Src.Tests
{
    [TestFixture]
    public class RadialNetworkTest
    {
        Classificator testedClassificator;
        Dictionary dictionary;


        [Test]
        public void Tests()
        {
            testedClassificator = new RadialNetwork(2, 2);
            Console.WriteLine("Instance crated");
            Assert.IsNotNull(testedClassificator);
            dictionary = new DictionaryFake(1000);
            dictionary.Init(null);
            Console.WriteLine("Instance crated");
            Assert.IsNotNull(testedClassificator);
            DocumentClass.addClass("zero");
            DocumentClass.addClass("jeden");
            testedClassificator.Learn(dictionary);
            //testedClassificator.Learn(

            
        }
    }
}
