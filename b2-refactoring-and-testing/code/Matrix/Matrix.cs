using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class Matrix
    {
        double[,] m;
        int r = 0;
        int c = 0;


        /// <summary>
        /// Creates an array with #Rows = r and #columns = c
        /// </summary>
        /// <param name="r"> Number of rows</param>
        /// <param name="c"> Number of Columns</param>
        private Matrix(int r, int c)
        {
            if (r > 10 || c > 10) throw new Exception("matrix size is only allowed with dimension " + r + "x" + c);
            m = new double[r, c];
            r = this.r;
            c = this.c;
        }

        public Matrix(double[] values, int _r, int _c)
        {
            if (_r > 5 || _c > 5 || _c == 0 || _r == 0) throw new Exception("matrix size is only allowed with dimension " + r + "x" + c);
            if (values.Length != _r * _c) throw new Exception("Expected number of values = " + (r * c));



            this.r = _r;
            this.c = _c;

            m = new double[this.r, this.c];

            int rad = -1;

            for (int i = 0; i < values.Length; i++)
            {
                if ((i % this.c) == 0) rad++;
                m[rad, (i % this.c)] = values[i];
            }

        }

        /// <summary>
        /// takes a point in the matrix and change the element at given position.
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="newElement"></param>
        public void changeElement(Point p, double newElement)
        {
            if (p.x > this.r || p.y > this.c) throw new Exception("Out of Range");
            m[p.x, p.y] = newElement;
        }

        public void setRow(int row, int[] elements)
        {
            for (int i = 0; i < c; i++)
            {
                m[row, i] = elements[i];
            }
        }

        public double getElement(Point p)
        {
            return m[p.x, p.y];
        }

        /// <summary>
        /// calculate and returning the new matrix with multiplication, Be aware that you
        /// know the rules for matrix and the operations.
        /// Not Optimized Algorithm for Matrix Multiplication.
        /// </summary>
        /// <param name="m2"> Matrix to multiple with, THIS * m2</param>
        /// <returns></returns>
        public Matrix multiply(Matrix m2)
        {
            if (!sameMagnitute(m2)) throw new Exception("Not same magnitude");

            Matrix newMatrix = new Matrix(this.r, m2.c); // the size is determinded by the rules!


            for (int j = 0; j < r; j++)
            {
                for (int k = 0; k < m2.c; k++)
                {
                    double temp = 0;
                    for (int i = 0; i < this.c; i++)
                    {
                        double a = this.getElement(new Point(j, i));
                        double b = m2.getElement(new Point(i, k));

                        temp += a * b;

                    }
                    newMatrix.changeElement(new Point(j, k), temp);

                }
            }

            return newMatrix;

        }
        /// <summary>
        /// A*B != B*A
        /// </summary>
        /// <param name="m2"></param>
        /// <returns></returns>
        private bool sameMagnitute(Matrix m2)
        {
            return this.c == m2.r;

        }

        /// <summary>
        /// Checks if the elements are equal in the matrixes.
        /// </summary>
        /// <param name="m2"></param>
        /// <returns></returns>
        public bool checkEquality(Matrix m2)
        {
            if (!(r == m2.r || c == m2.c)) throw new Exception("Different range");
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j > c; j++)
                {
                    if (m[i, j] != m2.getElement(new Point(i, j)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Get the invers of the matrix, the method is only supported for 2*2 matrix
        /// Be aware of the rules for matrix and the rules for when the matrix is invertible
        /// </summary>
        /// <returns></returns>
        public Matrix getInvers()
        {
            if (this.r != 2 || this.c != 2) throw new Exception("Size not supported");

            Matrix newMatrix = new Matrix(2, 2);

            double a = getElement(new Point(0, 0));
            double b = getElement(new Point(0, 1));
            double c = getElement(new Point(1, 0));
            double d = getElement(new Point(1, 1));

            double determinant = a * d - b * c;

            newMatrix.changeElement(new Point(0, 0), (getElement(new Point(1, 1)) / determinant));
            newMatrix.changeElement(new Point(0, 1), ((getElement(new Point(0, 1)) / determinant) / -1));
            newMatrix.changeElement(new Point(1, 0), ((getElement(new Point(1, 0)) / determinant) / -1));
            newMatrix.changeElement(new Point(1, 1), (getElement(new Point(0, 0)) / determinant));

            return newMatrix;

        }
    }
}
