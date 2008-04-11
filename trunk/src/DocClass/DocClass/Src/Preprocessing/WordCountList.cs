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
        /// Tworzy nowy obiekt na podstawie pliku zawieraj�cego dane postaci s�owo liczba wyst�pie�.
        /// </summary>
          /// <param name="fileName">Plik zawieraj�cy dane postaci s�owo liczba wyst�pie�.</param>
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
        /// Zwraca ilo�� wszystkich s��w.
        /// </summary>
        /// <returns>Ilo�� wszystkich s��w.</returns>
        public int GetAllWordsCount()
        {
            int result = 0;
            foreach (WordCountPair tmpPair in wordList)
                result += (int)tmpPair.Count;
            return result;
        }
        /// <summary>
        /// Zwraca ilo�� r�nych s��w.
        /// </summary>
        /// <returns>Ilo�� r�nych s��w</returns>
        public int GetUniqueWordsCount()
        {
            return wordList.Count;
        }


        /// <summary>
        /// Zwraca warto�� dla danego s�owa lub -1, je�li s�owo nie wyst�puje.
        /// </summary>
        /// <param name="word">Szukane s�owo.</param>
        /// <returns>Warto�� dla danego s�owa lub -1, je�li s�owo nie wyst�puje.</returns>
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
