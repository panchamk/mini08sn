using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocClass.Src.Learning;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.Dictionaries
{
    class FixedDictionary : Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.Document> docs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// Tworzy nowy słownik na podstawie plików podsumowujących poszczególne kategorie.
        /// Z każdej kategorii trafi wordsPerCategory njaczęściej występujących, unikalnych słów.
        /// </summary>
        /// <param name="sourceDir">Katalog z plikami podsumowującymi.</param>
        /// <param name="wordsPerCategory">Ilość unikalnych słów, które mają zostać wybrane z każdej kategorii.</param>
        public FixedDictionary(String sourceDir, int wordsPerCategory)
        {
            wordList = new List<string>();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo fileInfo in sourceDirInfo.GetFiles(PreprocessingConsts.CategoryFilePattern))
            {
                List<WordCountPair> wordCountList = getSortedWordCountList(fileInfo.FullName);
                //dodanie odpowiedniej ilosci - wazne, zeby sie nie powtarzaly z juz istniejacymi
                int wordsAdded = 0;
                for (int i=0; i <wordCountList.Count && wordsAdded < wordsPerCategory; i++)
                    if (!wordList.Contains(wordCountList[i].Word))
                    {
                        wordList.Add(wordCountList[i].Word);
                        wordsAdded++;
                    }
                if (wordsAdded < wordsPerCategory)
                    throw new Exception("There are not enough words for category : " + fileInfo.Name);
            }
        }

        private List<WordCountPair> getSortedWordCountList(string fileName)
        {
            List<WordCountPair> result = new List<WordCountPair>();
            StreamReader sr = new StreamReader(fileName);
            //wczytywanie wszystkich słów
            String data = sr.ReadToEnd();
            sr.Close();
            String[] lines = data.Split(Environment.NewLine.ToCharArray()); //podział na linie
            //utworzenie listy WordCountPairów
            foreach (String tmpLine in lines)
                if (tmpLine != null && tmpLine.Length > 0)
                    result.Add(WordCountPair.Parse(tmpLine));
            //sortowanie
            result.Sort();
            result.Reverse();

            return result;
        }
    }
}
