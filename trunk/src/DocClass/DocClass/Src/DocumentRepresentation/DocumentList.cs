using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.Dictionaries;
using System.IO;
using DocClass.Src.Preprocessing;

namespace DocClass.Src.DocumentRepresentation
{
    class DocumentList
    {
        private Stack<int> indexStack = null;
        private List<Document> documentList;
        /// <summary>
        /// Sprawdza czy podane parametry s¹ zgodne z parametrami dla plików zapisanych na liœcie.
        /// Jeœli nie ma zgodnoœci, to rzuca wyj¹tek.
        /// </summary>
        /// <param name="dtr">Typ dokumentu</param>
        /// <param name="dt">Typ s³ownika</param>
        private void CheckCorrectness(DocumentRepresentationType dtr, DictionaryType dt)
        {
            if (documentList.Count > 0)
            {
                Document tmpDocument = documentList[0];
                if (tmpDocument.GetDocumentRepresentationType() != dtr || tmpDocument.DictionaryType != dt)
                    throw new Exception("Can't add document. RepresentationType or DictionaryType differs from others in the list.");
            }

        }
        /// <summary>
        /// Tworzy pust¹ listê.
        /// </summary>
        public DocumentList()
        {
            documentList = new List<Document>();
        }
        /// <summary>
        /// Tworzy listê na podstawie katalogu z plikami w postaci s³owo, iloœæ wyst¹pieñ.
        /// </summary>
        /// <param name="sourceDir">Katalog z plikami.</param>
        /// <param name="dictionary">Rodzaj s³ownika, który ma byæ u¿yty do tworzenia nowych dokumentów.</param>
        /// <param name="drt">Rodzaj dokumentów.</param>
        /// <param name="className">Nazwa klasy, do której maj¹ nale¿eæ wszystkie nowo dodane elementu lub null, jeœli klasa jest nieznana.</param>
        /// <param name="learningDocInfo">Obiekt zawieraj¹cy informacje o wszystkich dokumentach ucz¹cych.
        /// Je¿eli dana reprezentacja nie potrzebuje tego obiektu, parametr jest ignorowany.</param>
        public DocumentList(String sourceDir, Dictionary dictionary, DocumentRepresentationType drt, String className, LearningDocInfo learningDocInfo)
        {
            documentList = new List<Document>();
            AddDocumentsFromDir(sourceDir, dictionary, drt, className, learningDocInfo);
        }
        /// <summary>
        /// Dodaje listê dokumentów na podstawie katalogu z plikami w postaci s³owo, iloœæ wyst¹pieñ.
        /// </summary>
        /// <param name="sourceDir">Katalog z plikami.</param>
        /// <param name="dictionary">Rodzaj s³ownika, który ma byæ u¿yty do tworzenia nowych dokumentów.</param>
        /// <param name="drt">Rodzaj dokumentów.</param>
        /// <param name="className">Nazwa klasy, do której maj¹ nale¿eæ wszystkie nowo dodane elementu lub null, jeœli klasa jest nieznana.</param>
        /// <param name="learningDocInfo">Obiekt zawieraj¹cy informacje o wszystkich dokumentach ucz¹cych.
        /// Je¿eli dana reprezentacja nie potrzebuje tego obiektu, parametr jest ignorowany.</param>
        public void AddDocumentsFromDir(String sourceDir, Dictionary dictionary, DocumentRepresentationType drt, String className, LearningDocInfo learningDocInfo)
        {
            CheckCorrectness(drt, dictionary.GetDictionaryType());

            Console.WriteLine("Adding dir: " + sourceDir);

            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo fileInfo in sourceDirInfo.GetFiles())
            {
                Console.WriteLine("Adding file: " + fileInfo.FullName);
                switch (drt)
                {
                    case DocumentRepresentationType.TfIdf:
                        documentList.Add(new TfIdfDocument(fileInfo.FullName, dictionary, className, learningDocInfo));
                        break;
                    case DocumentRepresentationType.Binary:
                        documentList.Add(new BinaryDocument(fileInfo.FullName, dictionary, className));
                        break;
                    case DocumentRepresentationType.Own:
                        documentList.Add(new OwnDocument(fileInfo.FullName, dictionary, className));
                        break;
                    default:
                        throw new Exception("Unknown DocumentRepresentationType: " + drt);
                }
            }
        }
        /// <summary>
        /// Dodaje dokument do listy.
        /// </summary>
        /// <param name="document">Dokument do dodania.</param>
        public void AddDocument(Document document)
        {
            CheckCorrectness(document.GetDocumentRepresentationType(), document.DictionaryType);
            documentList.Add(document);
        }
        /// <summary>
        /// Zwraca wektor z maksymaln¹ wartoœci¹ na ka¿dej wspó³rzêdnej.
        /// </summary>
        /// <returns>Wektor z maksymaln¹ wartoœci¹ na ka¿dej wspó³rzêdnej.</returns>
        public List<double> GetMaxValues()
        {
            if (documentList.Count == 0)
                throw new Exception("Document list is empty");
            List<double> result = new List<double>(documentList[0].GetValues()); //inicjujê rezultat pierwszym wektorem
            foreach (Document document in documentList) //przechodze po wszystkich dokumentach
                for (int i = 0; i < result.Count; i++) //przechodze po kazdej wspolrzednej
                {
                    List<double> tmpValues = document.GetValues();
                    if (tmpValues[i] > result[i])
                        result[i] = tmpValues[i];
                }
            return result;

        }
        /// <summary>
        /// Zwraca wektor z minimaln¹ wartoœci¹ na ka¿dej wspó³rzêdnej.
        /// </summary>
        /// <returns>Wektor z minimaln¹ wartoœci¹ na ka¿dej wspó³rzêdnej.</returns>
        public List<double> GetMinValues()
        {
            if (documentList.Count == 0)
                throw new Exception("Document list is empty");
            List<double> result = new List<double>(documentList[0].GetValues()); //inicjujê rezultat pierwszym wektorem
            foreach (Document document in documentList) //przechodze po wszystkich dokumentach
                for (int i = 0; i < result.Count; i++) //przechodze po kazdej wspolrzednej
                {
                    List<double> tmpValues = document.GetValues();
                    if (tmpValues[i] < result[i])
                        result[i] = tmpValues[i];
                }
            return result;

        }
        /// <summary>
        /// Zwraca listê dokumentów.
        /// </summary>
        /// <returns>Lista dokumentów.</returns>
        public List<Document> GetDocumentList()
        {
            return documentList;
        }

