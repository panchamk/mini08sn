using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using DocClass.Src.Classification;

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
         
        //TODO: sprawdzic
        /// <summary>
        /// Tworzenie listy par uczacych
        /// </summary>
        /// <returns></returns>
        private void CreateLearningData()
        {
            if (dataPrepared == false)
            {
                //budowanie listy slow
                List<string> contener = new List<string>();
                foreach(IDictionary d in dictionaries)
                {
                    foreach(string word in d.ToMap().Keys)
                    {
                        if (!contener.Contains(word))
                        {
                            contener.Add(word);
                        }
                    }
                }

                //tworzenie wekrotow wedluw stworzonej wlasnie definicji przestrzeni
                foreach (IDictionary d in dictionaries)
                {
                    double[] vector = new double[contener.Count];
                    foreach (string word in d.ToMap().Keys)
                    {
                        vector[contener.IndexOf(word)] = d.ToMap()[word];
                    }
                    learningData.Add(new LearningPair(vector, d.GetDesiredOutput()));
                    inputData.Add(vector);
                }

                //tworzenie wektorow wyjsciowych w celu uzycia ich w macierzy greena
                for (int i = 0; i < DocumentClass.CathegoriesCount; i++)
                {
                    double[] vector = new double[contener.Count];
                    outputData.Add(vector);
                }
                for(int i =0; i<dictionaries.Count; i++)
                {
                    outputData[dictionaries[i].GetDesiredOutput()][i] = 1;
                }

                dataPrepared = true;
            }
        }

        /// <summary>
        /// Dodawanie slownika do zestawu danych uczacych
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
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
