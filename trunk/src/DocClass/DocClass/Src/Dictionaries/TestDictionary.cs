using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Dictionaries
{
    class TestDictionary:Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.Document> docs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// Tworzy s�ownik wczytany bezpo�rednio z pliku.
        /// </summary>
        /// <param name="fileName">�cie�ka do pliku, ka�de s�owo w pliku powinno by� w nowej linii.</param>
        public TestDictionary(String fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            //wczytywanie wszystkich s��w
            String data = sr.ReadToEnd();
            sr.Close();
            String[] lines = data.Split(Environment.NewLine.ToCharArray()); //podzia� na linie
            //utworzenie listy slow
            this.wordList = new List<string>();
            foreach (String tmpLine in lines)
                if (tmpLine != null && tmpLine.Length > 0)
                    this.wordList.Add(tmpLine);

        }
    }
}
