using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Classification;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Reprezentuje list� kategorii.
    /// </summary>
    class CategoryList
    {
        //private List<List<WordCountPair>> categoryList;
        private List<Category> categoryList;
        /// <summary>
        /// Tworzy nowy obiekt na podstawie wcze�niej wygenerowanych plik�w podsumowuj�cyh kategorie.
        /// </summary>
        /// <param name="directoryName">Katalog zawieraj�cy pliki podsumowuj�ce kategorie.</param>
        /// <param name="filePattern">Wzorzec plik�w zawieraj�cyh podsumowanie kategorii (np. odpowiednie
        /// rozszerzenie. Zaleca si� stosowanie sta�ych z klasy PreprocessingConsts.</param>
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
        /// Zwraca kategori� o podanym indeksie.
        /// </summary>
        /// <param name="index">Indeks kategorii.</param>
        /// <returns>Kategoria o podanym indeksie.</returns>
        public Category this[int index]
        {
            get { return categoryList[index]; }
        }
        /// <summary>
        /// Zwraca kategori� o podanej nazwie.
        /// </summary>
        /// <param name="categoryName">Nazwa kategorii.</param>
        /// <returns>Kateogria o podanej nazwie lub null, je�li nie ma jej na li�cie.</returns>
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
        /// Zwraca ilo�� kategorii, dla kt�rej przechowywane s� listy.
        /// </summary>
        public int CategoryCount
        {
            get { return categoryList.Count; }
        }
    }
}
