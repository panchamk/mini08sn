using System;
using System.Text;
using System.Diagnostics;
using DocClass.Src.Learning;
using DocClass.Src.Dictionaries;
using System.Collections.Generic;
using DocClass.Src.Classification;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.BayesClassificator
{
    /// <summary>
    /// Klasa implementuje naiwny klasyfikator Bayes'a.
    /// </summary>
    [DebuggerDisplay("Categories Count = {mKey}")]
    class BayesClassificator : Classificator, IDisposable
    {
        #region PrivateFields

        /// <summary>
        /// Lista kategorii.
        /// </summary>
        private Dictionary<int, Category> categories;

        /// <summary>
        /// Klucz do iterowania kategorii.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int mKey = 0;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor bezargumentowy.
        /// </summary>
        public BayesClassificator()
        {
            this.categories = new Dictionary<int, Category>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Funkcja wylicza wszystkie slowa znajdujace sie we 
        /// wszystkich kategoriach.
        /// </summary>
        /// <returns>Liczbe wszystkich slow.</returns>
        public int AllWordsInCategories
        {
            get
            {
                if (this.categories == null || this.categories.Count == 0)
                    return 0;

                int total = 0;
                foreach (KeyValuePair<int, Category> category in this.categories)
                    total += category.Value.TotalWords;
                return total;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Metoda uczaca. Dla danego typu wczytuje wszystkie pliki.
        /// </summary>
        /// <param name="dict">Parametr lest lista plikow danej kategorii. Jedna kategoria
        /// moze zawierac wiele plikow.</param>
        /// <returns>Zwraca true, jesli dane sa poprawne.</returns>
        public override bool Learn(DocumentList docList ) //Dictionary dict)
        {
            //TODO: MZ - przystosuj do danych czerpanych z DocumentList
            /*
            if (dict == null || dict.DataVectors == null || dict.DataVectors.Count == 0)
                return false;

            Category category = new Category();
            foreach (LearningPair pair in dict.DataVectors)
            {
                category.Learn(pair.Map);
            }
            this.categories.Add(this.mKey, category);
            this.mKey++;
             * */
            return true;
        }

        /// <summary>
        /// Metody nieuzywane.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override int Classificate(Document doc)
        {
            return 0;
        }

        /// <summary>
        /// Metody Nieuzywane.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public override int Classificate(double[] vector)
        {
            return 0;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Kolekcja slow ze sprawdzanego tekstu.
        /// </summary>
        /// <param name="collection">Dowolna kolekcja slow.</param>
        /// <returns>Zwraca indeks kategorii do ktorej nalezy sprawdzany tekst.</returns>
        /// <remarks>Uwaga: funkcja zwraca indeks kategorii w porzadku uczenia.
        /// Czyli jesli kategoria "Religia" byla trzecia kategoria uczaca i dany tekst bedzie(wedlug klasyfikatora)
        /// nalezal do kategorii  "Religia", to zwroci wartosc 3.</remarks>
        public int Classificate(ICollection<String> collection)
        {
            double count = 0, allWords;
            double[] score = new double[this.categories.Count];
            foreach (String strWord in collection)
                foreach (KeyValuePair<int, Category> cat in this.categories)
                {
                    count = cat.Value.GetWordsCount(strWord);
                    if (0 < count)
                        score[cat.Key] += Math.Log(count / (double)cat.Value.TotalWords);
                    else
                        score[cat.Key] += Math.Log(0.01 / (double)cat.Value.TotalWords);
                }
            allWords = AllWordsInCategories;
            foreach (KeyValuePair<int, Category> cat in this.categories)
                score[cat.Key] += Math.Log((double)cat.Value.TotalWords / (double)allWords);

            return GetMaxIndex(score);
        }

        /// <summary>
        /// Metoda uczaca.
        /// </summary>
        /// <param name="dict">Parametr lest lista slow danej kategorii.</param>
        /// <returns>Zwraca true, jesli dane sa poprawne.</returns>
        public bool Learn(ICollection<String> dict)
        {
            if (dict == null || dict.Count == 0)
                return false;

            Category category = new Category();
            Dictionary<String, double> strDict = new Dictionary<String, double>();
            foreach (String word in dict)
                strDict.Add(word, 0);
            category.Learn(strDict);
            this.categories.Add(this.mKey, category);
            this.mKey++;
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Funkcja zwraca indeks najwiekszego pola w tablicy.
        /// </summary>
        /// <param name="vect">Tablica.</param>
        /// <returns>Indeks najwiekszego pola.</returns>
        private int GetMaxIndex(double[] vect)
        {
            if(vect == null || vect.Length == 0)
                throw new ArgumentException("vect");

            int index = 0;
            double max = Double.MinValue;
            for (int i = 0; i < vect.Length; i++)
            {
                if (vect[i] > max)
                {
                    max = vect[i];
                    index = i;
                }
            }
            return index;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Zwraca zaalokowane wczesniej zasoby.
        /// </summary>
        public void Dispose()
        {
            if (this.categories != null)
            {
                this.categories.Clear();
                this.categories = null;
            }
            this.mKey = 0;
        }

        #endregion
    }
}
