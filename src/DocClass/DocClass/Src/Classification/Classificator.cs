using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning;

namespace DocClass.Src.Classification
{
    abstract class Classificator
    {
        #region private members
        #endregion

        #region protected members
        protected DocumentList learningData;
        #endregion

        #region abstaract methods
        /// <summary>
        /// Calosc zwiazana z uczeniem klasyfikatora
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public abstract bool Learn(Object list);

        /// <summary>
        /// Klasyfikacja dokumentu
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public abstract int Classificate(Document doc);

        /// <summary>
        /// Klasyfikacja wektora
        /// Wykona sie poprawnie przy zalozeniu, ze odpowiednie wspolrzedne wektora
        /// odpowiadaja odpowiednim wspolrzednym wektorow uczacych
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public abstract int Classificate(double[] vector);
        #endregion

        #region public methods
        #endregion

        #region protected methods
        #endregion

    }
}
