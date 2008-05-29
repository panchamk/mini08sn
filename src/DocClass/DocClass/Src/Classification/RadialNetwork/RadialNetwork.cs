using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ComponentModel;

using DocClass.Src.Exceptions;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning.MathOperations;
using DocClass.Src.DocumentRepresentation;
using System.Windows.Forms;
using System.Diagnostics;


namespace DocClass.Src.Classification.RadialNetwork
{
    [Serializable]
    class RadialNetwork : Classificator
    {
        #region statics

        public const int OUTPUT_LAYER_NEURON_COUNT = 20;
        
        public const int HIDDEN_LAYER_INIT_NEURON_COUNT = 1;

        public const int HIDDEN_LAYER_MAX_NEURON_COUNT = 40;

        private const int TH_DOCUMENT_TO_CHECK = 2;



        #endregion


        #region private variables

        //neurony liniowe warstwy wyjciowej
        private Collection<INeuron> neuronOutputLayer;

        //lista wszystkich dokumentow do uczenia
        [NonSerialized]
        private List<Document> documentList;

        //lista wszystkich dokumentow do testowania uczenia
        [NonSerialized]
        private List<Document> checkList;

        //dane wyjsciowe przetworzone
        private List<double[]> outputData;

        /// <summary>
        /// Aktualna macierz greena
        /// </summary>
        double[,] greenMatrix;
        
        //neurony radialne warstwy ukrytej
        private Collection<INeuron> neuronHiddenLayer;

        //wagi poszczegolnych neuronow wyjsciowych;
        private List<double[]> outputLayerNeutonWeights;

        [NonSerialized]
        private BackgroundWorker bWorker;
        
        #endregion

        #region constructors

        /// <summary>
        /// Konstruktor domyslnej struktory neuronu
        /// </summary>
        public RadialNetwork() : this(HIDDEN_LAYER_INIT_NEURON_COUNT, OUTPUT_LAYER_NEURON_COUNT) { }

        /// <summary>
        /// Konstruktor neuronu o okreslonej strukturze
        /// </summary>
        /// <param name="hiddenLayerInitNeuronCount">liczba neuronow ukrytych</param>
        /// <param name="outputLayerNeuronCount">liczba neuronow wyjsciowych</param>
        public RadialNetwork(int hiddenLayerInitNeuronCount, int outputLayerNeuronCount)
        {
            neuronHiddenLayer = new Collection<INeuron>();
            neuronOutputLayer = new Collection<INeuron>();
            outputLayerNeutonWeights = new List<double[]>();
            for (int i = 0; i < hiddenLayerInitNeuronCount; i++)
            {
                INeuron r = new RadialNeuron();
                neuronHiddenLayer.Add(r);
            }

            for (int i = 0; i < outputLayerNeuronCount; i++)
            {
                INeuron r = new LinearNeuron();
                neuronOutputLayer.Add(r);
            }
        }

        public RadialNetwork(int hiddenLayerInitNeuronCount, int outputLayerNeuronCount,BackgroundWorker bWorker)
        : this(hiddenLayerInitNeuronCount,outputLayerNeuronCount)
        {
            this.bWorker = bWorker;
        }




        #endregion

        #region public methods

        #endregion

        #region private methods

        /// <summary>
        /// Pokrywa rownomiernie przestrzen neuronami
        /// </summary>
        /// <param name="minValues">Tablica minimalnych wartosci w danym wymiarze</param>
        /// <param name="maxValues">Tablica maksymalnych wartosci w danym wymiarze</param>
        /// <param name="neuronList">Lista neuronow do ustawienia</param>
        /// <returns></returns>
        private bool CoverSpaceByNeuronCells(double[] minValues, double[] maxValues, Collection<INeuron> neuronList)
        {
            for (int i = 0; i < this.neuronHiddenLayer.Count; i++)
            {
                ((RadialNeuron)this.neuronHiddenLayer[i]).RandomizeCells(minValues, maxValues, i);
            }
            //double mult = 0;
            //if (minValues.Length != maxValues.Length)
            //    throw new Exception("Niezgodne dlugosci tablic");
            //for (int i = 0; i < minValues.Length; i++)
            //{
            //    mult *= maxValues[i] - minValues[i];
            //}
            //Pierwiastek p = new Pierwiastek();

            //double per = mult / neuronList.Count;
            //p.Liczba = per;
            //p.LiczbaIteracji = 3;
            //p.PunbktStartowy = 1;
            //p.Stopien = minValues.Length;
            //List<Iteracja> wynik = p.obliczenia();
            //double w = wynik[wynik.Count - 1].F3;

            return true;
        }

