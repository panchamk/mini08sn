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


        [Test]
        public void Tests()
        {
            testedClassificator = new RadialNetwork(4, 2);
            Console.WriteLine("Instance crated");
            Assert.IsNotNull(testedClassificator);
            dictionary = new DictionaryFake(10);
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
