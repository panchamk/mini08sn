using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Classification
{
    static class DocumentClass
    {
        private static List<String> documentCathegories = new List<String>();

        public static int CathegoriesCount
        {
            get
            {
                return documentCathegories.Count;
            }
        }

        public static void addClass(String className)
        {
            if (!documentCathegories.Contains(className))
                documentCathegories.Add(className);
        }
        //TODO: Zrobic dodawanie i pobieranie klas
    }
}
