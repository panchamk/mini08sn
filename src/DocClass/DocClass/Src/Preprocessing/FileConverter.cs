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
        /// Zwraca list� s��w �adowan� z pliku.
        /// </summary>
        /// <param name="fileName">Plik z list� plik�w. Ka�de s�owo powinno by� w nowej linii.</param>
        /// <returns>Lista s��w, ka�de pisane ma�ymi literami.</returns>
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
        /// Wykonuje stemming wszystkich s��w w danym pliku pomijaj�c tzw. "stop words"
        /// </summary>
        /// <param name="sourceFileName">Pe�na �cie�ka pliku wej�ciowego.</param>
        /// <param name="destFileName">Pe�na �cie�ka pliku wynikowego zawieraj�cego s�owa po stemmingu.</param>
        /// <param name="stopWords">S�ownik zawieraj�cy "stop words" - s�owa (koniecznie zapisane ma�ymi literami!), kt�re s� pomijane przy obr�bce
        /// i kt�re nie zostan� zapisane w wynikowym pliku. Sprawdzenie czy dane s�owo nale�y do s�ownika
        /// nast�puej przed jego stemmingiem. </param>
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
            String[] wordList = Regex.Split(text, @"[\W\s0-9]+"); //dziele w miejscu, gdzie s� znaki specjalne, spacje, lub cyfry
            FileStream fs = new FileStream(destFileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            //obr�bka s��w
            for (int i=0; i<wordList.Length;i++)
            {
                wordList[i] = wordList[i].ToLower(); //ma�ych liter wymaga stemmer
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
