﻿using System;
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
                    return "Binrna";
                case DocumentRepresentationType.Own:
                    return "Tf";
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
