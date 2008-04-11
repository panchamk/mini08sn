using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Preprocessing
{
    class WordCountList:IEnumerable<WordCountPair>
    {
        private List<WordCountPair> wordList;

        public WordCountList()
        {
            wordList = new List<WordCountPair>();
        }
        /// <summary>
        /// Tworzy nowy obiekt na podstawie pliku zawieraj¹cego dane postaci s³owo liczba wyst¹pieñ.
        /// </summary>
          /// <param name="fileName">Plik zawieraj¹cy dane postaci s³owo liczba wyst¹pieñ.</param>
        public WordCountList(String fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            String tmpString = sr.ReadToEnd();
            sr.Close();
            String[] splittedTmpString = tmpString.Split(Environment.NewLine.ToCharArray());
            wordList = new List<WordCountPair>();
            foreach (String line in splittedTmpString)
                if (line.Length > 0)
                    wordList.Add(WordCountPair.Parse(line));

        }
        /// <summary>
        /// Zwraca iloœæ wszystkich s³ów.
        /// </summary>
        /// <returns>Iloœæ wszystkich s³ów.</returns>
        public int GetAllWordsCount()
        {
            int result = 0;
            foreach (WordCountPair tmpPair in wordList)
                result += (int)tmpPair.Count;
            return result;
        }
        /// <summary>
        /// Zwraca iloœæ ró¿nych s³ów.
        /// </summary>
        /// <returns>Iloœæ ró¿nych s³ów</returns>
        public int GetUniqueWordsCount()
        {
            return wordList.Count;
        }


        /// <summary>
        /// Zwraca wartoœæ dla danego s³owa lub -1, jeœli s³owo nie wystêpuje.
        /// </summary>
        /// <param name="word">Szukane s³owo.</param>
        /// <returns>Wartoœæ dla danego s³owa lub -1, jeœli s³owo nie wystêpuje.</returns>
        public double this[string word]
        {
            get 
            {
                foreach (WordCountPair tmpPair in wordList)
                    if (tmpPair.Word.Equals(word))
                        return tmpPair.Count;
                return -1;
            }
        }

        public void Add(WordCountPair newPair)
        {
            wordList.Add(newPair);
        }
        #region IEnumerable<WordCountPair> Members

        public IEnumerator<WordCountPair> GetEnumerator()
        {
            for (int i = 0; i < wordList.Count; i++)
                yield return wordList[i];
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<WordCountPair>)this).GetEnumerator(); 
        }

        #endregion
    }
}
