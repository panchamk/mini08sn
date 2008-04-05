using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DocClass.Src.Preprocessing
{
    class PreprocessingUtility
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
            //dziele w miejscu, gdzie s¹ znaki specjalne, spacje, lub cyfry
            //uwaga: znak _ nie jest zaliczany do znaków specjalnych
            String[] wordList = Regex.Split(text, @"[\W\s0-9_]+"); 
            //obróbka s³ów
            Dictionary<String, int> wordsInFile = new Dictionary<String, int>();
            for (int i=0; i<wordList.Length;i++)
            {
                wordList[i] = wordList[i].ToLower(); //ma³ych liter wymaga stemmer
                //eliminacja stop words, pomijam te¿ wyrazy puste i jednoliterowe
                if (wordList[i].Length <= 1 || (stopWords != null && stopWords.ContainsKey(wordList[i].GetHashCode())))
                    continue;
                //stemming
                Stemmer stemmer = new Stemmer();
                stemmer.add(wordList[i].ToCharArray(),wordList[i].Length);
                stemmer.stem();
                String word = stemmer.ToString();
                if (wordsInFile.ContainsKey(word))
                    wordsInFile[word]++;
                else
                    wordsInFile.Add(word, 1);
                //sw.Write(stemmer.ToString() + ' ');
            }
            //utworzenie pliku wynikowego
            FileStream fs = new FileStream(destFileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            foreach (String word in wordsInFile.Keys)
                sw.WriteLine(word + ' ' + wordsInFile[word]);
            sw.Close();
            fs.Close();


        }
        /// <summary>
        /// Stemuje wszystkie pliki w danym katalogu. Nie uwzglêdnia podkatalogów.
        /// Pliki po stemmingu s¹ zapisywane do podkatalogu "stem", który zostaje utworzony.
        /// Wynikowy plk ma nazwê pliku wejœciowego i rozszerzenie ".stm".
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj¹ce pliki wejœciowe.</param>
        /// <param name="stopWords">Lista "stop words"</param>
        public static void StemDir(String sourceDir, Dictionary<int, String> stopWords)
        {
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo destDirInfo = Directory.CreateDirectory(sourceDirInfo.FullName + "\\stem");
            String destFile;
            foreach (FileInfo sourceFile in sourceDirInfo.GetFiles())
            {
                Console.WriteLine("Processing file: " + sourceFile);
                destFile = sourceFile.Name + ".stm";
                PreprocessingUtility.StemFile(sourceFile.FullName, destDirInfo.FullName + "\\" + destFile, stopWords);
            }
        }
        
        /// <summary>
        /// Tworzy plik dla danego katalogu z posumowanymi wsystkimi wyst¹pieniami s³ów.
        /// Zostaje przeszukany tylko ten katalog - podkatalogi nie s¹ uwzglêdniane.
        /// </summary>
        /// <param name="sourceDir">Katalog, w którym znajduj¹ siê pliki z danymi</param>
        /// <param name="resultFileName">Œcie¿ka do pliku z wynikami.</param>
        public static void SumWords(String sourceDir, String resultFileName)
        {
            Dictionary<String, int> wordsInFiles = new Dictionary<String, int>();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo sourceFile in sourceDirInfo.GetFiles()) //przechodzê przez wszystkie pliki
            {
                Console.WriteLine("Processing file: " + sourceFile);
                StreamReader sr = new StreamReader(sourceFile.FullName);
                String tmpLine;
                String[] splitedLine;
                while ((tmpLine = sr.ReadLine()) != null && tmpLine.Length > 0)
                {
                    splitedLine = tmpLine.Split(' ');
                    String word = splitedLine[0];
                    int count = int.Parse(splitedLine[1]);
                    //dodanie s³owa do s³ownika lub zwiêkszenie jego wartoœci
                    if (wordsInFiles.ContainsKey(word))
                        wordsInFiles[word] += count;
                    else
                        wordsInFiles.Add(word, count);
                }
                sr.Close();
            }
            //utworzenie pliku wynikowego
            FileStream fs = new FileStream(resultFileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            foreach (String word in wordsInFiles.Keys)
                sw.WriteLine(word + ' ' + wordsInFiles[word]);
            sw.Close();
            fs.Close();

        }
        
    }
}
