using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Dictionaries
{
    class DictionaryTypeUtil
    {
        public static String ToString(DictionaryType dictionaryType)
        {
            switch (dictionaryType)
            {
                case DictionaryType.CtfIdf:
                    return "CtfIdf";
                case DictionaryType.Fixed:
                    return "Fixed";
                case DictionaryType.Frequent:
                    return "Frequent";
                default:
                    throw new Exception("Methode not implemented for this type.");
            }
        }

        public static String ToString(int value)
        {
            return ToString((DictionaryType)value);
        }
    }
}
