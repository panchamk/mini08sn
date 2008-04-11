using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using DocClass.Src.Preprocessing;
using DocClass.Src.Classification;

namespace DocClass.Src.DocumentRepresentation
{
    class BinaryDocument : Document
    {
        /// <summary>
        /// Tworzy dokument na podstawie wcześniej przygotowanego pliku.
        /// </summary>
        /// <param name="fileName">Plik z danymi.</param>
        /// <param name="dictionary">Słownik, na podstawie którego tworzony jest dokument.</param>
        /// <param name="className">Nazwa klasy, do której należy dany dokument lub null, jeśli klasa jest nieznana.</param>
        public BinaryDocument(String fileName, Dictionary dictionary, String className)
        {
            wordCountList = new WordCountList();
            if (className != null)
                ClassNo = DocumentClass.CategoriesCount;

            WordCountList listFromFile = new WordCountList(fileName);
            foreach (String word in dictionary)
                if (listFromFile[word] != -1)
                    wordCountList.Add(new WordCountPair(word, 1));
                else
                    wordCountList.Add(new WordCountPair(word, 0));

        }
    }
}
