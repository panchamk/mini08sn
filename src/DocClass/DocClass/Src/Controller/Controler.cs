using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows.Forms;

using DocClass.Src.Classification.BayesClassificator;
using DocClass.Src.Classification.RadialNetwork;
using DocClass.Src.Classification;
using DocClass.Src.Dictionaries;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Preprocessing;
using DocClass.Src.Controller.Workers;
using DocClass.Src.GUI;


namespace DocClass.Src.Controller
{
    
    
    public class Controller
    {
        /// <summary>
        /// Główne okno aplikacji.
        /// </summary>
        private MainForm form;

        /// <summary>
        /// Okno odpowiedzialne za preprocessing.
        /// </summary>
        private PreprocessingForm preprocessingForm;

        /// <summary>
        /// Lista plików do klasyfikacji.
        /// </summary>
        private List<string> fileToClassification;

        private List<string> classificationResult;

        /// <summary>
        /// Objekt reprezentujący sieć neuronową.
        /// </summary>
        private RadialNetwork radialNetwork;

        /// <summary>
        /// Objekt reprezentujący klasyfikator Baysena.
        /// </summary>
        private BayesClassificator bayesClassificator;

        /// <summary>
        /// Objekt reprezentujący słownik.
        /// </summary>
        private Dictionary dictionary;

        /// <summary>
        /// Objekt reprezentujący "stop wordsy"
        /// </summary>
        private Dictionary<int, String> stopWords;

        /// <summary>
        /// Objekt zawierający informacje o dokumentach.
        /// </summary>
        private LearningDocInfo learningDocInfo;

        /// <summary>
        /// Wątek uczący.
        /// </summary>
        private LearningBackgroundWorker learningWorker;

        /// <summary>
        /// Watek klasyfikujący.
        /// </summary>
        private ClassificationBackgroundWorker classificationWorker;
        
        /// <summary>
        /// Wątek robiący preprocessing.
        /// </summary>
        private PreprocessingBackgroundWorker preprocessingWorker;
        
        /// <summary>
        /// Folder który w którym będzie robiony preprocesing.
        /// </summary>
        private String preprocessingPath;

        #region CONSTRUCTOR 

        public Controller(MainForm form)
        {
            this.form = form;
            fileToClassification = new List<string>();

            learningWorker = new LearningBackgroundWorker(this);
            learningWorker.WorkerReportsProgress = true;
            learningWorker.WorkerSupportsCancellation = true;
            learningWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLearningWorker_RunWorkerCompleted);
            learningWorker.ProgressChanged += new ProgressChangedEventHandler(OnLearningWorker_ProgressChanged);

            classificationWorker = new ClassificationBackgroundWorker(this);
            classificationWorker.WorkerReportsProgress = true;
            classificationWorker.WorkerSupportsCancellation = true;
            classificationWorker.ProgressChanged += new ProgressChangedEventHandler(OnClassificationWorker_ProgressChanged);
            classificationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnClassificationWorker_RunWorkerCompleted);

