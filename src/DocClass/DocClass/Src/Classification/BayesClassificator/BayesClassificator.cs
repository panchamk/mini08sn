using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;

namespace DocClass.src.classification.beyesClassificator
{
    class BayesClassificator : Classificator
    {

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
