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

        FixedDictionary(String sourceDir, int wordsPerCategory)
        {
            /*
            wordList = new List<string>();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo fileInfo in sourceDirInfo.GetFiles(PreprocessingConsts.CategoryFilePattern))
            {
                //wczytanie z pliku
                StreamReader sr = new StreamReader(fileInfo.FullName);
                String tmpString = sr.ReadToEnd();
                sr.Close();
                String[] 
                //posorotowanie

                //dodanie odpowiedniej ilosci - wazne, zeby sie nie powtarzaly z juz istniejacymi
            }
             */ 
        }
    }
}
