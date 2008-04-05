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
    }
}
