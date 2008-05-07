using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Dictionaries;

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
            FileStream fs = new FileStream(destFileName, FileMode.Create);
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
                destFile = sourceFile.Name + PreprocessingConsts.StemmedFileExtension;//".stm";
                PreprocessingUtility.StemFile(sourceFile.FullName, destDirInfo.FullName + "\\" + destFile, stopWords);
            }
        }
        
        /// <summary>
        /// Tworzy plik dla danego katalogu z posumowanymi wsystkimi wyst¹pieniami s³ów.
        /// Zostaje przeszukany tylko ten katalog - podkatalogi nie s¹ uwzglêdniane.
        /// </summary>
        /// <param name="sourceDir">Katalog, w którym znajduj¹ siê pliki z danymi.</param>
        /// <param name="pattern">Wzorzec plików, dla których ma byæ sumowanie np. ".cat".</param>
        /// <param name="resultFileName">Œcie¿ka do pliku z wynikami.</param>
        public static void SumWords(String sourceDir, String pattern, String resultFileName)
        {
            //Dictionary<String, int> wordsInFiles = new Dictionary<String, int>();
            Dictionary<String, WordInfo> wordsInFiles = new Dictionary<String, WordInfo>();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo sourceFile in sourceDirInfo.GetFiles(pattern)) //przechodzê przez wszystkie pliki
            {
                Console.WriteLine("Processing file: " + sourceFile);
                StreamReader sr = new StreamReader(sourceFile.FullName);
                String tmpLine;
                //String[] splittedLine;
                while ((tmpLine = sr.ReadLine()) != null && tmpLine.Length > 0)
                {
                    //splittedLine = tmpLine.Split(' ');
                    //String word = splitedLine[0];
                    //int count = int.Parse(splitedLine[1]);
                    WordInfo newWordInfo = WordInfo.Parse(tmpLine);
                    //dodanie s³owa do s³ownika lub zwiêkszenie jego wartoœci
                    if (wordsInFiles.ContainsKey(newWordInfo.Word))
                    {
                        WordInfo storedWordInfo = wordsInFiles[newWordInfo.Word];
                        storedWordInfo.Count += newWordInfo.Count;
                        storedWordInfo.InclDocCount += newWordInfo.InclDocCount;
                    }
                    else
                        wordsInFiles.Add(newWordInfo.Word, newWordInfo);
                }
                sr.Close();
            }
            //utworzenie pliku wynikowego
            FileStream fs = new FileStream(resultFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (String word in wordsInFiles.Keys)
                sw.WriteLine(wordsInFiles[word]);
            sw.Close();
            fs.Close();

        }
        /// <summary>
        /// Onlicza wartoœæ Tf-Idf.
        /// </summary>
        /// <param name="wordCount">Iloœæ wyst¹pieñ danego s³owa w dokumencie.</param>
        /// <param name="wordsInDocCount">Iloœæ wszystkich s³ów w dokumencie.</param>
        /// <param name="allDocCount">Iloœæ wszystkich dokumentów.</param>
        /// <param name="inclDocCount">Iloœæ dokumentów zawieraj¹cych dane s³owo.</param>
        /// <returns></returns>
        public static double ComputeTfIdf(double wordCount, double wordsInDocCount, double allDocCount, double inclDocCount)
        {
            return (wordCount / wordsInDocCount) * Math.Log10(allDocCount / inclDocCount);
        }
        /// <summary>
        /// Tworzy listê zawieraj¹c¹ wszystkie dokumenty do uczenia.
        /// </summary>
        /// <param name="sourceDir">Kataloog zawieraj¹cy katalogi z poszczególnymi kategoriami.</param>
        /// <param name="dictionary">S³ownik na podstawie którego maj¹ byæ tworzone dokumenty.</param>
        /// <param name="drt">Rodzaj dokumentów.</param>
        /// <param name="learningDocInfo">Obiekt klasy learningDocInfo lub null jeœli nie jest potrzebny dla danego s³ownika i typu dokumentu.</param>
        /// <returns></returns>
        public static DocumentList CreateLearningDocumentList(String sourceDir, Dictionary dictionary, DocumentRepresentationType drt, LearningDocInfo learningDocInfo)
        {
            DocumentList result = new DocumentList();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(Properties.Settings.Default.pathLearningDir);
            foreach (DirectoryInfo dirInfo in sourceDirInfo.GetDirectories())
                result.AddDocumentsFromDir(dirInfo.FullName + "\\" + PreprocessingConsts.StemmedFolder,dictionary,drt,dirInfo.Name,learningDocInfo);
            return result;
        }
    }
}
