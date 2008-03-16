using System;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    /// <summary>
    /// Klasa operujaca na wektorach.
    /// </summary>
    public class Vector
    {
        #region Public Method

        /// <summary>
        /// Oblicza iloczyn skalarny dwoch wektorow.
        /// </summary>
        /// <param name="vectorA">Wektor a.</param>
        /// <param name="vectorB">Wektor b.</param>
        /// <returns>Iloczyn skalarny dwoch wektorow.</returns>
        /// <exception cref="InvalidOperationException">Jesli iloczyn skalarny nie da sie obliczyc.</exception>
        public static double Scalar(double[] vectorA, double[] vectorB)
        {
            if (vectorA.Length != vectorB.Length)
                throw new InvalidOperationException("Mnozenie wektorow o roznych dlugosciach !");

            double value = 0;
            for (int i = 0; i < vectorA.Length; i++)
                value += vectorA[i] * vectorB[i];
            return value;
        }

        /// <summary>
        /// Przeksztalca wektor w string.
        /// </summary>
        /// <param name="vector">Wektor do konwersji.</param>
        /// <param name="ignoreFirstElement">Flaga, jesli bedzie ustawiona na true - pierszy element
        /// zostanie zignorowany. </param>
        /// <returns>Opis wektora.</returns>
        public static string ToString(double[] vector, bool ignoreFirstElement)
        {
            if (vector == null || vector.Length == 0)
                return String.Empty;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            for (int i = ignoreFirstElement ? 1 : 0; i < vector.Length; i++)
                builder.Append(String.Format("{0,5:F2} ", vector[i]));
            builder.AppendLine();
            return builder.ToString();
        }

        /// <summary>
        /// Przeksztalca wektor w obiekt typu System.String
        /// </summary>
        /// <param name="vector">Wektor do konwersji.</param>
        /// <returns>Opis wektora.</returns>
        public static string ToString(double[] vector)
        {
            return ToString(vector, false);
        }

        #endregion
    }
}