        /// <summary>
        /// Y liczone zgodnie ze wzorami na siec, jako iloczyn aktualnej macierzy greena i wektora wag dla danej klasy.
        /// W tym przypadku jest to wektor wejsciowy
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private double[] y(double[] w)
        {
            double[] result;
            result = Matrix.Multiply(greenMatrix, w);
            return result;
        }


        /// <summary>
        /// Tworzy macierz greena na podstawie wektorw uczacych i wyznaczonych wektorow
        /// centralnych komorek
        /// </summary>
        /// <returns></returns>
        private double[,] CreateGreenMatrix()
        {
            if(learningData == null)
                throw new NullReferenceException("Puste learningData");
            List<Document> documentCollection = learningData.GetAllDataRandomized();
            if(documentCollection == null || documentCollection.Count == 0)
                throw new NullReferenceException("documentCollecion puste");
            double[,] result = new double[this.documentList.Count, /*documentCollection.Count, */neuronHiddenLayer.Count+1];
            for (int y = 0; y < documentList.Count /*documentCollection.Count*/; y++)
            {
                for (int x = 0; x < neuronHiddenLayer.Count+1; x++)
                {
                    if (x == 0)
                        result[y, x] = 1;
                    else
                    {
                        result[y, x] = ((RadialNeuron)neuronHiddenLayer[x-1]).GaussianFunction(documentList[y].GetValues().ToArray()/* documentCollection[y].GetValues().ToArray()*/);
                    }
                }
            }
            return result;
        }


        private void printMatrix(double[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write("\t{1}", matrix[y, x]);
                }
            }
        }

        /// <summary>
        /// Uczenie warstwy wyjsciowej
        /// </summary>
        /// <param name="outputDesirableData"></param>
        private void OutputLayerLearning(List<double[]> outputDesirableData)
        {
            greenMatrix = CreateGreenMatrix();
            double[,] invertedGreenmatrix = Pseudoinverse.Solve(greenMatrix);
            for (int i = 0; i < neuronOutputLayer.Count ; i++)
            {
                double[] weight = Matrix.Multiply(invertedGreenmatrix, outputDesirableData[i]);
                ((LinearNeuron)neuronOutputLayer[i]).Weights = weight;

            }
        }

        #endregion

        #region overriden methods
        /// <summary>
        /// Glowna procedura uczenia
        /// </summary>
        /// <param name="docs">dane uczace</param>
        /// <returns></returns>
        public override bool Learn(Object obj)
        {
            if (obj == null)
                throw new NullReferenceException("docList puste");
            if (!(obj is DocumentList))
                throw new ArgumentException("Argument nie jest typu: DocumentList !");

            double num1 = 0, num2 = 0;
         
            DocumentList docList = obj as DocumentList;
            docList.ToString();

            this.learningData = docList;
            documentList = docList.GetAllDataRandomized();
            PreSelect();
            if (documentList == null || documentList.Count == 0)
                throw new NullReferenceException("DocumentList pusty");
            List<double[]> desiredOutputData = PrepareOutputData(documentList);
            CoverSpaceByNeuronCells(docList.GetMinValues().ToArray(), docList.GetMaxValues().ToArray(), this.neuronOutputLayer);
            do
            {
                double num3 = 0, num4 = 0;
                OutputLayerLearning(desiredOutputData);
                do
                {
                    HiddenLayerLearning();
                    PrintNeuronsInfo();
                    num4 = num3;
                    num3 = LearnCheck();
                    if (bWorker != null && bWorker.CancellationPending)
                        return false;
                } while (num3 > num4);
                foreach (RadialNeuron n in neuronHiddenLayer)
                    n.BackToPrevWeights();
                num2 = num1;
                num1 = LearnCheck();
            } while (num1 > num2);
            MessageBox.Show("Koniec nauki");
            foreach (LinearNeuron n in neuronOutputLayer)
                n.BackToPrevWeights();
            return true;
        }

