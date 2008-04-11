using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.Dictionaries
{
    class FrequentDictionary : Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.Document> docs)
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
            //wczytywanie wszystkich słów
            String data = sr.ReadToEnd();
            sr.Close();
            String[] lines = data.Split(Environment.NewLine.ToCharArray()); //podział na linie
            //utworzenie listy WordCountPairów
            foreach (String tmpLine in lines)
                if (tmpLine != null && tmpLine.Length > 0)
                    wordList.Add(WordCountPair.Parse(tmpLine));
            //sortowanie
            wordList.Sort();
            wordList.Reverse();
            //przepisanie do listy słów
            this.wordList = new List<string>();
            for (int i = 0; i < Math.Min(wordList.Count, size); i++)
                this.wordList.Add(wordList[i].Word);
        }
    }
}
