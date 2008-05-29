using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Klasa zawieraj�ca informacje o dokumentach ucz�cych.
    /// Pozwala uzyska� informacje ilo�ci wszystkich dokument�w ucz�cych a tak�e o wszystkich s�owach
    /// we wszystkich dokumentach ucz�cych. 
    /// </summary>
    [Serializable]
    class LearningDocInfo
    {
        private Dictionary<String, WordInfo> allWordsInfo;
        private int allDocCount;
        private String sourceDir;

        public String SourceDir
        {
            get { return sourceDir; }
        }
        /// <summary>
        /// Tworzy nowy obiekt klasy LearningDocInfo.
        /// UWAGA Tworzenie tego obiektu jest stosukowo d�ugie. Nale�y stara� si� obiekt tej klasy tylko raz
        /// i przechowywa� referencj� do niego tak d�ugo jak jest potrzebna.
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj�cy wszystkie dane ucz�ce.</param>
        /// <param name="summaryFile">Plik zawieraj�cy informacje o wszystkich s�owach ze wszystkich dokument�w.</param>
        public LearningDocInfo(String sourceDir, String summaryFile)
        {
            this.sourceDir = sourceDir;

            //tworz� s�ownik informacji o wszystkich s�owach
            allWordsInfo = new Dictionary<string, WordInfo>();
            StreamReader sr = new StreamReader(summaryFile);
            String data = sr.ReadToEnd();
            sr.Close();
            String[] dataLines = data.Split(Environment.NewLine.ToCharArray());
            foreach (String dataLine in dataLines)
                if (dataLine.Length > 0)
                {
                    WordInfo wordInfo = WordInfo.Parse(dataLine);
                    allWordsInfo.Add(wordInfo.Word, wordInfo);
                }
            //licz� ilo�� wszystkich dokument�w
            allDocCount = 0;
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (DirectoryInfo dirInfo in sourceDirInfo.GetDirectories())
                allDocCount += dirInfo.GetFiles().Length;
            
        }
        /// <summary>
        /// Zwraca list� informacji o s�owach.
        /// </summary>
        public Dictionary<String, WordInfo> AllWordsInfo
        {
            get { return allWordsInfo; }
        }
        /// <summary>
        /// Zwraca ilo�� wszystkich dokument�w.
        /// </summary>
        public int AllDocCount
        {
            get { return allDocCount; }
        }

    }
}
