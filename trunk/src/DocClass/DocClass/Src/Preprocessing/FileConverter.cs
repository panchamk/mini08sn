using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DocClass.Src.Preprocessing
{
    class FileConverter
    {
        /// <summary>
        /// Zwraca listê s³ów ³adowan¹ z pliku.
        /// </summary>
        /// <param name="fileName">Plik z list¹ plików. Ka¿de s³owo powinno byæ w nowej linii.</param>
        /// <returns>Lista s³ów, ka¿de pisane ma³ymi literami.</returns>
        public static Dictionary<int, String> LoadStopWords(String fileName)
        {
            Dictionary<int, String> stopWords = new Dictionary<int,String>();
            StreamReader sr = new StreamReader(fileName); 
            String tmpLine;
            while ((tmpLine = sr.ReadLine()) != null)
            {
                tmpLine.Trim();
                tmpLine = tmpLine.ToLower();
                stopWords.Add(tmpLine.GetHashCode(), tmpLine);
            }
            sr.Close();
            return stopWords;
        }
        /// <summary>
        /// Wykonuje stemming wszystkich s³ów w danym pliku pomijaj¹c tzw. "stop words"
        /// </summary>
        /// <param name="sourceFileName">Pe³na œcie¿ka pliku wejœciowego.</param>
        /// <param name="destFileName">Pe³na œcie¿ka pliku wynikowego zawieraj¹cego s³owa po stemmingu.</param>
        /// <param name="stopWords">S³ownik zawieraj¹cy "stop words" - s³owa (koniecznie zapisane ma³ymi literami!), które s¹ pomijane przy obróbce
        /// i które nie zostan¹ zapisane w wynikowym pliku. Sprawdzenie czy dane s³owo nale¿y do s³ownika
        /// nastêpuej przed jego stemmingiem. </param>
        public static void StemFile(String sourceFileName, String destFileName, Dictionary<int, String> stopWords)
        {
            //odczyt z pliku do stringa
            StreamReader sr = new StreamReader(sourceFileName);
            String tmpLine;
            StringBuilder sb = new StringBuilder();
            while ((tmpLine = sr.ReadLine()) != null)
                sb.Append(tmpLine + ' ');
            sr.Close();
            String text = sb.ToString();
            //dzielenie na wyrazy
            String[] wordList = Regex.Split(text, @"[\W\s0-9]+"); //dziele w miejscu, gdzie s¹ znaki specjalne, spacje, lub cyfry
            FileStream fs = new FileStream(destFileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            //obróbka s³ów
            for (int i=0; i<wordList.Length;i++)
            {
                wordList[i] = wordList[i].ToLower(); //ma³ych liter wymaga stemmer
                //eliminacja stop words
                if (stopWords != null && stopWords.ContainsKey(wordList[i].GetHashCode()))
                    continue;
                //stemming
                Stemmer stemmer = new Stemmer();
                stemmer.add(wordList[i].ToCharArray(),wordList[i].Length);
                stemmer.stem();
                sw.Write(stemmer.ToString() + ' ');
            }

            sw.Close();
            fs.Close();


        }
    }
}
