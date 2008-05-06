using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DocClass.Src.Exceptions;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning.MathOperations;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.RadialNetwork
{
    class RadialNetwork : Classificator
    {
        #region statics

        public const int OUTPUT_LAYER_NEURON_COUNT = 20;
        
        public const int HIDDEN_LAYER_INIT_NEURON_COUNT = 1;

        public const int HIDDEN_LAYER_MAX_NEURON_COUNT = 40;



        #endregion


        #region private variables

        //neurony liniowe warstwy wyjciowej
        private Collection<INeuron> neuronOutputLayer;

        //lista wszystkich dokumentow
        private List<Document> documentList;

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


        #endregion

        #region public methods

        #endregion

        #region private methods

        /// <summary>
        /// Y liczone zgodnie ze wzorami na siec, jako iloczyn aktualnej macierzy greena i wektora wag dla danej klasy.
        /// W tym przypadku jest to wektor wejsciowy
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private double[] y(double[] w)
        {
            double[] result;
            if (greenMatrix != null)
            {
                result = Matrix.Multiply(greenMatrix, w);
            }
            else
                throw new NullReferenceException();
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
            List<Document> documentCollection = learningData.GetDocumentList();
            if(documentCollection == null || documentCollection.Count == 0)
                throw new NullReferenceException("documentCollecion puste");
            double[,] result = new double[documentCollection.Count, neuronHiddenLayer.Count+1];
            for (int y = 0; y < documentCollection.Count; y++)
            {
                for (int x = 0; x < neuronHiddenLayer.Count+1; x++)
                {
                    if (x == 0)
                        result[y, x] = 1;
                    else
                    {
                        result[y, x] = ((RadialNeuron)neuronHiddenLayer[x-1]).GaussianFunction(documentCollection[y].GetValues().ToArray());
                    }
                }
            }
//#if DEBUG
//            Console.WriteLine("CreateGreenMatrix");
//            Console.WriteLine(Matrix.ToString(result));
//#endif
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
        public override bool Learn(DocumentList docList)
        {
            if (docList == null)
                throw new NullReferenceException("docList puste");
            this.learningData = docList;
            documentList = docList.GetDocumentList();
            if (documentList == null || documentList.Count == 0)
                throw new NullReferenceException("DocumentList pusty");
            List<double[]> desiredOutputData = PrepareOutputData(documentList);
            for (int i = 0; i < 30; i++)
            {
                OutputLayerLearning(desiredOutputData);
                PrintNetworkData(neuronOutputLayer);
                HiddenLayerLearning();
                //PrintNetworkData(neuronHiddenLayer);
                HiddenLayerLearning();
                //PrintNetworkData(neuronHiddenLayer);
                HiddenLayerLearning();
                //PrintNetworkData(neuronHiddenLayer);
                HiddenLayerLearning();
                //PrintNetworkData(neuronHiddenLayer);
                HiddenLayerLearning();
                //PrintNetworkData(neuronHiddenLayer);
                HiddenLayerLearning();
                PrintNetworkData(neuronHiddenLayer);
            }
            return true;
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
                for (int j = 0; j < neuronOutputLayer.Count; j++)
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
            double maxValue;
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
            double[] result = new double[documentList.Count];
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
            //TODO: PR: klasyfikacja
            //return this.Classificate(doc.this.learningData.FitDocumentToVector(doc));
            return 0;
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
            for (int i = 0; i < output.Length; i++)
                Console.Write("   " + output[i].ToString());
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

        #endregion


    }
}
