using System;
using System.Collections.Generic;

namespace RefactoredMatrix
{
    public class Matrix
    {
        double[,] _elements;
        int Rows = 0;
        int Cols = 0;

        /// <summary>
        /// Creates an array with #Rows = r and #columns = c
        /// </summary>
        /// <param name="r"> Number of rows</param>
        /// <param name="c"> Number of Columns</param>
        private Matrix(int r, int c)
        {
            if (r > 10 || c > 10) throw new Exception("Matrix size is only allowed with dimension " + r + "x" + c);
            _elements = new double[r, c];
            r = this.Rows;
            c = this.Cols;
        }

        public Matrix(double[] values, int _r, int _c)
        {
            // ERROR 1: if (_r > 5 || _c > 5 || _c == 0 || _r == 0) throw new Exception("Matrix size is only allowed with dimension " + r + "x" + c);
            // Replaced with: 
            if (_r < 1 || _c < 1) throw new Exception("Matrix must have positive dimensions");

            if (values.Length != _r * _c) throw new Exception("Expected number of values = " + (Rows * Cols));

            this.Rows = _r;
            this.Cols = _c;

            _elements = new double[this.Rows, this.Cols];

            int rad = -1;

            for (int i = 0; i < values.Length; i++)
            {
                if ((i % this.Cols) == 0) rad++;
                _elements[rad, (i % this.Cols)] = values[i];
            }

        }

        /// <summary>
        /// takes a point in the matrix and change the element at given position.
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="newElement"></param>
        public void ChangeElement(Point p, double newElement)
        {
            if (p.x > this.Rows || p.y > this.Cols) throw new Exception("Out of Range");
            _elements[p.x, p.y] = newElement;
        }

        public double GetElement(Point p)
        {
            return _elements[p.x, p.y];
        }

        /// <summary>
        /// calculate and returning the new matrix with multiplication, Be aware that you
        /// know the rules for matrix and the operations.
        /// Not Optimized Algorithm for Matrix Multiplication.
        /// </summary>
        /// <param name="m2"> Matrix to multiple with, THIS * m2</param>
        /// <returns></returns>
        public Matrix Multiply(Matrix m2)
        {
            if (!sameMagnitute(m2))
                throw new Exception("Not same magnitude");

            // ERROR 4: The multiplication was broken
            List<double> newValues = new List<double>();

            for (int r = 0; r < Rows; r++)
                for (int c2 = 0; c2 < m2.Cols; c2++)
                {
                    double sum = 0;
                    for (int c = 0; c < Cols; c++)
                    {
                        double a = GetElement(new Point(r, c)),
                               b = m2.GetElement(new Point(c, c2));
                        double mult = a * b;
                        sum += mult;
                    }
                    newValues.Add(sum);
                }

            return new Matrix(newValues.ToArray(), Rows, m2.Cols); // the size is determinded by the rules!;
        }

        /// <summary>
        /// Checks if the elements are equal in the matrixes.
        /// </summary>
        /// <param name="m2"></param>
        /// <returns></returns>
        public bool CheckEquality(Matrix m2)
        {
            // ERROR 2: Bad range eq. check
            if (Rows != m2.Rows || Cols != m2.Cols)
                throw new Exception("Different range");

            // ERROR 3: Inverted bool return statements and iteration errors
            for (int r=0; r<Rows; r++)
                for (int c=0; c<Cols; c++)
                    if (_elements[r, c] != m2.GetElement(new Point(r, c)))
                        return false;

            return true;
        }

        /// <summary>
        /// A*B != B*A
        /// </summary>
        /// <param name="m2"></param>
        /// <returns></returns>
        private bool sameMagnitute(Matrix m2)
        {
            return this.Cols == m2.Rows;
        }
    }


    public class Point
    {
        public int x, y;

        public Point(int row, int col)
        {
            if (row < 0 || col < 0) throw new Exception("Points below zero not allowed.");
            this.x = row;
            this.y = col;
        }
    }
}
