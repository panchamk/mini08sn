using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    interface IDictionary
    {
        Dictionary<String, Double> ToMap();
        int GetDesiredOutput();
    }
}
