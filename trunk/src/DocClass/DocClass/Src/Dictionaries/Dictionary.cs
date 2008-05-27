using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Learning;
using DocClass.Src.Classification;

namespace DocClass.Src.Dictionaries
{
    [Serializable]
    abstract class Dictionary:IEnumerable<String>
    {

        //int GetDesiredOutput();
        abstract public bool Init(ICollection<Document> docs);

        protected List<String> wordList;

        public DictionaryType GetDictionaryType()
        {
            Type myType = GetType();
            if (myType == typeof(CtfIdfDictionary))
                return DictionaryType.CtfIdf;
            if (myType == typeof(FixedDictionary))
                return DictionaryType.Fixed;
            if (myType == typeof(FrequentDictionary))
                return DictionaryType.Frequent;
            throw new Exception("Unknown type: " + myType);
        }
        /// <summary>
        /// Zwraca listę słów należących do słownika oddzieloną spacjami.
        /// </summary>
        /// <returns>należących do słownika oddzieloną spacjami.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String word in wordList)
            {
                sb.Append(word);
                sb.Append(' ');
            }
            return sb.ToString();
        }

        public int GetWordIndex(String word)
        {
            return wordList.IndexOf(word);
        }

        public String this[int index]
        {
            get
            {
                return wordList[index];
            }
        }

        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < wordList.Count; i++)
                yield return wordList[i];
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)this).GetEnumerator();
        }

        #endregion
    }
}
