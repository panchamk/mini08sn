using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    class OwnDocument : IDocument
    {
        #region IDocument Members

        public int GetSpaceDimensionNumber()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public double[] ToVector()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool AddWord(string word)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
