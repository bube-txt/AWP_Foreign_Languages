using AWP_Foreign_Languages_Library.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AWP_Foreign_Languages_Library_UnitTests
{
    [TestClass]
    public class ConvertClassUnitTest
    {


        #region FormatedDate

        /// <summary>
        /// Метод переводящий DateTime в String для более приятного визуального отображения даты
        /// </summary>
        [TestMethod]
        public void FormatedDate_TestMethod1_TrueReturned()
        {
            // Arrange
            DateTime dateTime = new DateTime(1997, 01, 07);

            string expected = "1997-01-07";

            // Act
            string result = ConvertClass.FormatedDate(dateTime);

            // Assert

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Метод переводящий DateTime в String для более приятного визуального отображения
        /// </summary>
        [TestMethod]
        public void FormatedDate_TestMethod2_TrueReturned()
        {
            // Arrange
            DateTime dateTime = new DateTime(1568, 05, 02);

            string expected = "1568-05-02";

            // Act
            string result = ConvertClass.FormatedDate(dateTime);

            // Assert

            Assert.AreEqual(expected, result);
        }

        #endregion

        #region GetFormatedTime

        /// <summary>
        /// Метод переводящий DateTime в String для более приятного визуального отображения времени
        /// </summary>
        [TestMethod]
        public void FormatedTime_TestMethod1_TrueReturned()
        {
            // Arrange
            TimeSpan timeSpan = new TimeSpan(14, 0, 0);

            string expected = "14:00";

            // Act
            string result = ConvertClass.FormatedTime(timeSpan);

            // Assert

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Метод переводящий DateTime в String для более приятного визуального отображения времени
        /// Введено 25 часов - вывод 1 час
        /// </summary>
        [TestMethod]
        public void FormatedTime_TestMethod2_TrueReturned()
        {
            // Arrange
            TimeSpan timeSpan = new TimeSpan(25, 0, 0);

            string expected = "1:00";

            // Act
            string result = ConvertClass.FormatedTime(timeSpan);

            // Assert

            Assert.AreEqual(expected, result);
        }

        #endregion}
    }
}
