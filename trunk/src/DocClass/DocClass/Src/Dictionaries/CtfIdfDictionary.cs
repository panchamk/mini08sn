using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Preprocessing;
using System.IO;

namespace DocClass.Src.Dictionaries
{
    class CtfIdfDictionary : Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.Document> docs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// Tworzy nowy słownik.
        /// </summary>
        /// <param name="sourceDir">Katalog zawierający wszystkie pliki uczące.</param>
        /// <param name="summaryFile">Plik z podsumowaniem wszystkich plików.</param>
        /// <param name="size">Ilość słów w słowniku</param>
        public CtfIdfDictionary(String sourceDir, String summaryFile, int size)
        {
            Dictionary<String, WordCountPair> tmpDictionary = new Dictionary<string, WordCountPair>();
            //wczytanie informacji o wszystkich słowach
            LearningDocInfo learningDocInfo = new LearningDocInfo(sourceDir,summaryFile);
            Dictionary<String, WordInfo> allWords = learningDocInfo.AllWordsInfo;
            int allDocCount = learningDocInfo.AllDocCount;
            //tworzenie słownika
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (DirectoryInfo dirInfo in sourceDirInfo.GetDirectories()) //przechodzę po wszystkich podkatalogach
            {
                DirectoryInfo stemDir = new DirectoryInfo(dirInfo.FullName + "//stem");
                foreach (FileInfo fileInfo in stemDir.GetFiles()) //przechodzę po wszystkich plikach
                {
                    WordCountList wordsInFile = new WordCountList(fileInfo.FullName);
                    int wordsInDocCount = wordsInFile.GetAllWordsCount();
                    foreach (WordCountPair wordCountPair in wordsInFile) //przechodzę po wszsytkich słowach
                    {
                        double tfIdf = PreprocessingUtility.ComputeTfIdf(wordCountPair.Count,wordsInDocCount,allDocCount,allWords[wordCountPair.Word].InclDocCount);
                        if (tmpDictionary.ContainsKey(wordCountPair.Word))
                            tmpDictionary[wordCountPair.Word].Count += tfIdf;
                        else
                            tmpDictionary.Add(wordCountPair.Word, new WordCountPair(wordCountPair.Word, tfIdf));
                    }
                }
            }
            //wybranie odpowiednich słów 
            WordCountPair[] tmpArray = new WordCountPair[tmpDictionary.Count];
            tmpDictionary.Values.CopyTo(tmpArray, 0);
            Array.Sort(tmpArray);
            Array.Reverse(tmpArray);
            //kopiowanie do właściwej listy
            wordList = new List<string>();
            for (int i = 0; i < size; i++)
                wordList.Add(tmpArray[i].Word);
        }
    }
}
