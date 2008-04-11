using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.DocumentRepresentation
{
    abstract class Document
    {
        protected int ClassNo = -1;
        protected WordCountList wordCountList;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WordCountPair wordCountPair in wordCountList)
                sb.AppendFormat("{0} {1}\n", wordCountPair.Word, wordCountPair.Count);

            return sb.ToString();
        }
    }
}
