using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocClass.Src.Learning;

namespace DocClass.Src.Dictionaries
{
    class FixedDictionary : Dictionary
    {
        public override bool Init(ICollection<DocClass.Src.DocumentRepresentation.IDocument> docs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
    }
}
