using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Klasa zawieraj¹ca informacje o dokumentach ucz¹cych.
    /// Pozwala uzyskaæ informacje iloœci wszystkich dokumentów ucz¹cych a tak¿e o wszystkich s³owach
    /// we wszystkich dokumentach ucz¹cych. 
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
        /// UWAGA Tworzenie tego obiektu jest stosukowo d³ugie. Nale¿y staraæ siê obiekt tej klasy tylko raz
        /// i przechowywaæ referencjê do niego tak d³ugo jak jest potrzebna.
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj¹cy wszystkie dane ucz¹ce.</param>
        /// <param name="summaryFile">Plik zawieraj¹cy informacje o wszystkich s³owach ze wszystkich dokumentów.</param>
        public LearningDocInfo(String sourceDir, String summaryFile)
        {
            this.sourceDir = sourceDir;

            //tworzê s³ownik informacji o wszystkich s³owach
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
            //liczê iloœæ wszystkich dokumentów
            allDocCount = 0;
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (DirectoryInfo dirInfo in sourceDirInfo.GetDirectories())
                allDocCount += dirInfo.GetFiles().Length;
            
        }
        /// <summary>
        /// Zwraca listê informacji o s³owach.
        /// </summary>
        public Dictionary<String, WordInfo> AllWordsInfo
        {
            get { return allWordsInfo; }
        }
        /// <summary>
        /// Zwraca iloœæ wszystkich dokumentów.
        /// </summary>
        public int AllDocCount
        {
            get { return allDocCount; }
        }

    }
}
