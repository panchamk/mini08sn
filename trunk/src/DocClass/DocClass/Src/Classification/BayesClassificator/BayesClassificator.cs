using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;

namespace DocClass.src.classification.beyesClassificator
{
    class BayesClassificator : Classificator
    {

        public override bool Learn(Dictionary dict)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int Classificate(DocClass.Src.DocumentRepresentation.IDocument doc)
        {
            return this.Classificate(this.learningData.FitDocumentToVector(doc));
        }

        public override int Classificate(double[] vector)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