        private void PrintNeuronsInfo()
        {
            Debug.WriteLine("NeuronPrint------------------------------------------------------------");
            foreach (RadialNeuron n in neuronHiddenLayer)
            {
                n.ToString();
            }
        }

        /// <summary>
        /// Czesc dokumentow z documentList przenoci do checkList
        /// </summary>
        /// <returns></returns>
        private void PreSelect()
        {
            int counter = 1;
            checkList = new List<Document>();
            for (int i = 0; i < documentList.Count; i++, counter++)
            {
                if (counter % TH_DOCUMENT_TO_CHECK == 0)
                {
                    Document d = documentList[i];
                    documentList.Remove(d);
                    checkList.Add(d);
                    i--;
                }

            }            
        }

        /// <summary>
        /// Sprawdzanie wspojczynnika poprawnych roziwazan
        /// </summary>
        /// <returns></returns>
        private double LearnCheck()
        {
            int counter = 0;
            for (int i = 0; i < documentList.Count; i++)
            {
                if (this.Classificate(documentList[i]) == documentList[i].ClassNo)
                    counter++;
            }
            for (int i = 0; i < checkList.Count; i++)
            {
                if (this.Classificate(checkList[i]) == checkList[i].ClassNo)
                    counter++;
            }
            double result = ((double)counter) / (documentList.Count + checkList.Count);
            Console.WriteLine("Skutecznosc: " + result.ToString());
            return result;
        }

        private List<double[]> PrepareOutputData(List<Document> docList)
        {
            outputData = new List<double[]>();
            for (int i = 0; i < DocumentClass.CategoriesCount; i++)
            {
                double[] vector = new double[docList.Count];
                outputData.Add(vector);
            }
            for (int i = 0; i < docList.Count; i++)
            {
                outputData[docList[i].ClassNo][i] = 1;
            }
            return outputData;
        }

        private void PrintNetworkData(Collection<INeuron> ine)
        {
            for (int ij = 0; ij < ine.Count; ij++)
                PrintNeuronData(ine, ij);
            //PrintNeuronData(ine, 0);
        }

        private void PrintNeuronData(Collection<INeuron> ine, int ij)
        {
            Console.WriteLine();
            Console.WriteLine("Neuron nr: " + ij);
            Console.WriteLine(ine[ij].ToString());
        }
        /// <summary>
        /// Uczenie warstwy ukrytej neuronow radialnych
        /// </summary>
        private void HiddenLayerLearning()
        {
            //dla kazdej klasy wyjsciowej
            for (int k = 0; k < DocumentClass.CategoriesCount; k++)
            {
                // kazdego neuronu warstwy ukrytej
                for (int j = 0; j < neuronHiddenLayer.Count; j++)
                {
                    double[] dif_c = new double[neuronHiddenLayer.Count],
                        dif_sigma = new double[neuronHiddenLayer.Count];
                    //for (int k = 0; k < neuronHiddenLayer.Count; k++)
                    //{
                        dif_c = dE_dc(k, j);
                        dif_sigma = dE_dSigma(k, j);

                    //}
                    ((RadialNeuron)neuronHiddenLayer[j]).CorrectFactors(dif_c, dif_sigma);
                }
            }
        }

        #region hidden layer error correction

        ///// <summary>
        ///// Funkcja y z definicji uzywana do modyfikacji wag neuronow radialnych
        ///// </summary>
        ///// <param name="fi"></param>
        ///// <returns></returns>
        //private double y(double[] xk)
        //{
        //    double result = 0;
        //    foreach( RadialNeuron neu in neuronHiddenLayer)
        //    {
        //        result += neu.fi(neu.u2(xk));
        //    }
        //    return result;
        //}

