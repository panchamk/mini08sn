﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    interface IDictionary
    {
        Dictionary<String, double> ToMap();
        int GetDesiredOutput();
    }
}
