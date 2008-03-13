using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    interface IDocument
    {
        int getSpaceDimensionNumber();
        double[] toVector();
        bool addWord(string word);
    }
}
