using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    interface IDocument
    {
        int GetSpaceDimensionNumber();
        Dictionary<String, double> ToMap();
        bool AddWord(string word);
        int DesiredOutput { get; }

    }
}
