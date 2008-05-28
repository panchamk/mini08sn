using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace DocClass.Src.Classification.BayesClassificator
{
    public delegate void ProgressChangedCategoryHandler();

    /// <summary>
    /// Klasa implementuje kategorie pliku,
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Exists Words Count = {mExistsWords.Count}, Total Words = {mTotalWords}")]
    public class Category : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// Lista zawierajaca slowa znajdujace sie w kategorii.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<Node> mExistsWords;

        /// <summary>
        /// Liczba wszystkich slow w kategorii.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int mTotalWords;

        /// <summary>
        /// Nazwa kategorii.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string mName;

        #endregion

        #region Events

        public event ProgressChangedCategoryHandler ProgressCategoryChange;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor bezparametrowy.
        /// </summary>
        public Category()
        {
            this.mExistsWords = new List<Node>();
            this.mTotalWords = 0;
            this.mName = String.Empty;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Zwraca liczbe slow znajdujacych sie w danej kategorii.
        /// </summary>
        public int TotalWords
        {
            get { return this.mTotalWords; }
        }

        /// <summary>
        /// Zwraca lite obiektow zawierajacych slowo oraz liczbe jego wsytapien 
        /// w danej kategorii.
        /// </summary>
        public List<Node> ExistsWords
        {
            get { return this.mExistsWords; }
        }

        /// <summary>
        /// Pobiera lub ustawia nazwe kategorii.
        /// </summary>
        public string Name
        {
            get { return this.mName; }
            set { this.mName = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Zwraca liczbe wystapien danego slowa w kategorii.
        /// </summary>
        /// <param name="word">Slowo kture wyszukujemy.</param>
        /// <returns>Liczba wystapien danego slowa w kategorii.</returns>
        public int GetWordsCount(string word)
        {
            if (this.mExistsWords.Count > 0)
            {
                Node node = this.mExistsWords.Find(Predicates.GetForWord(word));
                if (node != null)
                    return node.Count;
            }
            return 0;
        }

        /// <summary>
        /// Czysci kategorie.
        /// </summary>
        public void Clear()
        {
            this.mExistsWords.Clear();
            this.mTotalWords = 0;
        }

        /// <summary>
        /// Kategoria zapamietuje slowa, nalezace do niej.
        /// </summary>
        /// <param name="words">Slowa definiujace kategorie.</param>
        public void Learn(Dictionary<String, int> words)
        {
            foreach (KeyValuePair<String, int> w in words)
            {
                Node node;
                if (!TryGetValue(w.Key, out node))
                {
                    node = new Node(w.Key);
                    node.Count = w.Value;
                    this.mExistsWords.Add(node);
                }
                else
                    node.Count++;
                this.mTotalWords++;

                if (this.ProgressCategoryChange != null)
                    ProgressCategoryChange();
            }
        }

        /// <summary>
        /// Zwraca obiekt zwiazany z podanym kluczem.
        /// </summary>
        /// <param name="word">Klucz definiujacy obiekt.</param>
        /// <param name="node">Obiekt zwiazany z kluczem.</param>
        /// <returns>true, jesli jakis obiekt jest zwizany z kluczem; false w przeciwnym przypadku(obiekt node jest null).</returns>
        private bool TryGetValue(string word, out Node node)
        {
            if (this.mExistsWords.Count > 0)
            {
                node = this.mExistsWords.Find(Predicates.GetForWord(word));
                return node != null;
            }
            node = null;
            return false;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Zwalnia zaalokowane zasoby.
        /// </summary>
        public void Dispose()
        {
            if (this.mExistsWords != null)
            {
                this.mExistsWords.Clear();
                this.mExistsWords = null;
            }
            this.mTotalWords = 0;
        }

        #endregion
    }
}
