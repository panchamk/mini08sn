using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.DocumentRepresentation
{
    class DocumentRepresentationTypeUtil
    {
        public static String ToString(DocumentRepresentationType documentRepresentationType)
        {    
            switch (documentRepresentationType)
            {
                case DocumentRepresentationType.Binary:
                    return "Binary";
                case DocumentRepresentationType.Own:
                    return "Own";
                case DocumentRepresentationType.TfIdf:
                    return "TfIdf";
                default:
                    throw new Exception("Methode not implemented for this type.");
            }
        }

        public static String ToString(int value)
        {
            return ToString((DocumentRepresentationType)value);
        }
    }
}
