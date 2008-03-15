using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Dictionaries;

namespace DocClass.src.classification
{
    abstract class Classificator
    {
        public abstract bool Learn(IDictionary[] docs);

        //TODO: Czy rzeczywicie IDocument, a nie IDictionary?
        public abstract int Classificate(IDocument doc);
    }
}
