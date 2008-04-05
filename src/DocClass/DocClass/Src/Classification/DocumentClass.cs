using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DocClass.Src.Classification
{
    /// <summary>
    /// Reprezentuje liste klas dostêpnych w danym czasie.
    /// </summary>
    static class DocumentClass
    {
        private static List<String> documentCategories = new List<String>();


        /// <summary>
        /// Zwraca iloœæ dostêpnych kategorii.
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
        /// £aduje listê kategorii na podstawie plików podsumowuj¹cyh kategoriê.
        /// </summary>
        /// <param name="sourceDir">Katalog zawieraj¹cy pliki podsumowuj¹cte kategorie.</param>
        /// <param name="pattern">Wzorzec plików zawieraj¹cyh podsumowanie kategorii (np. odpowiednie
        /// rozszerzenie. Zaleca siê stosowanie sta³ych z klasy PreprocessingConsts.</param>
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
            return documentCategories.IndexOf(className);
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
