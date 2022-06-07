using AWP_Foreign_Languages_WPF.Models;
using AWP_Foreign_Languages_WPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AWP_Foreign_Languages_Library_UnitTests
{
    [TestClass]
    public class UserViewModelUnitTest
    {
        Core db = new Core();
        /// <summary>
        /// Проверка данных для авторизации 
        /// </summary>
        [TestMethod]
        public void UserLogin_TestMethod1_TrueReturned()
        {
            // Arrange
            string phone = "79089005533";
            string password = "qwe";

            // Act
            bool result = UserViewModel.UserLogin(phone, password);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверка данных для авторизации
        /// </summary>
        [TestMethod]
        public void UserLogin_TestMethod2_FalseReturned()
        {
            // Arrange
            string phone = "79089005555";
            string password = "123";

            // Act
            bool result = UserViewModel.UserLogin(phone, password);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
