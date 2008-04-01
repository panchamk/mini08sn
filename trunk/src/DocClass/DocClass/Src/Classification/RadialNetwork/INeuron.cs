using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.RadialNetwork
{
    interface INeuron
    {
        double SetInput(double[] input);
        double Process(double[] vector);
    }
}
