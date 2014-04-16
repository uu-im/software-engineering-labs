using System;
using RefactoredMatrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        #region Constructor
        [TestMethod, ExpectedException(typeof(Exception))]
        public void Constructor_Empty_Exception()
        {
            Matrix m = new Matrix(new double[0], 0, 0);
        }
        #endregion

        #region GetElement
        [TestMethod]
        public void GetElement_One()
        {
            Matrix m = new Matrix(new double[1]{ 1.1 }, 1, 1);

            double actual = m.GetElement(new Point(0, 0));

            Assert.AreEqual(1.1, actual);
        }

        [TestMethod]
        public void GetElement_OneTimesTwo()
        {
            Matrix m = new Matrix(new double[2] { 1.1, 2.2 }, 1, 2);

            double actual1 = m.GetElement(new Point(0, 0)),
                   actual2 = m.GetElement(new Point(0, 1));

            Assert.AreEqual(1.1, actual1);
            Assert.AreEqual(2.2, actual2);
        }

        [TestMethod]
        public void GetElement_TwoTimesOne()
        {
            Matrix m = new Matrix(new double[2] { 1.1, 2.2 }, 2, 1);
            
            double actual1 = m.GetElement(new Point(0, 0)),
                   actual2 = m.GetElement(new Point(1, 0));
            
            Assert.AreEqual(1.1, actual1);
            Assert.AreEqual(2.2, actual2);
        }

        [TestMethod]
        public void GetElement_ThreeTimesFour()
        {
            Matrix m = new Matrix(new double[12] {1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.0 }, 3, 4);

            double actual1 = m.GetElement(new Point(0, 0)),
                   actual2 = m.GetElement(new Point(0, 1)),
                   actual3 = m.GetElement(new Point(0, 2)),
                   actual4 = m.GetElement(new Point(0, 3)),
                   actual5 = m.GetElement(new Point(1, 0)),
                   actual6 = m.GetElement(new Point(1, 1)),
                   actual7 = m.GetElement(new Point(1, 2)),
                   actual8 = m.GetElement(new Point(1, 3)),
                   actual9 = m.GetElement(new Point(2, 0)),
                   actual10 = m.GetElement(new Point(2, 1)),
                   actual11 = m.GetElement(new Point(2, 2)),
                   actual12 = m.GetElement(new Point(2, 3));

            Assert.AreEqual(1.0, actual1);
            Assert.AreEqual(2.0, actual2);
            Assert.AreEqual(3.0, actual3);
            Assert.AreEqual(4.0, actual4);
            Assert.AreEqual(5.0, actual5);
            Assert.AreEqual(6.0, actual6);
            Assert.AreEqual(7.0, actual7);
            Assert.AreEqual(8.0, actual8);
            Assert.AreEqual(9.0, actual9);
            Assert.AreEqual(10.0, actual10);
            Assert.AreEqual(11.0, actual11);
            Assert.AreEqual(12.0, actual12);
        }
        #endregion

        #region ChangeElement
        [TestMethod]
        public void ChangeElement_First_GivesDifferentElementThroughGetElement()
        {
            // Arrange
            Matrix m = new Matrix(new double[1] { 1.0 }, 1, 1);
            Point position = new Point(0, 0);
            double actual = m.GetElement(position);
            Assert.AreEqual(1.0, actual);

            // Act
            m.changeElement(position, 2.0);

            // Assert
            actual = m.GetElement(position);
            Assert.AreEqual(2.0, actual);
        }

        [TestMethod]
        public void ChangeElement_DeeperInTheMatrix_GivesDifferentElementThroughGetElement()
        {
            // Arrange
            Matrix m = new Matrix(new double[12] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0 }, 3, 4);
            Point pos = new Point(1, 2);
            double actual = m.GetElement(pos);
            Assert.AreEqual(7.0, actual);

            // Act
            m.changeElement(pos, 2.0);

            // Assert
            actual = m.GetElement(pos);
            Assert.AreEqual(2.0, actual);
        }
        #endregion

        #region CheckEquality
        [TestMethod]
        public void CheckEquality_SimpleEqual_True()
        {
            Matrix m1 = new Matrix(new double[1] { 1 }, 1, 1),
                   m2 = new Matrix(new double[1] { 1 }, 1, 1);

            Assert.IsTrue(m1.checkEquality(m2));
        }

        [TestMethod]
        public void CheckEquality_SimpleNonEqual_False()
        {
            Matrix m1 = new Matrix(new double[1] { 1 }, 1, 1),
                   m2 = new Matrix(new double[1] { 0 }, 1, 1);

            Assert.IsFalse(m1.checkEquality(m2));
        }

        [TestMethod]
        public void CheckEquality_ComplexEqual_True()
        {
            Matrix m1 = new Matrix(new double[12] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0 }, 3, 4),
                   m2 = new Matrix(new double[12] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0 }, 3, 4);

            Assert.IsTrue(m1.checkEquality(m2));
        }

        [TestMethod]
        public void CheckEquality_ComplexNonEqual_False()
        {
            Matrix m1 = new Matrix(new double[12] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0 }, 3, 4),
                   m2 = new Matrix(new double[12] { 1.0, 2.0, 3.0, 4.0, 5.0, 7.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0 }, 3, 4);

            Assert.IsFalse(m1.checkEquality(m2));
        }
        #endregion

        #region Multiply
        [TestMethod]
        public void Multiply_2x2With2x2()
        {
            // Arrange
            Matrix m1 = new Matrix(new double[4] { 1, 2, 3, 4 }, 2, 2),
                   m2 = new Matrix(new double[4] { 0, 1, 0, 0 }, 2, 2);
            Assert.AreEqual(m1.GetElement(new Point(0, 1)), 2);
            
            // Act
            Matrix actual = m1.multiply(m2);

            // Assert
            Matrix expected = new Matrix(new double[4] { 0, 1, 0, 3 }, 2, 2);
            Assert.IsTrue(actual.checkEquality(expected));
        }

        [TestMethod]
        public void Multiply_2x3With3x2()
        {
            // Arrange
            Matrix m1 = new Matrix(new double[6] { 1,2,3,4,5,6 }, 2, 3),
                   m2 = new Matrix(new double[6] { 7,8,9,10,11,12 }, 3, 2);

            // Act
            Matrix actual = m1.multiply(m2);

            // Assert
            Matrix expected = new Matrix(new double[4] { 58, 64, 139, 154 }, 2, 2);
            Assert.IsTrue(actual.checkEquality(expected));
        }
        #endregion
    }
}
