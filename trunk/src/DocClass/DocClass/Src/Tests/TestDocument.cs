using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;

namespace DocClass.Src.DocumentRepresentation
{
    class TestDocument : Document
    {
        static Random r = new Random();
        int dims;

        List<double> result;

        public TestDocument() : base() { }
        public TestDocument(int dims)
            : base()
        {
            this.dims = dims;
        }

        public override List<double> GetValues()
        {
            result = new List<double>();
            for (int i = 0; i < dims; i++)
            {
                result.Add(r.NextDouble());
            }
            return result;
        }

        public override int ClassNo
        {
            get
            {
                return classBelonings(result);
            }
        }

        public static int classBelonings(List<double> result)
        {
            if (result[0] < 0.33)
            {
                if (result[1] < 0.33)
                {
                    if (result[2] < 0.33)
                    {
                        return 0;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else if (result[1] < 0.66)
                {
                    if (result[2] < 0.33)
                    {
                        return 3;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 4;
                    }
                    else
                    {
                        return 5;
                    }
                }
                else
                {
                    if (result[2] < 0.33)
                    {
                        return 6;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 7;
                    }
                    else
                    {
                        return 8;
                    }
                }
            }
            else if (result[0] < 0.66)
            {
                if (result[1] < 0.33)
                {
                    if (result[2] < 0.33)
                    {
                        return 9;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 10;
                    }
                    else
                    {
                        return 11;
                    }
                }
                else if (result[1] < 0.66)
                {
                    if (result[2] < 0.33)
                    {
                        return 12;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 13;
                    }
                    else
                    {
                        return 14;
                    }
                }
                else
                {
                    if (result[2] < 0.33)
                    {
                        return 15;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 16;
                    }
                    else
                    {
                        return 17;
                    }
                }
            }
            else
            {
                if (result[1] < 0.33)
                {
                    if (result[2] < 0.33)
                    {
                        return 18;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 19;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (result[1] < 0.66)
                {
                    if (result[2] < 0.33)
                    {
                        return 1;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (result[2] < 0.33)
                    {
                        return 4;
                    }
                    else if (result[2] < 0.66)
                    {
                        return 5;
                    }
                    else
                    {
                        return 6;
                    }
                }
            }
        }
    }
}
