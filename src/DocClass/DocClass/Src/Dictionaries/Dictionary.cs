using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Learning;
using DocClass.Src.Classification;

namespace DocClass.Src.Dictionaries
{
    abstract class Dictionary
    {

        //int GetDesiredOutput();
        abstract public bool Init(ICollection<IDocument> docs);
        
        protected List<LearningPair> learningData;
        protected List<IDocument> documents;
        private bool dataPrepared = false;
        private List<double[]> outputData;
        private List<double[]> inputData;

        public List<double[]> InputVectors
        {
            get
            {
                CreateVectorsData();
                return inputData;
            }
        }

        public List<LearningPair> DataVectors
        {
            get
            {
                CreateVectorsData();
                return learningData;
            }
        }

        public List<double[]> OutputVectors
        {
            get{
                CreateVectorsData();
                return outputData;
            }
        }
         
        //TODO: sprawdzic
        /// <summary>
        /// Tworzenie listy par uczacych
        /// </summary>
        /// <returns></returns>
        private void CreateVectorsData()
        {
            if (dataPrepared == false)
            {
                //budowanie listy slow
                List<string> contener = new List<string>();
                foreach(LearningPair d in learningData)
                {
                    foreach(string word in d.Map.Keys)
                    {
                        if (!contener.Contains(word))
                        {
                            contener.Add(word);
                        }
                    }
                }

                //tworzenie wekrotow wedluw stworzonej wlasnie definicji przestrzeni
                foreach (IDocument d in documents)
                {
                    double[] vector = new double[contener.Count];
                    foreach (string word in d.ToMap().Keys)
                    {
                        vector[contener.IndexOf(word)] = d.ToMap()[word];
                    }
                    inputData.Add(vector);
                }

                //tworzenie wektorow wyjsciowych w celu uzycia ich w macierzy greena
                for (int i = 0; i < DocumentClass.CathegoriesCount; i++)
                {
                    double[] vector = new double[learningData.Count];
                    outputData.Add(vector);
                }
                for(int i =0; i<learningData.Count; i++)
                {
                    outputData[documents[i].DesiredOutput][i] = 1;
                }

                dataPrepared = true;
            }
        }
    }
}
