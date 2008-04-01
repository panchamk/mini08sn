using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    class WordCountPair
    {
        private String word;
        private int count;

        public WordCountPair(String word, int count)
        {
            this.word = word;
            this.count = count;
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

    }
}
