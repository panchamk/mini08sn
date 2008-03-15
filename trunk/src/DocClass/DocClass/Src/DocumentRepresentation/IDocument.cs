using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    interface IDocument
    {
        int GetSpaceDimensionNumber();
        double[] ToVector();
        bool AddWord(string word);
    }
}
