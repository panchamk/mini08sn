using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Classification;

namespace DocClass.Src.DocumentRepresentation
{
    class OwnDocument : IDocument
    {
        private int ClassNo = -1;
        private List<WordCountPair> wordCountList;

        #region IDocument Members

        public int GetSpaceDimensionNumber()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Dictionary<string, double> ToMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool AddWord(string word)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DesiredOutput
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
        /// <summary>
        /// Tworzy dokument na podstawie wcześniej przygotowanego pliku.
        /// </summary>
        /// <param name="fileName">Plik z danymi.</param>
        /// <param name="dictionary">Słownik, na podstawie którego tworzony jest dokument.</param>
        /// <param name="className">Nazwa klasy, do której należy dany dokument lub null, jeśli klasa jest nieznana.</param>
        public OwnDocument(String fileName, Dictionary dictionary, String className)
        {
            int allWords = 0;
            wordCountList = new List<WordCountPair>(dictionary.Size);
            if (className != null)
                ClassNo = DocumentClass.CategoriesCount;

            StreamReader sr = new StreamReader(fileName);
            //dodanie odpowiednich słów i ilości wystąpień do listy 
            String tmpLine;
            while ((tmpLine = sr.ReadLine()) != null)
            {
                WordCountPair wordCountPair = WordCountPair.Parse(tmpLine);
                allWords += (int)wordCountPair.Count;
                int wordIndex = dictionary.GetWordIndex(wordCountPair.Word);
                if (wordIndex != -1)
                    wordCountList.Add(wordCountPair);
            }
            sr.Close();
            //podzielenie każdej wartości przez liczbę słów w dokumencie
            foreach (WordCountPair wordCountPair in wordCountList)
                wordCountPair.Count /= allWords;
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WordCountPair wordCountPair in wordCountList)
                sb.AppendFormat("{0} {1:#.##}\n", wordCountPair.Word, wordCountPair.Count);

            return sb.ToString();
        }
    }
}
