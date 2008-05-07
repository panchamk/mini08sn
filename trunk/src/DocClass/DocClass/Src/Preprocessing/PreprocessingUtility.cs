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
            //dziele w miejscu, gdzie s� znaki specjalne, spacje, lub cyfry
            //uwaga: znak _ nie jest zaliczany do znak�w specjalnych
            String[] wordList = Regex.Split(text, @"[\W\s0-9_]+"); 
            //obr�bka s��w
            Dictionary<String, int> wordsInFile = new Dictionary<String, int>();
            for (int i=0; i<wordList.Length;i++)
            {
                wordList[i] = wordList[i].ToLower(); //ma�ych liter wymaga stemmer
                //eliminacja stop words, pomijam te� wyrazy puste i jednoliterowe
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
        /// Stemuje wszystkie pliki w danym katalogu. Nie uwzgl�dnia podkatalog�w.
        /// Pliki po stemmingu s� zapisywane do podkatalogu "stem", kt�ry zostaje utworzony.
        /// Wynikowy plk ma nazw� pliku wej�ciowego i rozszerzenie ".stm".
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj�ce pliki wej�ciowe.</param>
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
        /// Tworzy plik dla danego katalogu z posumowanymi wsystkimi wyst�pieniami s��w.
        /// Zostaje przeszukany tylko ten katalog - podkatalogi nie s� uwzgl�dniane.
        /// </summary>
        /// <param name="sourceDir">Katalog, w kt�rym znajduj� si� pliki z danymi.</param>
        /// <param name="pattern">Wzorzec plik�w, dla kt�rych ma by� sumowanie np. ".cat".</param>
        /// <param name="resultFileName">�cie�ka do pliku z wynikami.</param>
        public static void SumWords(String sourceDir, String pattern, String resultFileName)
        {
            //Dictionary<String, int> wordsInFiles = new Dictionary<String, int>();
            Dictionary<String, WordInfo> wordsInFiles = new Dictionary<String, WordInfo>();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo sourceFile in sourceDirInfo.GetFiles(pattern)) //przechodz� przez wszystkie pliki
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
                    //dodanie s�owa do s�ownika lub zwi�kszenie jego warto�ci
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
        /// Onlicza warto�� Tf-Idf.
        /// </summary>
        /// <param name="wordCount">Ilo�� wyst�pie� danego s�owa w dokumencie.</param>
        /// <param name="wordsInDocCount">Ilo�� wszystkich s��w w dokumencie.</param>
        /// <param name="allDocCount">Ilo�� wszystkich dokument�w.</param>
        /// <param name="inclDocCount">Ilo�� dokument�w zawieraj�cych dane s�owo.</param>
        /// <returns></returns>
        public static double ComputeTfIdf(double wordCount, double wordsInDocCount, double allDocCount, double inclDocCount)
        {
            return (wordCount / wordsInDocCount) * Math.Log10(allDocCount / inclDocCount);
        }
        /// <summary>
        /// Tworzy list� zawieraj�c� wszystkie dokumenty do uczenia.
        /// </summary>
        /// <param name="sourceDir">Kataloog zawieraj�cy katalogi z poszczeg�lnymi kategoriami.</param>
        /// <param name="dictionary">S�ownik na podstawie kt�rego maj� by� tworzone dokumenty.</param>
        /// <param name="drt">Rodzaj dokument�w.</param>
        /// <param name="learningDocInfo">Obiekt klasy learningDocInfo lub null je�li nie jest potrzebny dla danego s�ownika i typu dokumentu.</param>
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
