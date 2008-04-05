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
        /// <summary>
        /// Tworzy nowy słownik na podstawie pliku podsumowującego wszsytkie kategorie.
        /// </summary>
        /// <param name="summaryFile">Nazwa pliku zawierającego podsumowanie wszsytkich kategorii.</param>
        /// <param name="size">Rozmiar słownika - ilość słów w słowniku.</param>
        public FrequentDictionary(String summaryFile, int size)
        {

            List<WordCountPair> wordList = new List<WordCountPair>();
            StreamReader sr = new StreamReader(summaryFile);
            String tmpLine;
            //wczytywanie kolejnych słów
            long linesCount = 0;
            while ((tmpLine = sr.ReadLine()) != null)
                linesCount++;
            sr.Close();
            sr = new StreamReader(summaryFile);
            long currentLine = 0;
            while ((tmpLine = sr.ReadLine()) != null)
            {
                currentLine++;
                Console.WriteLine(currentLine +"/" + linesCount);
                
                String[] splittedLine = tmpLine.Split(' ');
                WordCountPair tmpPair = new WordCountPair(splittedLine[0], int.Parse(splittedLine[1]));
                wordList.Add(tmpPair);
            }
             
            sr.Close();
            wordList.Sort();
            wordList.Reverse();
            this.wordList = new List<string>();
            for (int i = 0; i < Math.Min(wordList.Count, size); i++)
                this.wordList.Add(wordList[i].Word);
        }
    }
}
