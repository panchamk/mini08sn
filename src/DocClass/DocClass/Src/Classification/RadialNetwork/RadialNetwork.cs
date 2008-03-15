using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DocClass.Src.Exceptions;
using DocClass.Src.Dictionaries;

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
        
        #endregion

        #region constructors

        public RadialNetwork() : this(HIDDEN_LAYER_INIT_NEURON_COUNT, OUTPUT_LAYER_NEURON_COUNT) { }

        public RadialNetwork(int hiddenLayerInitNeuronCount, int outputLayerNeuronCount)
        {
            neuronHiddenLayer = new Collection<INeuron>();
            neuronOutputLayer = new Collection<INeuron>();
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

        private double[,] CreateGreenMatrix(double[] x)
        {
            double[,] result = new double[x.Length, neuronHiddenLayer.Count + 1];
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < neuronHiddenLayer.Count + 1; j++)
                {
                    if (j == 0)
                        result[i, j] = 1;
                    else
                    {

                    }
                }
            }
            return null;
        }

        #endregion



        public override bool Learn(IDictionary[] docs)
        {

            throw new Exception("The method or operation is not implemented.");
        }

        public override int Classificate(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
