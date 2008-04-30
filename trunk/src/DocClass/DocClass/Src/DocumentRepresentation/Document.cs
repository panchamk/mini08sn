using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Preprocessing;
using DocClass.Src.Dictionaries;

namespace DocClass.Src.DocumentRepresentation
{
    abstract class Document
    {
        protected int ClassNo = -1;
        protected WordCountList wordCountList;
        protected DictionaryType dictionaryType;

        protected Document(Dictionary dictionary)
        {
            dictionaryType = dictionary.GetDictionaryType();
        }
        public DictionaryType DictionaryType
        {
            get { return dictionaryType; }
        }

        public DocumentRepresentationType GetDocumentRepresentationType()
        {
            Type myType = GetType();
            if (myType == typeof(BinaryDocument))
                return DocumentRepresentationType.Binary;
            if (myType == typeof(OwnDocument))
                return DocumentRepresentationType.Own;
            if (myType == typeof(TfIdfDocument))
                return DocumentRepresentationType.TfIdf;
            throw new Exception("Unknown type: " + myType);
            
        }
        /// <summary>
        /// Zwraca listê wartoœci. Jeœli nie ma ¿adnych wartoœci to zwraca pust¹ listê.
        /// </summary>
        /// <returns>Lista wartoœci lub pusta lista.</returns>
        public  List<double> GetValues()
        {
            List<double> result = new List<double>();
            foreach (WordCountPair wordCountPair in wordCountList)
                result.Add(wordCountPair.Count);
            return result;
        }
 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WordCountPair wordCountPair in wordCountList)
                sb.AppendFormat("{0} {1}\n", wordCountPair.Word, wordCountPair.Count);

            return sb.ToString();
        }
    }
}
