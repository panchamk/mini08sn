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
        /// Zwraca iloœæ wyst¹pieñ danego s³owa lub rzuca wyj¹tek KeyNotFoundExcpetion, gdy 
        /// s³owo nie wsytêpuje w kategorii.
        /// </summary>
        /// <param name="word">Szukane s³owo.</param>
        /// <returns>Iloœæ wyst¹pieñ danego s³owa lub rzuca wyj¹tek KeyNotFoundExcpetion, gdy 
        /// s³owo nie wsytêpuje w kategorii.</returns>
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
