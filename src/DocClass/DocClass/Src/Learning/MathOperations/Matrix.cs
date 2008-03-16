using System;
using System.Text;

namespace DocClass.Src.Learning.MathOperations
{
    /// <summary>
    /// Zawiera wszystkie potrzebne operacje na macierzach.
    /// </summary>
    public static class Matrix
    {
        #region Public Methods

        /// <summary>
        /// Operacja transpozycji.
        /// </summary>
        /// <param name="matrix">Macierz poddana transpozycji.</param>
        /// <returns>Macierz transponowana do parametru.</returns>
        public static double[,] Transposition(double[,] matrix)
        {
            int width = matrix.GetLength(1);
            int lenght = matrix.GetLength(0);
            double[,] newMatrix = new double[width, lenght];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < lenght; j++)
                    newMatrix[i, j] = matrix[j, i];
            return newMatrix;
        }

        /// <summary>
        /// Operacja transpozycji wraz z odwrotnoscia
        /// kazdego niezerowego elemnetu.
        /// Aij->1/Aji
        /// </summary>
        /// <param name="matrix">Macierz poddana przeksztalceniu.</param>
        /// <returns>Wynik przesztalcen.</returns>
        public static double[,] Reciprocal(double[,] matrix)
        {
            double[,] transform = Transposition(matrix);
            int width = transform.GetLength(1);
            int lenght = transform.GetLength(0);
            for (int j = 0; j < width; j++)
                for (int i = 0; i < lenght; i++)
                {
                    if (transform[i, j] != 0)
                        transform[i, j] = 1 / transform[i, j];
                }
            return transform;
        }

        /// <summary>
        /// Tworzy macierz o podanych rozmiarach oraz inicjuje diagonal
        /// podanym wektorem.
        /// </summary>
        /// <param name="diagonal">Wektor diagonali.</param>
        /// <param name="width">Szerokosc macierzy.</param>
        /// <param name="lenght">Wysokosc macierzy.</param>
        /// <returns>Nowa macierz.</returns>
        public static double[,] CreateMatrix(double[] diagonal, int width, int lenght)
        {
            double[,] matrix = new double[width, lenght];
            int min = Math.Min(width, lenght);
            for (int i = 1; i < width; i++)
                for (int j = 0; j < lenght; j++)
                {
                    if (i == j && i < min && i < diagonal.Length)
                        matrix[i, j] = diagonal[i];
                }
            return matrix;
        }

        /// <summary>
        /// Operacja mnozenia dwoch macierzy.
        /// </summary>
        /// <param name="matrixA">Macierz A.</param>
        /// <param name="matrixB">Macierz B.</param>
        /// <returns>Wynik operacji mnozenia dwoch macierzy.</returns>
        /// <exception cref="InvalidOperationException">Jesli rozmiary macierzy nie pozwalaja
        /// wykonac operacji mnozenia.</exception>
        public static double[,] Multiply(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
                throw new InvalidOperationException("Niedozwolone mnozenie macierzy !");

            double[,] multiply = new double[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < multiply.GetLength(0); i++)
                for (int j = 0; j < multiply.GetLength(1); j++)
                {
                    multiply[i, j] = Vector.Scalar(GetRow(matrixA, i), GetColumn(matrixB, j));
                }
            return multiply;
        }

        /// <summary>
        /// Operacja mnozenia macierzy i wektora.
        /// x = Ay
        /// </summary>
        /// <param name="matrix">Macierz.</param>
        /// <param name="vector">Wektor.</param>
        /// <returns>Iloczyn macierzy i wektora.</returns>
        public static double[] Multiply(double[,] matrix, double[] vector)
        {
            if(matrix.GetLength(1) != vector.Length)
                throw new InvalidOperationException("Niedozwolone mnozenie macierzy i wektora!");

            int lenght = matrix.GetLength(0);
            double[] multiply = new double[lenght];
            for (int i = 0; i < lenght; i++)
                multiply[i] = Vector.Scalar(GetRow(matrix, i), vector);

            return multiply;
        }

        /// <summary>
        /// Pobiera wiersz macierzy o podanym indeksie.
        /// </summary>
        /// <param name="matrix">Macierz z ktorej ma zostac pobrany wiersz.</param>
        /// <param name="index">Indeks wiersza w macierzy.</param>
        /// <returns>Wiersz macierzy.</returns>
        /// <exception cref="InvalidOperationException">Jesli indeks wykracza poza 
        /// romiar macierzy.</exception>
        public static double[] GetRow(double[,] matrix, int index)
        {
            if (index >= matrix.GetLength(0))
                throw new InvalidOperationException("Index nie istnieje !");

            int width = matrix.GetLength(1);
            double[] row = new double[width];
            for (int i = 0; i < width; i++)
                row[i] = matrix[index, i];
            return row;
        }

        /// <summary>
        /// Pobiera kolumne macierzy o podanym indeksie.
        /// </summary>
        /// <param name="matrix">Macierz z ktorej ma zostac pobrana kolumna.</param>
        /// <param name="index">Indeks kolumny.</param>
        /// <returns>Kolumne macierzy</returns>
        /// <exception cref="InvalidOperationException">Jesli indeks wykracza poza 
        /// romiar macierzy.</exception>
        public static double[] GetColumn(double[,] matrix, int index)
        {
            int width = matrix.GetLength(1);
            if (index >= width) throw new InvalidOperationException("Index nie istnieje !");

            int lenght = matrix.GetLength(0);
            double[] column = new double[lenght];
            for (int i = 0; i < lenght; i++)
                column[i] = matrix[i, index];
            return column;
        }

        /// <summary>
        /// Konwertuje macierz do obiektu typu System.String.
        /// </summary>
        /// <param name="matrix">Macierz do konwersji.</param>
        /// <param name="ignoreFirstRow">Jesli ten parametr bedzie ustawiony na true, to pierwszy wiersz
        /// bedzie pominiety, w przeciwnym przypadku wszystkie wiersze zostana przekonwertowane.</param>
        /// <param name="ignoreFirstColumn">Jesli ten parametr bedzie ustawiony na true, to pierwsza kolumna
        /// zostanie pominieta, w przeciwnym przypadku wszystkie kolumny zostana przekonwertowane.</param>
        /// <returns>Zwraca opis macierzy. System.String</returns>
        public static string ToString(double[,] matrix, bool ignoreFirstRow, bool ignoreFirstColumn)
        {
            StringBuilder builder = new StringBuilder();
            int width = matrix.GetLength(0);
            int lenght = matrix.GetLength(1);
            for (int i = ignoreFirstColumn ? 1 : 0; i < width; i++)
            {
                for (int j = ignoreFirstRow ? 1 : 0; j < lenght; j++)
                {
                    builder.Append(String.Format("{0,5:F2} ", matrix[i, j]));
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        /// <summary>
        /// Konwertuje macierz do obiektu typu System.String.
        /// </summary>
        /// <param name="matrix">Mocierz poddana konwersji.</param>
        /// <returns>Opis macierzy. System.String</returns>
        public static string ToString(double[,] matrix)
        {
            return ToString(matrix, false, false);
        }

        #endregion
    }
}
