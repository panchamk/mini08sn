﻿using System;
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
        protected Dictionary learningData;
        #endregion

        #region abstaract methods
        /// <summary>
        /// Calosc zwiazana z uczeniem klasyfikatora
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public abstract bool Learn(Dictionary dict);

        //TODO: Czy rzeczywicie IDocument, a nie IDictionary?
        /// <summary>
        /// Klasyfikacja dokumentu
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public abstract int Classificate(IDocument doc);
        public abstract int Classificate(double[] vector);
        #endregion

        #region public methods
        #endregion

        #region protected methods
        #endregion

    }
}
