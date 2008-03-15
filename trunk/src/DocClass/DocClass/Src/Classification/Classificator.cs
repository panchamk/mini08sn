using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Dictionaries;
using DocClass.Src.Learning;

namespace DocClass.src.classification
{
    abstract class Classificator
    {
        #region private members
        private List<IDictionary> dictionaries;

        #endregion

        #region protected members
        protected List<LearningPair> learningData;

        #endregion

        #region abstaract methods

        /// <summary>
        /// Calosc zwiazana z uczeniem klasyfikatora
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public abstract bool Learn(IDictionary[] docs);

        //TODO: Czy rzeczywicie IDocument, a nie IDictionary?
        /// <summary>
        /// Klasyfikacja dokumentu
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public abstract int Classificate(IDocument doc);

        #endregion

        #region public methods

        /// <summary>
        /// Dodawanie slownika. Dla wiekszej ilosci slownikow dodawac przez AddDictionaries
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool AddDictionary(IDictionary dict)
        {
            //TODO: napisac dodawanie slownika razem z mergowaniem wymiarow zadania
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dodawanie wiekszej ilosci slownikow
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool AddDictionaries(IDictionary[] dict)
        {
            //TODO: napisa dodawanie wielu slownikow razem z mergowaniem wymiarow zadania
            throw new NotImplementedException();
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Tworzenie listy par uczacych
        /// </summary>
        /// <returns></returns>
        protected List<LearningPair> CreateLearningData()
        {
            //TODO: tworzenie tablicy wszystkich danych ze slownikow (wektory pionowo) 
            // na podstawie dictionaries
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Tworzy liste wektorow wyjsciowych (dla kazdego neuronu wyjsciowego jest to osobny wektor
        /// na liscie) na podstawie listy LearningData. Kazdy wektor odpowiada jednemu neuronowi wyjsciowemu.
        /// Jedynka jest ustawiana wtedy, gdy odpowiadajacy w learningData.Output jest liczba wskazujaca na 
        /// ten neuron wyjsciowy. Zero w przeciwnym wypadku.
        /// </summary>
        /// <returns></returns>
        protected List<double[]> CreateLearningDesiredOutputData() 
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
