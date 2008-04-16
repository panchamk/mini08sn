using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Preprocessing
{
    class WordInfo
    {
        String word;
        int count;
        int inclDocCount;

        public WordInfo(String word, int count, int inclDocCount)
        {
            this.word = word;
            this.count = count;
            this.inclDocCount = inclDocCount;
        }
        /// <summary>
        /// Parsuje obikt WordInfo z tekstu.
        /// </summary>
        /// <param name="text">Tekst w postaci: s³owo, iloœæ wyst¹pieñ, iloœæ dokumentów oddzielone spacjami
        /// np. : test 5 2
        /// Ostatnia liczba jest opcjonalna. Jeœli nie wyst¹pi w obiekcie zsotanie przypisana wartoœæ 1.</param>
        /// <returns>Nowy obiekt klasy WordInfo</returns>
        public static WordInfo Parse(String text)
        {
            String[] splittedText = text.Split(' ');
            if (splittedText.Length >= 3)
                return new WordInfo(splittedText[0], int.Parse(splittedText[1]), int.Parse(splittedText[2]));
            if (splittedText.Length == 2)
                return new WordInfo(splittedText[0], int.Parse(splittedText[1]), 1);
            throw new Exception("Text format incorect. Text:" + text);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", word, count, inclDocCount);
        }
        /// <summary>
        /// Zwraca hash code s³owa zawartego w obiekcie.
        /// </summary>
        /// <returns>Hash code s³owa zawarty w obiekcie.</returns>
        public override int GetHashCode()
        {
            return word.GetHashCode();
        }
        /// <summary>
        /// Zwraca true, jeœli s³owa s¹ te same.
        /// </summary>
        /// <param name="obj">Obiekt do porównania.</param>
        /// <returns>True, jeœli s³owa zawarte w obiketach s¹ te same.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) 
                return false;

            WordInfo wordInfo = (WordInfo)obj;
            return word.Equals(wordInfo.word);
        }

        public String Word
        {
            get { return word; }
            set { word = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public int InclDocCount
        {
            get { return inclDocCount; }
            set { inclDocCount = value; }
        }

    }
}
