using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    class FixedDictionary : IDictionary
    {
        #region IDictionary Members

        public Dictionary<string, double> ToMap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDictionary Members

        //Pytanie, czy to powinno tu jednak byc?
        public int GetDesiredOutput()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
