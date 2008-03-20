using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Classification
{
    class ClassyficatorTypeUtil
    {
        public static String ToString(ClasyficatorType classificatorType)
        {
            switch (classificatorType)
            {
                case ClasyficatorType.Bayes:
                    return "Bayes";
                case ClasyficatorType.RadialNeural:
                    return "RadialNeural";
                default:
                    throw new Exception("Methode not implemented for this type.");
            }
        }

        public static String ToString(int value)
        {
            return ToString((ClasyficatorType)value);
        }
    }
}
