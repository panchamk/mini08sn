using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;

namespace DocClass.Src.Learning
{
    class LearningData
    {
        #region private members
        private List<LearningPair> learningData;
        private List<IDictionary> dictionaries;
        private List<double[]> outputData;
        private List<double[]> inputData;
        private bool dataPrepared = false;
        #endregion

        public List<double[]> InputVectors
        {
            get
            {
                CreateLearningData();
                return inputData;
            }
        }

        public List<LearningPair> DataVectors
        {
            get
            {
                CreateLearningData();
                return learningData;
            }
        }

        public List<double[]> OutputVectors
        {
            get{
                CreateLearningData();
                return outputData;
            }
        }
         
        



        /// <summary>
        /// Tworzenie listy par uczacych
        /// </summary>
        /// <returns></returns>
        private void CreateLearningData()
        {
            if (dataPrepared == false)
            {
                //TODO: tworzenie listy wszystkich danych ze slownikow (wektory pionowo) 
                // na podstawie dictionaries
                throw new Exception("The method or operation is not implemented.");

                // Tworzy liste wektorow wyjsciowych (dla kazdego neuronu wyjsciowego jest to osobny wektor
                // na liscie) na podstawie listy LearningData. Kazdy wektor odpowiada jednemu neuronowi wyjsciowemu.
                // Jedynka jest ustawiana wtedy, gdy odpowiadajacy w learningData.Output jest liczba wskazujaca na 
                // ten neuron wyjsciowy. Zero w przeciwnym wypadku
                throw new Exception("The method or operation is not implemented.");

                //wypelnia liste wszystkich wektorow danych wejsciowych
                throw new Exception("The method or operation is not implemented.");

                dataPrepared = true;
            }
        }

        public bool AddDictionary(IDictionary dict)
        {
            dictionaries.Add(dict);
            dataPrepared = false;
            return true;
        }

        /// <summary>
        /// Dodawanie wiekszej ilosci slownikow
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool AddDictionaries(List<IDictionary> dict)
        {
            dictionaries.AddRange(dict);
            dataPrepared = false;
            return true;
        }
    }
}
