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
            matrix = Matrix.ZeroComplete(matrix);
            if (!SVD.Decomposition(matrix, ref w, ref u, ref vt))
                throw new InvalidOperationException("Macierz nie udalo sie rozlozyc !");

            double[,] uTrans = Matrix.Transposition(u);
            double[,] vMatrix = Matrix.Transposition(vt);
            double[,] sigma = Matrix.CreateMatrix(w, matrix.GetLength(0), matrix.GetLength(1));
            sigma = Matrix.Reciprocal(sigma);
            double[,] matrixPlus = Matrix.Multiply(vMatrix, sigma);
            matrixPlus = Matrix.Multiply(matrixPlus, uTrans);
            u = vt = sigma = uTrans = vMatrix = null;
            
            return matrixPlus = Matrix.RemoveFirstColumnAndFirstRow(matrixPlus);
        }

        #endregion

        #region Private Methods
        /*
        private static double[,] Solve(double[,] matrix)
        {
            double[,] u = null, vt = null;
            double[] w = null;
            if (!SVD.Decomposition(matrix, ref w, ref u, ref vt))
                throw new InvalidOperationException("Macierz nie udalo sie rozlozyc !");
            //tworze macierz w
            MatrixDN matrixW = CreateMatrix(w, matrix.GetLength(0), matrix.GetLength(1));
            //tworze macierz u
            MatrixDN matrixU = CreateMatrix(u);
            //tworze macie vt
            MatrixDN matrixVT = CreateMatrix(vt);
            //transpozycja u
            matrixU = matrixU.Transpose();
            //transozycja Vt -> V
            matrixVT = matrixVT.Transpose();
            //transpozycja polaczona z odwronoscia kazdego niezerowego elementu
            matrixW = Reciprocal(matrixW);
            //mplus
            MatrixDN mPlus = (matrixVT * matrixW) * matrixU;
            //tablica
            return mPlus.ToArray();
        }

        private static MatrixDN CreateMatrix(double[] diagonal, int lenght0, int lenhgt1)
        {
            MatrixDN matrixW = MatrixBuild.CreateMatrix(lenght0 - 1, lenhgt1 - 1);
            for (int i = 1; i < lenght0; i++)
                for (int j = 1; j < lenhgt1; j++)
                {
                    if (i == j && i < diagonal.Length)
                        matrixW[i - 1, j - 1] = diagonal[i];
                    else
                        matrixW[i - 1, j - 1] = 0;
                }
            return matrixW;
        }

        private static MatrixDN CreateMatrix(double[,] m)
        {
            MatrixDN matrixW = MatrixBuild.CreateMatrix(m.GetLength(0) - 1, m.GetLength(1) - 1);
            for (int i = 1; i < m.GetLength(0); i++)
                for (int j = 1; j < m.GetLength(1); j++)
                {
                    matrixW[i - 1, j - 1] = m[i, j];
                }
            return matrixW;
        }

        private static MatrixDN Reciprocal(MatrixDN matrix)
        {
            matrix = matrix.Transpose();
            for (int j = 0; j < matrix.Columns; j++)
                for (int i = 0; i < matrix.Rows; i++)
                {
                    if (matrix[i, j] != 0)
                        matrix[i, j] = 1 / matrix[i, j];
                }
            return matrix;
        }
        */
        #endregion
    }

    #endregion
}
