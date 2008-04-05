using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    class WordCountPair : IComparable
    {
        private String word;
        private double count;

        public WordCountPair(String word, double count)
        {
            this.word = word;
            this.count = count;
        }
        public String Word
        {
            get { return word; }
            set { word = value; }
        }

        public double Count
        {
            get { return count; }
            set { count = value; }
        }
        /// <summary>
        /// Parsuje obiekt WordCountPair z tekstu.
        /// </summary>
        /// <param name="text">Tekst w postaci : s³owo, iloœæ wyst¹pieñ - rozdzielone spacj¹ np.
        /// test 5</param>
        /// <returns>Nowy obiekt klasy WordCountPair</returns>
        public static WordCountPair Parse(String text)
        {
            String[] splittedText = text.Split(' ');
            return new WordCountPair(splittedText[0], int.Parse(splittedText[1]));
        }


        #region IComparable Members

        public int CompareTo(object obj)
        {
            return count.CompareTo(((WordCountPair)obj).count);
        }

        #endregion
    }
}
