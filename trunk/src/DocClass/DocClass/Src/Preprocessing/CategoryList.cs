using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Classification;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Reprezentuje listê kategorii.
    /// </summary>
    class CategoryList
    {
        //private List<List<WordCountPair>> categoryList;
        private List<Category> categoryList;
        /// <summary>
        /// Tworzy nowy obiekt na podstawie wczeœniej wygenerowanych plików podsumowuj¹cyh kategorie.
        /// </summary>
        /// <param name="directoryName">Katalog zawieraj¹cy pliki podsumowuj¹ce kategorie.</param>
        /// <param name="filePattern">Wzorzec plików zawieraj¹cyh podsumowanie kategorii (np. odpowiednie
        /// rozszerzenie. Zaleca siê stosowanie sta³ych z klasy PreprocessingConsts.</param>
        public CategoryList(String directoryName, String filePattern)
        {
            categoryList = new List<Category>();
            DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
            foreach (FileInfo fileInfo in dirInfo.GetFiles(filePattern))
            {
                Category newCategory = new Category(fileInfo.FullName);
                categoryList.Add(newCategory);
            }
        }
        /// <summary>
        /// Zwraca kategoriê o podanym indeksie.
        /// </summary>
        /// <param name="index">Indeks kategorii.</param>
        /// <returns>Kategoria o podanym indeksie.</returns>
        public Category this[int index]
        {
            get { return categoryList[index]; }
        }
        /// <summary>
        /// Zwraca kategoriê o podanej nazwie.
        /// </summary>
        /// <param name="categoryName">Nazwa kategorii.</param>
        /// <returns>Kateogria o podanej nazwie lub null, jeœli nie ma jej na liœcie.</returns>
        public Category this[string categoryName]
        {
            get 
            {
                foreach (Category c in categoryList)
                    if (c.Name.Equals(categoryName))
                        return c;
                return null;
            }
        }
        /// <summary>
        /// Zwraca iloœæ kategorii, dla której przechowywane s¹ listy.
        /// </summary>
        public int CategoryCount
        {
            get { return categoryList.Count; }
        }
    }
}
