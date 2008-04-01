﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DocClass.Src.Exceptions;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning.MathOperations;

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
        
        //neurony radialne warstwy ukrytej
        private Collection<INeuron> neuronHiddenLayer;



        //centra funkcji gaussa
        private List<double[]> cellCenters;

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
            cellCenters = new List<double[]>();
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

        


        //TODO: Sprawdzic
        /// <summary>
        /// Tworzy macierz greena na podstawie wektorw uczacych i wyznaczonych wektorow
        /// centralnych komorek
        /// </summary>
        /// <returns></returns>
        private double[,] CreateGreenMatrix()
        {
            double[,] result = new double[learningData.DataVectors.Count, neuronHiddenLayer.Count + 1];
            for (int y = 0; y < learningData.DataVectors.Count; y++)
            {
                for (int x = 0; x < neuronHiddenLayer.Count + 1; x++)
                {
                    if (x == 0)
                        result[y, x] = 1;
                    else
                    {
                        result[y, x] = ((RadialNeuron)neuronHiddenLayer[x-1]).GaussianFunction(learningData.InputVectors[y]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Uczenie warstwy wyjsciowej
        /// </summary>
        /// <param name="outputDesirableData"></param>
        private void OutputLayerLearning(List<double[]> outputDesirableData)
        {
            double[,] greenmatrix = Pseudoinverse.Solve(CreateGreenMatrix());
            for (int i = 0; i < neuronOutputLayer.Count ; i++)
            {
                outputLayerNeutonWeights.Add(Matrix.Multiply(greenmatrix, outputDesirableData[i]));
            }
        }

        #endregion

        #region overriden methods
        /// <summary>
        /// Procedura uczenia
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public override bool Learn(Dictionary dict)
        {
            this.learningData = dict;

            //TODO: to ma byc w petli
            OutputLayerLearning(learningData.OutputVectors);
            HiddenLayerLearning();
            //koniec petli z warunkiem
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// Uczenie warstwy ukrytej neuronow radialnych
        /// </summary>
        private void HiddenLayerLearning()
        {
            for (int i = 0; i < learningData.DataVectors.Count; i++)
            {
                double[] hiddenOutput = HiddenLayerForward(learningData.InputVectors[i]);
                double[] outputLayer = OutputLayerForward(hiddenOutput);
                double[] errorFactorVector = ComputeErrors(outputLayer, learningData.DataVectors[i].OutputVector);
                CorrectErrorsInHiddenLayer(errorFactorVector);
            }
            throw new Exception("The method or operation is not implemented.");
        }

        #region hidden layer error correction

        /// <summary>
        /// Poprawa wspolczynnikow neuronow warstwy ukrytej
        /// </summary>
        /// <param name="errorFactorVector"></param>
        private void CorrectErrorsInHiddenLayer(double[] errorFactorVector)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Funkcja z definicji
        /// Uzywana do poprawy wspolczynnikow warstwy ukrytej neuronow
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private double u(int i, int k, double[] x)
        {
            double result = 0;
            for (int ii = 0; ii < x.Length; ii++)
            {
                //x[i] - c
            }

            return result;
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
        public override int Classificate(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            return this.Classificate(this.learningData.FitDocumentToVector(doc));
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
            throw new NotImplementedException();
        }

        #endregion


    }
}
