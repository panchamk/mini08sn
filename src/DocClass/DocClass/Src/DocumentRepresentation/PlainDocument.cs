using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.DocumentRepresentation
{
    class PlainDocument:WordCountList
    {
        public PlainDocument(string fileName)
            : base(fileName)
        {
        }

    }
}
