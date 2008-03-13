using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    class OwnDocument : IDocument
    {
        #region IDocument Members

        public int getSpaceDimensionNumber()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public double[] toVector()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool addWord(string word)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
