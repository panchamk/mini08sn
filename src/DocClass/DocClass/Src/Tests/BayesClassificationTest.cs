using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using DocClass.Src.Classification;
using DocClass.Src.Classification.BayesClassificator;

namespace DocClass.Src.Tests
{
    [TestFixture]
    class BayesClassificationTest
    {
        [Test]
        public static void Test()
        {
            string[] boys = new String[] { "Michal", "Pawel", "Jan", "Wiktor", "Zbigniew", "Emil", "Tomek" };
            string[] girls = new String[] { "Wika", "Ania", "Aga", "Joanna", "Gosia", "Iwona" };
            string[] testBoys = new String[] { "Michal", "Jan", "Andrzej", "Tomek" };
            string[] testGirls = new String[] { "Wika", "Ania", "Joanna", "Ilona" };
            string[] testDiferent = new String[] { "Wika", "Ania", "Joanna", "Ilona", "Tomek", "Gosia" };

            BayesClassificator bayes = new BayesClassificator();
            Console.WriteLine("Uczy sie imion chlopcow ....");
            bayes.Learn(boys);//index 0
            Console.WriteLine("Uczy sie imion dziewczyn ...");
            bayes.Learn(girls);//index 1
            int test = bayes.Classificate(testBoys);
            if (test == 0) Console.WriteLine("Zgadl !. To naprawde imiona chlopcow.");
            else Console.WriteLine("Niestety. Prawidlowa odpowiedz: imiona chlopcow !");
            test = bayes.Classificate(testGirls);
            if (test == 1) Console.WriteLine("Zgadl !. To naprawde imiona dziewczyn.");
            else Console.WriteLine("Niestety. Prawidlowa odpowiedz: imiona dziewczyn !");
            test = bayes.Classificate(testDiferent);
            if (test == 1) Console.WriteLine("Mysli ze to imiona dziewczyn.");
            else if (test == 0) Console.WriteLine("Mysli ze to imiona chlopcow.");
        }
    }
}
