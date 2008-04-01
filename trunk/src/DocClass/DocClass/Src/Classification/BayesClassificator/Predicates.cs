using System;

namespace DocClass.Src.Classification.BayesClassificator
{
    /// <summary>
    /// Klasa zawierajaca predykaty obslugujace struktury danych
    /// zawierajace obiekty typu Node.
    /// </summary>
    public static class Predicates
    {
        /// <summary>
        /// Delegat wyszukuje obiekt zawierajacy podane slowo.
        /// </summary>
        /// <param name="word">Klucz po jakim wyszukujemy.</param>
        /// <returns>True jesli dany obiekt zawiera dane slowo, 
        /// false w przeciwnym przypadku.</returns>
        public static Predicate<Node> GetForWord(string word)
        {
            return delegate(Node node)
            {
                return node.Word.Equals(word);
            };
        }
    }
}
