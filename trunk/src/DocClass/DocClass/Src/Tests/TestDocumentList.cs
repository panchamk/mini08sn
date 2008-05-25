using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.Tests
{
    class TestDocumentList: DocumentList
    {
        int count, dims;

        public TestDocumentList(int count, int dims)
        {
            this.count = count;
            this.dims = dims;
        }

        public override List<Document> GetAllDataRandomized()
        {
            List<Document> result = new List<Document>();
            for (int i = 0; i < this.count; i++)
            {
                Document d = new TestDocument(this.dims);
                d.GetValues();
                result.Add(d);
            }
            return result;
            return null;
        }

        public override List<double> GetMinValues()
        {
            List<double> r = new List<double>();
            for(int i= 0; i<3; i++)
                r.Add(0);
            return r;
        }

        public override List<double> GetMaxValues()
        {
            List<double> r = new List<double>();
            for (int i = 0; i < 3; i++)
                r.Add(1);
            return r;
        }
    }
}
