using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using DocClass.Src.Classification.BayesClassificator;
using DocClass.Src.Classification.RadialNetwork;
using DocClass.Src.Classification;
using DocClass.Src.Dictionaries;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Preprocessing;
using DocClass.Src.Controller.Workers;
using DocClass.Src.GUI;
using DocClass.Properties;


namespace DocClass.Src.Controller
{
    
    
    public class Controller
    {
        #region FIELDS

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

        private int allWordsInBayesCategory;

        private DictionaryType learnDictionaryType;

        public DictionaryType LearnDictionaryType
        {
            get { return learnDictionaryType; }
            set { learnDictionaryType = value; }
        }

        private DocumentRepresentationType learnDocumentRepresentationType;

        internal DocumentRepresentationType LearnDocumentRepresentationType
        {
            get { return learnDocumentRepresentationType; }
            set { learnDocumentRepresentationType = value; }
        }

        #endregion

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
            if (!((BackgroundWorker)sender).CancellationPending)
            {
                form.ProgressBarLearn.Maximum = allWordsInBayesCategory;
                form.ProgressBarLearn.Increment(1);
            }
        }

        void OnLearningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            form.LearnEnd();
            this.learnDocumentRepresentationType = (DocumentRepresentationType)Settings.Default.documentRepresentationType;
            this.LearnDictionaryType = (DictionaryType)Settings.Default.dictionaryType;
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
            if(preprocessingForm!=null)
            {
                preprocessingForm.PreprocessingEnd();
            }
        }

        void OnPreprocessingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            preprocessingForm.IncreseProgress(1);
        }

        #endregion 



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

        #region LEARN

        /// <summary>
        /// Metoda wywoływana na uczenie sieci.
        /// Metoda odpala wątek który bedzie uczył sieć.
        /// </summary>
        public void Learn()
        {
            if (((ClasyficatorType)Settings.Default.clasificatorType)==ClasyficatorType.RadialNeural){
                form.ProgressBarLearn.Style = ProgressBarStyle.Marquee;
            }
            learningWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Prces uczenia sieci.
        /// Metoda wykonywana w odzielnym wątku.
        /// </summary>
        public void LearnProcess()
        {
            switch ((ClasyficatorType)Settings.Default.clasificatorType)
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
        }

        private void RadialNeuralLearn()
        {
            if (learningDocInfo != null && learningDocInfo.SourceDir != Settings.Default.pathLearningDir)
            {
                learningDocInfo = null;
            }

            //ładuje listę kategorii
            DocumentClass.LoadFromFiles(Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);

            //stworzenie słownika
            dictionary = DictionaryFactory(Settings.Default.pathSummaryFile);
            //dictionary.LearningData = new List<DocClass.Src.Learning.LearningPair>();

            //stworzenie sieci
            radialNetwork = new RadialNetwork(Settings.Default.numberNeuronsHidden, DocumentClass.CategoriesCount);

            DocumentList dl = PreprocessingUtility.CreateLearningDocumentList(Settings.Default.pathLearningDir, dictionary, (DocumentRepresentationType)Settings.Default.documentRepresentationType, learningDocInfo);
            if (radialNetwork.Learn(dl) == false)
            {
                radialNetwork = null;
                dictionary = null;
            }
        }

        private void BayesLearn()
        {
            //tworze klasyfikator
            bayesClassificator = new BayesClassificator(learningWorker);

            //ładuje listę kategorii
            DocumentClass.LoadFromFiles(Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);

            //tworze liste kategorii
            CategoryList categoryList = new CategoryList(Settings.Default.pathLearningDir, PreprocessingConsts.CategoryFilePattern);
            this.allWordsInBayesCategory = categoryList.AllWordsCount;

            //nauka
            if (bayesClassificator.Learn(categoryList) == false)
            {
                bayesClassificator = null;
                this.allWordsInBayesCategory = 0;
            }
        }

        public void StopLearning()
        {
            learningWorker.CancelAsync();
        }

        #endregion

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

                switch ((ClasyficatorType)Settings.Default.clasificatorType)
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

            preprocessingForm = new PreprocessingForm(this);
            preprocessingForm.MaxProgress = dirNumber;
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
                stopWords = PreprocessingUtility.LoadStopWords(Settings.Default.pathStopWords);
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

        /// <summary>
        /// Zapisuje siec neuronową do podanego pliku.
        /// </summary>
        /// <param name="pathFile">Scieżka do pliku.</param>
        public void SaveRadialNetwork(String pathFile)
        {
            Stream stream = File.Open(pathFile, FileMode.OpenOrCreate);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, this.radialNetwork);
            bFormatter.Serialize(stream, this.dictionary);
            bFormatter.Serialize(stream, this.learningDocInfo);
            bFormatter.Serialize(stream, DocumentClass.DocumentCategories);
            bFormatter.Serialize(stream, this.learnDocumentRepresentationType);
            bFormatter.Serialize(stream, this.learnDictionaryType);
            SaveSettings(stream, bFormatter);
            stream.Close();
        }

        /// <summary>
        /// Odczytuje sieć nuronową z podanego pliku.
        /// </summary>
        /// <param name="pathFile">Scieżka do pliku.</param>
        public void LoadRadialNetwork(String pathFile)
        {
            Stream stream = File.Open(pathFile, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            this.radialNetwork = (RadialNetwork)bFormatter.Deserialize(stream);
            this.dictionary = (Dictionary)bFormatter.Deserialize(stream);
            this.learningDocInfo = (LearningDocInfo)bFormatter.Deserialize(stream);
            DocumentClass.DocumentCategories = (List<String>)bFormatter.Deserialize(stream);
            this.learnDocumentRepresentationType = (DocumentRepresentationType)bFormatter.Deserialize(stream);
            this.learnDictionaryType = (DictionaryType)bFormatter.Deserialize(stream);
            LoadSettings(stream, bFormatter);
            stream.Close();

            this.form.LoadClassificatorEnd(ClasyficatorType.RadialNeural);
        }

        /// <summary>
        /// Zapisuje klasyfikator Bayes'a do podanego pliku.
        /// </summary>
        /// <param name="pathFile">Scieżka do pliku.</param>
        public void SaveBayes(String pathFile)
        {
            Stream stream = File.Open(pathFile, FileMode.OpenOrCreate);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, this.bayesClassificator);
            bFormatter.Serialize(stream, DocumentClass.DocumentCategories);
            SaveSettings(stream, bFormatter);
            stream.Close();
        }

        /// <summary>
        /// Odczytuje klasyfikator Bayesa z podanego pliku.
        /// </summary>
        /// <param name="pathFile">Scieżka do pliku.</param>
        public void LoadBayes(String pathFile)
        {
            Stream stream = File.Open(pathFile, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            this.bayesClassificator = (BayesClassificator)bFormatter.Deserialize(stream);
            DocumentClass.DocumentCategories = (List<String>)bFormatter.Deserialize(stream);
            LoadSettings(stream, bFormatter);
            stream.Close();

            this.form.LoadClassificatorEnd(ClasyficatorType.Bayes);
        }

        public bool IsAfterLearn()
        {
            ClasyficatorType classificationType = (ClasyficatorType)Settings.Default.clasificatorType;
            switch (classificationType)
            {
                case ClasyficatorType.Bayes:
                    return (this.bayesClassificator != null);
                case ClasyficatorType.RadialNeural:
                    return (radialNetwork!=null);
                default:
                    throw new NotImplementedException("Nieznany typ klasyfikacji.");
            }
        }

        public bool IsAfterLearn(ClasyficatorType classificatorType)
        {
            switch (classificatorType)
            {
                case ClasyficatorType.Bayes:
                    return (this.bayesClassificator != null);
                case ClasyficatorType.RadialNeural:
                    return (radialNetwork != null);
                default:
                    throw new NotImplementedException("Nieznany typ klasyfikacji.");
            }
        }



        #region PRIVATE METHODS


        private void SaveSettings(Stream stream, BinaryFormatter bFormatter)
        {
            bFormatter.Serialize(stream, Settings.Default.pathSummaryFile);
            bFormatter.Serialize(stream, Settings.Default.pathLearningDir);

            bFormatter.Serialize(stream, Settings.Default.numberLearningDocuments);
            bFormatter.Serialize(stream, Settings.Default.numberLearningCategories);
            bFormatter.Serialize(stream, Settings.Default.numberAllWordsInDictionary);

            bFormatter.Serialize(stream, Settings.Default.dictionaryType);
            bFormatter.Serialize(stream, Settings.Default.documentRepresentationType);

            bFormatter.Serialize(stream, Settings.Default.numberNeuronsHidden);
            bFormatter.Serialize(stream, Settings.Default.numberNeuronsOut);
        }

        private void LoadSettings(Stream stream, BinaryFormatter bFormatter)
        {
            Settings.Default.pathSummaryFile = (string)bFormatter.Deserialize(stream);
            Settings.Default.pathLearningDir = (string)bFormatter.Deserialize(stream);

            Settings.Default.numberLearningDocuments = (int)bFormatter.Deserialize(stream);
            Settings.Default.numberLearningCategories = (int)bFormatter.Deserialize(stream);
            Settings.Default.numberAllWordsInDictionary = (int)bFormatter.Deserialize(stream);

            Settings.Default.dictionaryType = (int)bFormatter.Deserialize(stream);
            Settings.Default.documentRepresentationType = (int)bFormatter.Deserialize(stream);

            Settings.Default.numberNeuronsHidden = (int)bFormatter.Deserialize(stream);
            Settings.Default.numberNeuronsOut = (int)bFormatter.Deserialize(stream);
        }

        /// <summary>
        /// Metoda wykonująca klasyfikacjie Bayesa.
        /// </summary>
        /// <param name="pathFile"></param>
        private string BayesClassificate(String pathFile)
        {
            String preprocessingPathFile = Path.GetTempPath() + GetNameFromPath(pathFile);

            //preprocesing
            PreprocessingFile(pathFile, preprocessingPathFile);

            //tworze listę słów
            ICollection<string> wordsCollection = GetWordsFromFile(preprocessingPathFile);

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
            String preprocessingPathFile = Path.GetTempPath() + GetNameFromPath(pathFile);

            //preprocesing
            PreprocessingFile(pathFile, preprocessingPathFile);

            //stworzenie reprezentacji dokumentu
            Document document = DocumentFactory(preprocessingPathFile);

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
        private Dictionary DictionaryFactory(String pathSummary)
        {
            WordCountList wordCountList = new WordCountList(pathSummary);
            if (learningDocInfo == null)
            {
                learningDocInfo = new LearningDocInfo(Settings.Default.pathLearningDir,
                                                    Settings.Default.pathSummaryFile);
            }
            switch ((DictionaryType)Settings.Default.dictionaryType)
            {
                case DictionaryType.CtfIdf:
                    return new CtfIdfDictionary(Settings.Default.pathLearningDir, pathSummary, wordCountList.GetUniqueWordsCount());
                case DictionaryType.Fixed:
                    return new FixedDictionary(Settings.Default.pathLearningDir, wordCountList.GetUniqueWordsCount());
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
        private Document DocumentFactory(String pathFile)
        {
            switch ((DocumentRepresentationType)Settings.Default.documentRepresentationType)
            {
                case DocumentRepresentationType.Binary:
                    return new BinaryDocument(pathFile, dictionary, null);
                case DocumentRepresentationType.Own:
                    return new OwnDocument(pathFile,dictionary,null);
                case DocumentRepresentationType.TfIdf:
                    if (learningDocInfo == null)
                    {
                        learningDocInfo = new LearningDocInfo(Settings.Default.pathLearningDir,
                                                            Settings.Default.pathSummaryFile);
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
        private String GetNameFromPath(String path)
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
                stopWords = PreprocessingUtility.LoadStopWords(Settings.Default.pathStopWords);
            }
            PreprocessingUtility.StemFile(sourcePath, destinationFile, stopWords);
        }

        private ICollection<string> GetWordsFromFile(String pathFile)
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
