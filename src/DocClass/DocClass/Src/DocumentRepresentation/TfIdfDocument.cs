using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.Collections;
using System.IO;
using DocClass.Src.Preprocessing;
using DocClass.Src.Classification;

namespace DocClass.Src.DocumentRepresentation
{
    class TfIdfDocument : Document
    {
        

        /// <summary>
        /// Tworzy dokument na podstawie wcześniej przygotowanego pliku.
        /// </summary>
        /// <param name="fileName">Plik z danymi.</param>
        /// <param name="dictionary">Słownik, na podstawie którego tworzony jest dokument.</param>
        /// <param name="className">Nazwa klasy, do której należy dany dokument lub null, jeśli klasa jest nieznana.</param>
        /// <param name="learningDocInfo">Obiekt zawierający informacje o wszystkich dokumentach uczących.</param>
        public TfIdfDocument(String fileName, Dictionary dictionary, String className, LearningDocInfo learningDocInfo)
            : base(dictionary)
        {
            wordCountList = new WordCountList();
            if (className != null)
                classNo = DocumentClass.GetClassIndex(className);
            //tworze liste wszystkich słów ze wszystkuch dokumentów
            Dictionary<String, WordInfo> allWordsInfo = learningDocInfo.AllWordsInfo;
            double allDocNumber = learningDocInfo.AllDocCount;
            //tworze liste słów w dokumencie
            WordCountList wordsInDoc = new WordCountList(fileName);

            int wordsInDocCount = wordsInDoc.GetAllWordsCount();
            foreach (String word in dictionary)
                if (wordsInDoc[word] != -1)
                {
                    double inclDocCount = allWordsInfo[word].InclDocCount;
                    //double tfIdf = (wordsInDoc[word] / wordsInDocCount) * Math.Log10(allDocNumber/inclDocCount);
                    double tfIdf = PreprocessingUtility.ComputeTfIdf(wordsInDoc[word], wordsInDocCount, allDocNumber, inclDocCount);
                    wordCountList.Add(new WordCountPair(word, tfIdf));
                }
                else
                    wordCountList.Add(new WordCountPair(word, 0));

        }

    }
}
