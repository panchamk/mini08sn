using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Dictionaries
{
    class FrequentDictionary : Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.IDocument> docs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public FrequentDictionary(String summaryFile, int size)
        {
            List<WordCountPair> wordList = new List<WordCountPair>();
            StreamReader sr = new StreamReader(summaryFile);
            String tmpLine;
            //wczytywanie kolejnych słów
            while ((tmpLine = sr.ReadLine()) != null)
            {
                String[] splittedLine = tmpLine.Split(' ');
                WordCountPair tmpPair = new WordCountPair(splittedLine[0], int.Parse(splittedLine[1]));
                //sortowanie przez wstawianie
                int index;
                for (index = 0; index < wordList.Count; index++)
                    if (tmpPair.Count > wordList[index].Count)
                        break;
                wordList.Insert(index,tmpPair);
            }
            sr.Close();
            this.wordList = new List<string>();
            for (int i = 0; i < Math.Min(wordList.Count, size); i++)
                this.wordList.Add(wordList[i].Word);
        }
    }
}