        /// <summary>
        /// Zwraca listê wartoœci dla wszystkich dokumentów.
        /// </summary>
        /// <returns>Lista wartoœci dla wszystkich dokumentów.</returns>
        public List<List<double>> GetValuesList()
        {
            List<List<double>> result = new List<List<double>>();
            foreach (Document document in documentList)
                result.Add(document.GetValues());
            return result;
        }

        public void Randomize()
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < documentList.Count; i++) //tworze liste kolejnych liczb
                indexList.Add(i);
            while (indexList.Count > 0)
            {
                Random r = new Random();
                int index = r.Next() % indexList.Count;
                indexStack.Push(indexList[index]); //dodaje kolejny indeks na stos
                indexList.RemoveAt(index); //usuwam indeks
            }

        }
        /// <summary>
        /// Zwraca kolejny element listy w kolejnoœci losowej. Przed pierwszym u¿yciem nale¿y u¿yæ metody
        /// Randomize, ¿eby wylosowaæ kolejnoœæ elementów.
        /// </summary>
        /// <returns>Kolejny dokument  lub null, jeœli wszystkie elementy zosta³y wybrane.</returns>
        public Document nextRandomDocument()
        {
            if (indexStack == null) //jesli pierwsze wywolanie, to losuje kolejne indeksy
                throw new Exception("List isn't randomize. Use Randomize method first.");
            if (indexStack.Count > 0)
                return documentList[indexStack.Pop()]; //zwraca dokument i usuwa indeks ze stosu
            else
                return null;
        }
        /// <summary>
        /// Zwraca kolejny wektor wartoœci. Przed pierwszym u¿yciem nale¿y u¿yæ metody
        /// Randomize, ¿eby wylosowaæ kolejnoœæ elementów.
        /// </summary>
        /// <returns>Kolejny wektor wartoœci lub null, jeœli wszystkie elementy zosta³y wybrane.</returns>
        public List<double> nextRandomValues()
        {
            Document resultDocument = nextRandomDocument();
            if (resultDocument != null)
                return resultDocument.GetValues();
            else
                return null;
        }

    }
}
