using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Classification;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Reprezentuje list� list obiekt�w typu WordCountPair dla wszystkich kategorii.
    /// </summary>
    class CategoryList
    {
        private List<List<WordCountPair>> categoryList;
        /// <summary>
        /// Tworzy nowy obiekt na podstawie wcze�niej wygenerowanych plik�w podsumowuj�cyh kategori�.
        /// </summary>
        /// <param name="directoryName">Katalog zawieraj�cy pliki podsumowuj�ce kategorie.</param>
        /// <param name="filePattern">Wzorzec plik�w zawieraj�cyh podsumowanie kategorii (np. odpowiednie
        /// rozszerzenie. Zaleca si� stosowanie sta�ych z klasy PreprocessingConsts.</param>
        public CategoryList(String directoryName, String filePattern)
        {
            categoryList = new List<List<WordCountPair>>();
            for (int i=0; i<DocumentClass.CategoriesCount;i++)
                categoryList.Add(new List<WordCountPair>());
            DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
            foreach (FileInfo fileInfo in dirInfo.GetFiles(filePattern))
            {
                //utworzenie nowej listy
                int categoryIndex = DocumentClass.GetClassIndex(Path.GetFileNameWithoutExtension(fileInfo.Name));
                //wczytanie danych z pliku
                StreamReader sr = new StreamReader(fileInfo.FullName);
                String tmpString = sr.ReadToEnd();
                sr.Close();
                //dodanie poszczeg�lnych par do listy
                String[] splittedTmpString = tmpString.Split(Environment.NewLine.ToCharArray());
                foreach (String line in splittedTmpString)
                    if (line.Length > 0) 
                        categoryList[categoryIndex].Add(WordCountPair.Parse(line));
            }
        }
        /// <summary>
        /// Zwraca list� WordCountPair dla danej kategorii.
        /// </summary>
        /// <param name="index">Indeks kategorii.</param>
        /// <returns>Lista WordCountPair dla danej kategorii.</returns>
        public List<WordCountPair> this[int index]
        {
            get { return categoryList[index]; }
        }
        /// <summary>
        /// Zwraca list� WordCountPair dla danej kategorii.
        /// </summary>
        /// <param name="categoryName">Nazwa kategorii.</param>
        /// <returns>Lista WordCountPair dla danej kategorii.</returns>
        public List<WordCountPair> this[string categoryName]
        {
            get { return categoryList[DocumentClass.GetClassIndex(categoryName)]; }
        }
    }
}
