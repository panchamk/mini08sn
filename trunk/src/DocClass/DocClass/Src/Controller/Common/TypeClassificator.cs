using System;

namespace DocClass.Src.Controller.Common
{
    /// <summary>
    /// Typ klasyfikatora.
    /// </summary>
    public enum TypeClassificator : ushort
    {
        /// <summary>
        /// Klasyfikator Bayes'owski.
        /// </summary>
        Bayes = 0,

        /// <summary>
        /// Siec neuronowa radialna.
        /// </summary>
        RadialNetwork = 1,

        /// <summary>
        /// Zaden klasyfikator nie zostal wybrany.
        /// </summary>
        None = 2
    }
}
