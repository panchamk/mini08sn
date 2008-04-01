using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace DocClass.Src.Classification.BayesClassificator
{
    /// <summary>
    /// Klasa implementuje wezel
    /// zawierajacy slowo oraz liczbe wystapien.
    /// </summary>
    [DebuggerDisplay("Word = {mWord}, Count = {mCount}")]
    public class Node
    {
        #region Fields

        /// <summary>
        /// Slowo kategorii.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string mWord;

        /// <summary>
        /// Liczba wystapien slowa.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int mCount;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor jednoparametrowy.
        /// </summary>
        /// <param name="word">Slowo z kategorii.</param>
        public Node(String word)
        {
            this.mWord = word;
            this.mCount = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Zwraca slowo z kategorii.
        /// </summary>
        public String Word
        {
            get { return this.mWord; }
        }

        /// <summary>
        /// Pobiera lub ustawie liczbe wystopien
        /// danego slowa w kategorii.
        /// </summary>
        public int Count
        {
            get { return this.mCount; }
            set { this.mCount = value; }
        }

        #endregion

        #region Override Methods

        public override bool Equals(object obj)
        {
            Node node = obj as Node;
            if (node == null) 
                return false;

            return this.mCount.Equals(node.mCount) && this.mWord.Equals(node.mWord);
        }

        public override int GetHashCode()
        {
            return this.mWord.GetHashCode() + this.mCount.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Słowo: " + this.mWord);
            builder.AppendLine("Liczba wystapien: " + this.mCount);
            return builder.ToString();
        }

        #endregion
    }
}
