using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    class TfIdfDocument : IDocument
    {

        #region IDocument Members

        public int GetSpaceDimensionNumber()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Dictionary<string, double> ToMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool AddWord(string word)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DesiredOutput
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