        /// <summary>
        /// Gradient funkcji gaussa wzgledem c
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double[] dE_dc(int nth_Output, int nth_Neuron)
        {
            double[] result = new double[documentList[0].GetValues().Count];
            RadialNeuron radialNeuron = (RadialNeuron)neuronHiddenLayer[nth_Neuron];
            LinearNeuron linerarNeuron = (LinearNeuron)neuronOutputLayer[nth_Output];
            double[] inputVector;
            double exp;
            //double maxValue;
            for (int wsp = 0; wsp < result.Length; wsp++)
            {
                for (int i = 0; i < documentList.Count; i++) //learningData.DataVectors.Count
                {
                    inputVector = documentList[i].GetValues().ToArray();// learningData.InputVectors[i];
                    exp = Math.Pow(Math.E, -radialNeuron.u2(inputVector)/2 );
                    result[wsp] += (y(linerarNeuron.Weights)[i] - 
                        (outputData[nth_Output])[i]) * linerarNeuron.Weights[nth_Neuron] * 
                        exp * radialNeuron.u(inputVector, wsp);
                   // Console.WriteLine(y(linerarNeuron.Weights)[i] + " - " +
                   //     (learningData.OutputVectors[nth_Output])[i]+ " = " + (y(linerarNeuron.Weights)[i] -
                   //     (learningData.OutputVectors[nth_Output])[i]));
                }
            }
            return result;
        }

                /// <summary>
        /// Gradient funkcji gaussa wzgledem sigma
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double[] dE_dSigma(int nth_Output, int nth_Neuron)
        {
            double[] result = new double[documentList[0].GetValues().Count];
            RadialNeuron radialNeuron = (RadialNeuron)neuronHiddenLayer[nth_Neuron];
            LinearNeuron linerarNeuron = (LinearNeuron)neuronOutputLayer[nth_Output];
            double[] inputVector;
            double exp;
            //double maxValue;
            for (int wsp = 0; wsp < result.Length; wsp++)
            {
                for (int i = 0; i < documentList.Count; i++)
                {
                    inputVector = documentList[i].GetValues().ToArray();
                    exp = Math.Pow(Math.E, -radialNeuron.u2(inputVector) / 2);
                    result[wsp] += (y(linerarNeuron.Weights)[i] -
                        (outputData[nth_Output])[i]) * linerarNeuron.Weights[nth_Neuron] *
                        exp * radialNeuron.u3(inputVector, wsp);
                    //Console.WriteLine(y(linerarNeuron.Weights)[i] + " - " +
                    //    (learningData.OutputVectors[nth_Output])[i] + " = " + (y(linerarNeuron.Weights)[i] -
                    //    (learningData.OutputVectors[nth_Output])[i]));
                }
            }
            return result;
            //double[] result;
            //RadialNeuron radialNeuron = (RadialNeuron)neuronHiddenLayer[nth_Neuron];
            //double[] inputVector;
            //double exp;
            //for (int i = 0; i < learningData.DataVectors.Count; i++)
            //{
            //    inputVector = learningData.InputVectors[i];
            //    exp = Math.Pow(Math.E, radialNeuron.u2(inputVector) * radialNeuron.u3(inputVector, nth_Neuron));
            //    result += ((learningData.OutputVectors[nth_Output][i] - (learningData.OutputVectors[nth_Output])[i]) * exp);
            //}
            //return result;
        }

        #endregion


        /// <summary>
        /// Liczbnie bledow warstwy wyjsciowej w celu przerzucenia ich do warstwy ukrytej i poprawy
        /// wspolczynnikow radialnych neutronow
        /// </summary>
        /// <param name="outputLayer"></param>
        /// <param name="desiredOutput"></param>
        /// <returns></returns>
        private double[] ComputeErrors(double[] outputLayer, double[] desiredOutput)
        {
            double[] result = new double[outputLayer.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (desiredOutput[i] - outputLayer[i]) / desiredOutput[i];
            }
            return result;
        }


