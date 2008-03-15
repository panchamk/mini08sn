using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

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

        private Collection<INeuron> neuronOutputLayer;
        
        private Collection<INeuron> neuronHiddenLayer;
        
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

        #endregion



        public override bool Learn(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int Classificate(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
