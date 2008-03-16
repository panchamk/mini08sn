using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DocClass.Src.Exceptions;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning.MathOperations;

namespace DocClass.src.classification.radialNetwork
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

        //sigma dla funkcji gaussa
        private double sigma = 0.5;

        //centra funkcji gaussa
        private List<double[]> cellCenters;

        //wagi poszczegolnych neuronow wyjsciowych;
        private List<double[]> outputLayerNeutonWeights;
        
        #endregion

        #region constructors

        public RadialNetwork() : this(HIDDEN_LAYER_INIT_NEURON_COUNT, OUTPUT_LAYER_NEURON_COUNT) { }

        public RadialNetwork(int hiddenLayerInitNeuronCount, int outputLayerNeuronCount)
        {
            neuronHiddenLayer = new Collection<INeuron>();
            neuronOutputLayer = new Collection<INeuron>();
            cellCenters = new List<double[]>();
            outputLayerNeutonWeights = new List<double[]>();
            for (int i = 0; i < hiddenLayerInitNeuronCount; i++)
            {
                INeuron r = new LinearNeuron();
                neuronHiddenLayer.Add(r);
            }

            for (int i = 0; i < outputLayerNeuronCount; i++)
            {
                INeuron r = new RadialNeuron();
                neuronHiddenLayer.Add(r);
            }
        }


        #endregion

        #region public methods

        #endregion

        #region private methods

        //funkcja gaussa dla neuronu
        //TODO: sprawdzic poprawnosc dzialania
        private double GaussianFunction(double[] x, double[] c)
        {
            double result = 0;
            if (x.Length != c.Length)
                throw new IncompatibleArrayLength();
            int len = x.Length;

            for (int i = 0; i < len; i++)
            {
                result += (c[i] - x[i]) * (c[i] - x[i]);
            }
            result /= -2 * sigma * sigma;
            return Math.Pow(Math.E, result);
        }


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
                        result[y, x] = GaussianFunction(learningData.DataVectors[y].Vector, cellCenters[x]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Uczenie warstwy wyjsciowej
        /// </summary>
        /// <param name="outputDesirableData"></param>
        private void OutputLearning(List<double[]> outputDesirableData)
        {
            
            for (int i = 0; i < OUTPUT_LAYER_NEURON_COUNT; i++)
            {
                outputLayerNeutonWeights[i] = Matrix.Multiply(Pseudoinverse.Solve(CreateGreenMatrix()), outputDesirableData[i]);
            }
        }


        #endregion

        #region overriden methods
        /// <summary>
        /// Procedura uczenia
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public override bool Learn(IDictionary[] docs)
        {
            OutputLearning(learningData.OutputVectors);
            throw new Exception("The method or operation is not implemented.");
        }

        public override int Classificate(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}
