using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.RadialNetwork
{
    interface INeuron
    {

        /// <summary>
        /// Przeprowadza klasyfikacje danych wprowadzonych do neuronu na podstawie wag neuronu
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        double Process(double[] vector);
    }
}
