using System;

namespace DocClass.Src.Learning.MathOperations
{
    #region PseudoInverse Class

    /// <summary>
    /// Klasa do znalezienia macierz M+ na podstawie
    /// macierzy M. M+ = V*W+*U^T
    /// </summary>
    public static class Pseudoinverse
    {
        #region Public Methods

        /// <summary>
        /// Metoda wylicza macierz M+ na podstawie macierzy M.
        /// </summary>
        /// <param name="matrix">Macierz M.</param>
        /// <returns>Macierz M+</returns>
        /// <exception cref="NullReferenceException">Jesli argument bedzie null.</exception>
        /// <exception cref="InvalidOperationException">Jesli macierz nie uda sie rozlozyc.</exception>
        public static double[,] Solve(double[,] matrix)
        {
            if (matrix == null)
                throw new NullReferenceException("Parametr matrix nie moze byc null !");

            double[,] u = new double[0, 0];
            double[,] vt = new double[0, 0];
            double[] w = new double[0];

            if (!SVD.Decomposition(matrix, ref w, ref u, ref vt))
                throw new InvalidOperationException("Macierz nie udalo sie rozlozyc !");

            double[,] uTrans = Matrix.Transposition(u);
            double[,] vMatrix = Matrix.Transposition(vt);
            double[,] sigma = Matrix.CreateMatrix(w, matrix.GetLength(0), matrix.GetLength(1));
            sigma = Matrix.Reciprocal(sigma);
            double[,] matrixPlus = Matrix.Multiply(vMatrix, sigma);
            matrixPlus = Matrix.Multiply(matrixPlus, uTrans);

            u = vt = sigma = uTrans = vMatrix = null;
            return matrixPlus;
        }

        #endregion
    }

    #endregion
}
