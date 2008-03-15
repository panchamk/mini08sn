using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.src.classification
{
    abstract class Classificator
    {
        public abstract bool learn(IDocument doc);
        public abstract int classificate(IDocument doc);
    }
}
