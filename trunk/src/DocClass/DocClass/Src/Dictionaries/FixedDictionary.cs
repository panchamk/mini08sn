using System;
using System.Collections.Generic;
using System.Text;

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