        /// <summary>
        /// Klasyfikacja dokumentu
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override int Classificate(DocClass.Src.DocumentRepresentation.Document doc)
        {
            return this.Classificate(doc.GetValues().ToArray());
        }

        /// <summary>
        /// Tworzenie wektora wyjsciowego z warstwy wyjsciowej na podstawie
        /// wektora sygnalow do warstwy wyjsciowej dochodzacych
        /// </summary>
        /// <param name="inputVector"></param>
        /// <returns></returns>
        private double[] OutputLayerForward(double[] inputVector)
        {
            double[] outputVector = new double[neuronOutputLayer.Count];
            for(int i=0; i<neuronOutputLayer.Count; i ++)
            {
                outputVector[i] = neuronOutputLayer[i].Process(inputVector);
            }
            return outputVector;
        }

        /// <summary>
        /// Tworzenie wektora wyjsciowego z warstwy ukrytej na podstawie
        /// wektora wejsciowego
        /// </summary>
        /// <param name="inputVector"></param>
        /// <returns></returns>
        private double[] HiddenLayerForward(double[] inputVector)
        {
            double[] outputVector = new double[neuronHiddenLayer.Count];
            for (int i = 0; i < outputVector.Length; i++)
            {
                outputVector[i] = neuronHiddenLayer[i].Process(inputVector);
            }
            return outputVector;
        }


        public override int Classificate(double[] vector)
        {
            double vMax = Double.MinValue;
            double[] output = NetworkOutputVector(vector);

            int max = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] > vMax)
                {
                    max = i;
                    vMax = output[i];
                }
            }
            Console.Write("                ");
            //for (int i = 0; i < output.Length; i++)
            //  Console.Write("   " + output[i].ToString());
            Console.WriteLine();
            return max;

        }

        private double[] NetworkOutputVector(double[] vector)
        {
            double[] result = new double[neuronHiddenLayer.Count];
            for (int i = 0; i < neuronHiddenLayer.Count; i++)
            {
                result[i] = neuronHiddenLayer[i].Process(vector);
            }
            double[] output = new double[neuronOutputLayer.Count];

            for (int i = 0; i < neuronOutputLayer.Count; i++)
            {
                output[i] = neuronOutputLayer[i].Process(result);
            }
            return output;
        }
        //druga proba
        //private double[] NetworkOutputVector(double[] vector)
        //{
        //    return Matrix.Multiply(this.CreateGreenMatrix(), vector);
        //}



        #endregion

        //dodałem TOMEK
        public static RadialNetwork TestSave()
        {
            RadialNetwork rn = new RadialNetwork();
            rn.outputLayerNeutonWeights.Add(new double[] {1.0});
            rn.outputData = new List<double[]>();
            rn.outputData.Add(new double[] { 1.0 });
            //rn.greenMatrix = new double[1, 1];
            //rn.greenMatrix[0, 0] = 2;

            
            rn.neuronOutputLayer[0] = (INeuron)RadialNeuron.TestSave();
            Console.Out.WriteLine(rn.outputLayerNeutonWeights[0][0]);
            Console.Out.WriteLine(rn.outputData[0][0]);
            Console.Out.WriteLine(rn.neuronHiddenLayer.Count);
            Console.Out.WriteLine(rn.neuronOutputLayer.Count);
            //Console.Out.WriteLine(rn.greenMatrix[0, 0]);

            return rn;
        }

        //dodałem TOMEK
        public static void TestLoad(RadialNetwork rn)
        {
            Console.Out.WriteLine();
            
            RadialNeuron.TestLoad((RadialNeuron)rn.neuronOutputLayer[0]);
            Console.Out.WriteLine(rn.outputLayerNeutonWeights[0][0]);
            Console.Out.WriteLine(rn.outputData[0][0]);
            Console.Out.WriteLine(rn.neuronHiddenLayer.Count);
            Console.Out.WriteLine(rn.neuronOutputLayer.Count);
            //Console.Out.WriteLine(rn.greenMatrix[0, 0]); 

        }

    }
}
