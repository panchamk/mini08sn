using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;

namespace DocClass.Src.DocumentRepresentation
{
    class PlainDocument
    {
        private List<WordCountPair> wordList;
        /// <summary>
        /// Towrzy nowy obiekt na podstawie pliku po stemmingu.
        /// </summary>
        /// <param name="fileName">Plik po stemmingu.</param>
        public PlainDocument(String fileName)
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
    }
}
