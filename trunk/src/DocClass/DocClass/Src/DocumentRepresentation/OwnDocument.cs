using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Classification;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.DocumentRepresentation
{
    class OwnDocument : Document
    {
        

        /// <summary>
        /// Tworzy dokument na podstawie wcześniej przygotowanego pliku.
        /// </summary>
        /// <param name="fileName">Plik z danymi.</param>
        /// <param name="dictionary">Słownik, na podstawie którego tworzony jest dokument.</param>
        /// <param name="className">Nazwa klasy, do której należy dany dokument lub null, jeśli klasa jest nieznana.</param>
        public OwnDocument(String fileName, Dictionary dictionary, String className)
        {
            wordCountList = new WordCountList();
            if (className != null)
                ClassNo = DocumentClass.CategoriesCount;

            WordCountList listFromFile = new WordCountList(fileName);
            foreach (String word in dictionary)
                if (listFromFile[word] != -1)
                    wordCountList.Add(new WordCountPair(word,listFromFile[word]/listFromFile.GetAllWordsCount()));
                else
                    wordCountList.Add(new WordCountPair(word, 0));
        }

       
    }
}
