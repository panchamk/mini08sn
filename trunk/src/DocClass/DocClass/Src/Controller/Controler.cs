using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using DocClass.Src.Classification.BayesClassificator;
using DocClass.Src.Classification.RadialNetwork;
using DocClass.Src.Classification;
using DocClass.Src.Dictionaries;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Preprocessing;


namespace DocClass.Src.Controller
{
    
    
    class Controller
    {
        private RadialNetwork radialNetwork;
        private BayesClassificator bayesClassificator;
        private Dictionary dictionary;
        private Dictionary<int, String> stopWords;

        public Controller()
        {

        }

        #region PUBLIC METHODS

        public void Learn()
        {
            //preprocesing
            //TODO: dodać preprocessing

            //stworzenie słownika
            dictionary = dictionaryFactory(@"C:\Documents and Settings\Tomi\Moje dokumenty\SIECI\SVN COPY\res\Dane uczące\train\summary.all");
            dictionary.Init(null);//TODO: jak bedzie zaimplementowana metoda init ti dodać

            //stworzenie sieci
            radialNetwork = new RadialNetwork(Properties.Settings.Default.hiddenLayerInitNeuronCount,
                                               Properties.Settings.Default.outputLayerNeuronCount);
            //nauka
            radialNetwork.Learn(dictionary);
            Console.Out.WriteLine("Koniec nauki");

        }



        # endregion

        #region PRIVATE METHODS

        public void Classificate(String pathFile)
        {
            switch ((ClasyficatorType)Properties.Settings.Default.clasificatorType)
            {
                case (ClasyficatorType.Bayes):
                    BayesClassificate(pathFile);
                    break;
                case (ClasyficatorType.RadialNeural):
                    RadialNeuralClassificate(pathFile);
                    break;
                default:
                    throw new NotImplementedException("Nieznany typ klasyfikacji.");
            }
        }

        private Dictionary dictionaryFactory(String pathSummary)
        {
            WordCountList wordCountList = new WordCountList(pathSummary);

            switch ((DictionaryType)Properties.Settings.Default.dictionaryType)
            {
                case DictionaryType.CtfIdf:
                    Console.Out.WriteLine("Do zaimplementowania");//TODO: jak bedzie zaimplementowany konstruktor to dodać
                    return null;
                case DictionaryType.Fixed:
                    Console.Out.WriteLine("Do zaimplementowania");//TODO: jak bedzie zaimplementowany konstruktor to dodać
                    return null;
                case DictionaryType.Frequent:
                    return new FrequentDictionary(pathSummary, wordCountList.GetUniqueWordsCount());
                default:
                    throw new NotImplementedException("Nieznany typ słownika.");
            }
        }

        private Document documentFactory(String pathFile)
        {
            switch ((DocumentRepresentationType)Properties.Settings.Default.documentRepresentationType)
            {
                case DocumentRepresentationType.Binary:
                    return new BinaryDocument(pathFile, dictionary, null);//TODO: nazwa kategorii??
                case DocumentRepresentationType.Own:
                    return new OwnDocument(pathFile,dictionary,null);//TODO: nazwa kategorii??
                case DocumentRepresentationType.TfIdf:
                    Console.Out.WriteLine("Do zaimplementowania");//TODO: jak bedzie zaimplementowany konstruktor to dodać
                    return null;
                default:
                    throw new NotImplementedException("Nieznany typ dokumentu.");
            }
        }

        private void BayesClassificate(String pathFile)
        {
            //TODO: zaimplementować
        }

        private void RadialNeuralClassificate(String pathFile)
        {
            pathFile = "C:\\Documents and Settings\\Tomi\\Moje dokumenty\\SIECI\\SVN COPY\\res\\Dane uczące\\train\\alt.atheism\\51060";
            String preprocessingPathFile = Path.GetTempPath() + getNameFromPath(pathFile);
            
            //preprocesing
            if(stopWords==null)
            {
                stopWords=PreprocessingUtility.LoadStopWords(Properties.Settings.Default.pathStopWords);
            }
            PreprocessingUtility.StemFile(pathFile, preprocessingPathFile, stopWords);
            
            //stworzenie reprezentacji dokumentu
            Document document = documentFactory(preprocessingPathFile);

            //klasyfikacji
            radialNetwork.Classificate(document);

            //usunięcie pliku
            new FileInfo(preprocessingPathFile).Delete();
        }

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

        #endregion
    }       
}
