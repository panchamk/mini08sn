using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Classification
{
    /// <summary>
    /// Reprezentuje liste klas dost�pnych w danym czasie.
    /// </summary>
    static class DocumentClass
    {
        private static List<String> documentCategories = new List<String>();

        public static List<String> DocumentCategories
        {
            get { return DocumentClass.documentCategories; }
            set { DocumentClass.documentCategories = value; }
        }


        /// <summary>
        /// Zwraca ilo�� dost�pnych kategorii.
        /// </summary>
        public static int CategoriesCount
        {
            get
            {
                return documentCategories.Count;
            }
        }

        public static void AddClass(String className)
        {
            if (!documentCategories.Contains(className))
                documentCategories.Add(className);
        }

        /// <summary>
        /// �aduje list� kategorii na podstawie plik�w podsumowuj�cyh kategori�.
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj�cy pliki podsumowuj�cte kategorie.</param>
        /// <param name="pattern">Wzorzec plik�w zawieraj�cyh podsumowanie kategorii (np. odpowiednie
        /// rozszerzenie. Zaleca si� stosowanie sta�ych z klasy PreprocessingConsts.</param>
        public static void LoadFromFiles(String sourceDir, String pattern)
        {
            documentCategories.Clear();
            DirectoryInfo SourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo fileInfo in SourceDirInfo.GetFiles(pattern))
                documentCategories.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
        }

        /// <summary>
        /// Zwraca indeks klasy na podstawie nazwy.
        /// </summary>
        /// <param name="className">Nazwa klasy.</param>
        /// <returns>Indeks klasy.</returns>
        public static int GetClassIndex(String className)
        {
            int index = documentCategories.IndexOf(className);
            if (index == -1)
                throw new Exception(String.Format("Class: {0} doesn't exist.", className));
            return index;
            
            //return documentCategories.IndexOf(className);
        }

        /// <summary>
        /// Zwraca nazwe kategorii na podstawie indeksu.
        /// </summary>
        /// <param name="index">Index kategorii.</param>
        /// <returns></returns>
        public static string GetClassName(int index)
        {
            return documentCategories[index];
        }

        //TODO: Zrobic dodawanie i pobieranie klas
        public static new String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in documentCategories)
                sb.AppendLine(s);
            return sb.ToString();
        }
    }
}
