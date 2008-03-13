using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.src.classification
{
    interface Classificator
    {
        bool learn(IDocument doc);
        int classificate(IDocument doc);
    }
}
