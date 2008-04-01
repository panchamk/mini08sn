using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Classification.RadialNetwork
{
    interface INeuron
    {
        /// <summary>
        /// Ustawia dane wejsiowe
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double SetInput(double[] input);

        /// <summary>
        /// Przeprowadza klasyfikacje danych wprowadzonych do neuronu na podstawie wag neuronu
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        double Process(double[] vector);
    }
}
