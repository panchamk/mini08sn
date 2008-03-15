using System;
using System.Collections.Generic;
using System.Text;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Dictionaries;

namespace DocClass.src.classification
{
    abstract class Classificator
    {
        List<IDictionary> dictionaries;

        public abstract bool Learn(IDictionary[] docs);

        //TODO: Czy rzeczywicie IDocument, a nie IDictionary?
        public abstract int Classificate(IDocument doc);

        public bool AddDictionary(IDictionary dict)
        {
            //TODO: napisac dodawanie slownika razem z mergowaniem wymiarow zadania
            throw new NotImplementedException();
        }

        public bool AddDictionaries(IDictionary[] dict)
        {
            //TODO: napisa dodawanie wielu slownikow razem z mergowaniem wymiarow zadania
            throw new NotImplementedException();
        }
    }
}