            preprocessingWorker = new PreprocessingBackgroundWorker(this);
            preprocessingWorker.WorkerReportsProgress = true;
            preprocessingWorker.WorkerSupportsCancellation = true;
            preprocessingWorker.ProgressChanged += new ProgressChangedEventHandler(OnPreprocessingWorker_ProgressChanged);
            preprocessingWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnPreprocessingWorker_RunWorkerCompleted);
        }

        #endregion

        #region BECKGROUND WORKERS EVENTS

        void OnLearningWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.Out.WriteLine("LEARNING CHANGE");
        }

        void OnLearningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.Out.WriteLine("LEARNING END");
        }

        void OnClassificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            form.ClassificationEnd(classificationResult);
        }

        void OnClassificationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            form.ProgressBarClassification.Increment(1);
        }

        void OnPreprocessingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.Out.WriteLine("CLASSIFICATION CHANGE");
        }

        void OnPreprocessingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            preprocessingForm.IncreseProgress(1);
        }

        #endregion 

        #region PUBLIC METHODS

        /// <summary>
        /// Dodaje plik o danej scieżce do listy klasyfikacyjnej.
        /// </summary>
        /// <param name="path"></param>
        public void AddFileToClassification(String path)
        {
            fileToClassification.Add(path);
        }

        /// <summary>
        /// Czyści Listę klasyfikacyjną.
        /// </summary>
        public void ClearFileToClassification()
        {
            fileToClassification.Clear();
        }

        /// <summary>
        /// Metoda wywoływana na uczenie sieci.
        /// Metoda odpala wątek który bedzie uczył sieć.
        /// </summary>
        public void Learn()
        {
            learningWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Prces uczenia sieci.
        /// Metoda wykonywana w odzielnym wątku.
        /// </summary>
        public void LearnProcess()
        {
            

            switch ((ClasyficatorType)Properties.Settings.Default.clasificatorType)
            {
                case (ClasyficatorType.Bayes):
                    Console.Out.WriteLine("BAYES - Poczatek nauki.");
                    BayesLearn();
                    Console.Out.WriteLine("BAYES - Koniec nauki.");
                    break;
                case (ClasyficatorType.RadialNeural):
                    Console.Out.WriteLine("SIEC - Poczatek nauki.");
                    RadialNeuralLearn();
                    Console.Out.WriteLine("SIEC - Koniec nauki.");
                    break;
                default:
                    throw new NotImplementedException("Nieznany typ klasyfikacji.");
            }
            //TODO: Emil
            //DocumentList dl = new DocumentList(Properties.Settings.Default.pathLearningDir, dictionary, Properties.Settings.Default.documentRepresentationType, null, 
            //DocumentList dl = PreprocessingUtility.CreateLearningDocumentList(Properties.Settings.Default.pathLearningDir, dictionary, (DocumentRepresentationType)Properties.Settings.Default.documentRepresentationType, learningDocInfo);
            //nauka
            //radialNetwork.Learn(Docu); 
            //Console.Out.WriteLine("Koniec nauki.");




        }

        /// <summary>
        /// Metoda wywoływana na klasyfikacje sieci.
        /// Metoda odpala wątek który bedzie klasyfikował dokumenty.
        /// </summary>
        public void Classificate()
        {
            form.ProgressBarClassification.Maximum = fileToClassification.Count;
            form.ProgressBarClassification.Minimum = 0;
            classificationWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Metoda wywołuje odpowiednią klasyfikacje na podstawie wybranej opcji.
        /// </summary>
        public void ClassificateProcess()
        {
            classificationResult = new List<string>();
            string categoryName;

            foreach (string path in fileToClassification)
            {
                if (classificationWorker.CancellationPending)
                {
                    return;
                }

                switch ((ClasyficatorType)Properties.Settings.Default.clasificatorType)
                {
                    case (ClasyficatorType.Bayes):
                        categoryName = BayesClassificate(path);
                        break;
                    case (ClasyficatorType.RadialNeural):
                        int result = RadialNeuralClassificate(path);
                        categoryName = DocumentClass.GetClassName(result);
                        break;
                    default:
                        throw new NotImplementedException("Nieznany typ klasyfikacji.");
                }

                //zapisanie wyniku klasyfikacji
                classificationResult.Add(categoryName);

                //progress
                classificationWorker.ReportProgress(1, path);
            }
        }

        /// <summary>
        /// Metoda robiąca preprocesing całęgo katalogu.
        /// Odpala wątek wykonujący preprocesing.
        /// </summary>
        /// <param name="sourcePath"></param>
        public void PreprocessingDir(String sourcePath)
        {
            int dirNumber = new DirectoryInfo(sourcePath).GetDirectories().Length;

            preprocessingForm = new PreprocessingForm(dirNumber);
            preprocessingPath = sourcePath;
            preprocessingWorker.RunWorkerAsync();
            preprocessingForm.ShowDialog();


        }

        /// <summary>
        /// Metoda robiąca preprocesing całego katalogu.
        /// Odpalana w oddzielnym wątku.
        /// </summary>
        public void PreprocessingDirProcess()
        {
            if (stopWords == null)
            {
                stopWords = PreprocessingUtility.LoadStopWords(Properties.Settings.Default.pathStopWords);
            }

            DirectoryInfo rootDirInfo = new DirectoryInfo(preprocessingPath);
            foreach (DirectoryInfo sourceDirInfo in rootDirInfo.GetDirectories())
            {
                PreprocessingUtility.StemDir(sourceDirInfo.FullName, stopWords);
                PreprocessingUtility.SumWords(sourceDirInfo.FullName + "\\stem\\", PreprocessingConsts.StemmedFilePattern, rootDirInfo + "\\" + sourceDirInfo.Name + PreprocessingConsts.CategoryFileExtension);
                preprocessingWorker.ReportProgress(1);
            }
            PreprocessingUtility.SumWords(preprocessingPath, PreprocessingConsts.CategoryFilePattern, rootDirInfo + "\\" + PreprocessingConsts.SummaryFileName);
        }

        /// <summary>
        /// Metoda zatrzymująca klasyfikacjie.
        /// </summary>
        public void CancelClassification()
        {
            classificationWorker.CancelAsync();

        }

        # endregion

        #region PRIVATE METHODS

        private void RadialNeuralLearn()
        {
            //ładuje listę kategorii
            DocumentClass.LoadFromFiles(Properties.Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);

            //stworzenie słownika
            dictionary = dictionaryFactory(Properties.Settings.Default.pathSummaryFile);
            //dictionary.LearningData = new List<DocClass.Src.Learning.LearningPair>();

            //stworzenie sieci
            radialNetwork = new RadialNetwork(Properties.Settings.Default.hiddenLayerInitNeuronCount, DocumentClass.CategoriesCount);

            DocumentList dl = PreprocessingUtility.CreateLearningDocumentList(Properties.Settings.Default.pathLearningDir, dictionary, (DocumentRepresentationType)Properties.Settings.Default.documentRepresentationType, learningDocInfo);
            radialNetwork.Learn(dl); 
        }

        private void BayesLearn()
        {
            //ładuje listę kategorii
            DocumentClass.LoadFromFiles(Properties.Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);

            //tworze klasyfikator
            bayesClassificator = new BayesClassificator();

            //tworze liste kategorii
            CategoryList categoryList = new CategoryList(Properties.Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);

            //nauka
            bayesClassificator.Learn(categoryList);
        }

        /// <summary>
        /// Metoda wykonująca klasyfikacjie Bayesa.
        /// </summary>
        /// <param name="pathFile"></param>
        private string BayesClassificate(String pathFile)
        {
            String preprocessingPathFile = Path.GetTempPath() + getNameFromPath(pathFile);

            //preprocesing
            PreprocessingFile(pathFile, preprocessingPathFile);

            //tworze listę słów
            ICollection<string> wordsCollection = wordsFromFile(preprocessingPathFile);

            //klasyfikacja
            string category = bayesClassificator.Classificate(wordsCollection);

            //usunięcie pliku
            new FileInfo(preprocessingPathFile).Delete();

            return category;
        }

        /// <summary>
        /// Metoda wykonująca klasyfikacie na podtstawie nauczonej sieci.
        /// </summary>
        /// <param name="pathFile"></param>
        private int RadialNeuralClassificate(String pathFile)
        {
            String preprocessingPathFile = Path.GetTempPath() + getNameFromPath(pathFile);

            //preprocesing
            PreprocessingFile(pathFile, preprocessingPathFile);

            //stworzenie reprezentacji dokumentu
            Document document = documentFactory(preprocessingPathFile);

            //klasyfikacji
            int result = radialNetwork.Classificate(document);

            //usunięcie pliku
            new FileInfo(preprocessingPathFile).Delete();

            return result;
        }

        /// <summary>
        /// Metoda zwracające odpowiednią reprezentacjie słownika na 
        /// podstweie wybranej opcji.
        /// </summary>
        /// <param name="pathSummary"></param>
        /// <returns></returns>
        private Dictionary dictionaryFactory(String pathSummary)
        {
            WordCountList wordCountList = new WordCountList(pathSummary);
            if (learningDocInfo == null)
            {
                learningDocInfo = new LearningDocInfo(Properties.Settings.Default.pathLearningDir,
                                                    Properties.Settings.Default.pathSummaryFile);
            }
            switch ((DictionaryType)Properties.Settings.Default.dictionaryType)
            {
                case DictionaryType.CtfIdf:
                    return new CtfIdfDictionary(Properties.Settings.Default.pathLearningDir, pathSummary, 1000/*wordCountList.GetUniqueWordsCount()*/);
                case DictionaryType.Fixed:
                    //TODO: dodać jak bedzie zrobione
                    throw new Exception("Not implemented konstruktor");
                case DictionaryType.Frequent:
                    return new FrequentDictionary(pathSummary, wordCountList.GetUniqueWordsCount());
                default:
                    throw new NotImplementedException("Nieznany typ słownika.");
            }
        }

        /// <summary>
        /// Metoda zwracająca reprezentacjie dokumentu na podstawie
        /// wybranej opcji.
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        private Document documentFactory(String pathFile)
        {
            switch ((DocumentRepresentationType)Properties.Settings.Default.documentRepresentationType)
            {
                case DocumentRepresentationType.Binary:
                    return new BinaryDocument(pathFile, dictionary, null);
                case DocumentRepresentationType.Own:
                    return new OwnDocument(pathFile,dictionary,null);
                case DocumentRepresentationType.TfIdf:
                    if (learningDocInfo == null)
                    {
                        learningDocInfo = new LearningDocInfo(Properties.Settings.Default.pathLearningDir,
                                                            Properties.Settings.Default.pathSummaryFile);
                    }
                    return new TfIdfDocument(pathFile,dictionary, null, learningDocInfo);
                default:
                    throw new NotImplementedException("Nieznany typ dokumentu.");
            }
        }

        /// <summary>
        /// Metoda zwracające nazwe folderu/pliku 
        /// na podstawie ścieżki.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private String getNameFromPath(String path)
        {

            for (int i = path.Length-1; i >= 0; i--)
            {
                if (path[i] == '\\')
                {
                    return path.Substring(i+1);
                }
            }
            return path;
        }

        /// <summary>
        /// Metoda robiąca preprocessing piku.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationFile"></param>
        public void PreprocessingFile(String sourcePath, String destinationFile)
        {
            if (stopWords == null)
            {
                stopWords = PreprocessingUtility.LoadStopWords(Properties.Settings.Default.pathStopWords);
            }
            PreprocessingUtility.StemFile(sourcePath, destinationFile, stopWords);
        }

        private ICollection<string> wordsFromFile(String pathFile)
        {
            //tworze liste
            WordCountList wcl = new WordCountList(pathFile);

            ICollection<string> coll = new List<string>();
            foreach (WordCountPair wcp in wcl)
            {
                coll.Add(wcp.Word);
            }
            return coll;
        }

        #endregion
    }       
}
