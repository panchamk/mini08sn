using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Preprocessing
{
    class Category
    {
        private Dictionary<String, int> wordCountList;
        private String name;
        private int allWordsCount = 0;
        private int uniqueWordsCount = 0;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int AllWordsCount
        {
            get { return allWordsCount; }
        }
        public int UniqueWordsCount
        {
            get { return uniqueWordsCount; }
        }

        public Category(String fileName)
        {
            name = Path.GetFileNameWithoutExtension(fileName);
            WordCountList tmpList = new WordCountList(fileName);
            wordCountList = new Dictionary<string, int>();
            foreach (WordCountPair tmpPair in tmpList)
            {
                wordCountList.Add(tmpPair.Word, (int)tmpPair.Count);
                allWordsCount += (int)tmpPair.Count;
                uniqueWordsCount++;
            }
        }
        /// <summary>
        /// Zwraca ilo�� wyst�pie� danego s�owa lub rzuca wyj�tek KeyNotFoundExcpetion, gdy 
        /// s�owo nie wsyt�puje w kategorii.
        /// </summary>
        /// <param name="word">Szukane s�owo.</param>
        /// <returns>Ilo�� wyst�pie� danego s�owa lub rzuca wyj�tek KeyNotFoundExcpetion, gdy 
        /// s�owo nie wsyt�puje w kategorii.</returns>
        public int this[String word]
        {
            get
            {
                return wordCountList[word];
            }
        }

        /// <summary>
        /// Zwraca slownik slow oraz ich wystapien.
        /// </summary>
        public Dictionary<String, int> WordDictionary
        {
            get { return this.wordCountList; }
        }
    }
}
