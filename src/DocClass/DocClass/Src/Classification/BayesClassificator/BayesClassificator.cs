using System;
using System.Text;
using System.Diagnostics;
using DocClass.Src.Learning;
using DocClass.Src.Dictionaries;
using System.Collections.Generic;
using DocClass.Src.Classification;
using DocClass.Src.DocumentRepresentation;
using System.ComponentModel;
using DocClass.Src.Preprocessing;

using BayesCategory = DocClass.Src.Classification.BayesClassificator.Category;
using System.Collections.Specialized;

public delegate void ProgressChangedHandler();

namespace DocClass.Src.Classification.BayesClassificator
{
    /// <summary>
    /// Klasa implementuje naiwny klasyfikator Bayes'a.
    /// </summary>
    [Serializable]
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

        /// <summary>
        /// Watek wykonujacy klasyfikacje.
        /// </summary>
        [NonSerialized]
        private BackgroundWorker mOwner;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor bezargumentowy.
        /// </summary>
        public BayesClassificator()
            : this(null)
        { }

        /// <summary>
        /// Konstruktor jednoparametrowy.
        /// </summary>
        /// <param name="owner">Watek wykonujacy.</param>
        public BayesClassificator(BackgroundWorker owner)
        {
            this.categories = new Dictionary<int, Category>();
            this.mOwner = owner;
        }

        #endregion

        #region Events

        public event ProgressChangedHandler ProgressChange;

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
        public override bool Learn(Object obj ) //Dictionary dict)
        {
            if (obj == null)
                throw new ArgumentNullException("Argument jest null-em !");
            if (!(obj is CategoryList))
                throw new ArgumentException("Argument nie jest typu CategoryList!");

            CategoryList catList = obj as CategoryList; 
            int count = catList.CategoryCount, iter = 0;
            for(int i = 0; i < catList.CategoryCount; i++)
            {
                BayesCategory bayesCategory = new BayesCategory();
                bayesCategory.ProgressCategoryChange += new ProgressChangedCategoryHandler(category_ProgressCategoryChange);
                bayesCategory.Name = catList[i].Name;
                bayesCategory.Learn(catList[i].WordDictionary);
                this.categories.Add(catList[i].Name.GetHashCode(), bayesCategory);
            }

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
        public string Classificate(ICollection<String> collection)
        {
            double count = 0, allWords;
            
            Dictionary<String, double> score = new Dictionary<String, double>();

            foreach (KeyValuePair<int, Category> cat in this.categories)
                score.Add(cat.Value.Name, 0);

            foreach (String strWord in collection)
                foreach (KeyValuePair<int, Category> cat in this.categories)
                {
                    count = cat.Value.GetWordsCount(strWord);
                    if (0 < count)
                        score[cat.Value.Name] += Math.Log(count / (double)cat.Value.TotalWords);
                    else
                        score[cat.Value.Name] += Math.Log(0.01 / (double)cat.Value.TotalWords);
                }

            allWords = AllWordsInCategories;
            foreach (KeyValuePair<int, Category> cat in this.categories)
                score[cat.Value.Name] += Math.Log((double)cat.Value.TotalWords / (double)allWords);

            return GetCategory(score);
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
            Dictionary<String, int> strDict = new Dictionary<String, int>();  
            foreach (String word in dict)
            {
                strDict.Add(word, 0);
            }
            category.Learn(strDict);
            this.categories.Add(this.mKey, category);
            this.mKey++;
            return true;
        }

        void category_ProgressCategoryChange()
        {
            if (this.ProgressChange != null)
                ProgressChange();
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

        /// <summary>
        /// Znajduje kategorie, ktora w slowniku ma najwieksza wartosc.
        /// </summary>
        /// <param name="dictionary">Slownik kategorii.</param>
        /// <returns>Kategorie o najwiekszej wartosci.</returns>
        private string GetCategory(Dictionary<String, double> dictionary)
        {
            string category = String.Empty;
            double tmpVal = Double.MinValue;
            foreach (KeyValuePair<String, double> cat in dictionary)
                if (cat.Value > tmpVal)
                {
                    tmpVal = cat.Value;
                    category = cat.Key;
                }

            return category;
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
