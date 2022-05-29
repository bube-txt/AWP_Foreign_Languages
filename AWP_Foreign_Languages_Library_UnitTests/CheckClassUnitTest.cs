using AWP_Foreign_Languages_Library.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AWP_Foreign_Languages_Library_UnitTests
{
    [TestClass]
    public class CheckClassUnitTest
    {
        /// <summary>
        /// Проверка времени на корректность
        /// </summary>
        [TestMethod]
        public void TimeCheck_TestMethod1_TrueReturned()
        {
            // Arrange
            string time = "14:00";

            // Act
            bool result = CheckClass.TimeCheck(time);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка времени на корректность
        /// </summary>
        [TestMethod]
        public void TimeCheck_TestMethod2_TrueReturned()
        {
            // Arrange
            string time = "12:00:00";

            // Act
            bool result = CheckClass.TimeCheck(time);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка времени на корректность
        /// </summary>
        [TestMethod]
        public void TimeCheck_TestMethod3_TrueReturned()
        {
            // Arrange
            string time = "2:00:00";

            // Act
            bool result = CheckClass.TimeCheck(time);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка времени на корректность
        /// Больше 24 часов - ложь
        /// </summary>
        [TestMethod]
        public void TimeCheck_TestMethod4_FalseReturned()
        {
            // Arrange
            string time = "25:00:00";

            // Act
            bool result = CheckClass.TimeCheck(time);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проверка времени на корректность
        /// Отрицательное время - ложь
        /// </summary>
        [TestMethod]
        public void TimeCheck_TestMethod5_FalseReturned()
        {
            // Arrange
            string time = "-1:00:00";

            // Act
            bool result = CheckClass.TimeCheck(time);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
