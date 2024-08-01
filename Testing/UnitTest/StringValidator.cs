using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringValidatorLibrary;

namespace UnitTests
{
    [TestClass]
    public class StringValidatorTests
    {
        [TestMethod]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            string email = "test@example.com";
            bool result = StringValidator.IsValidEmail(email);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmail_InvalidEmailMissingAtSymbol_ReturnsFalse()
        {
            string email = "testexample.com";
            bool result = StringValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_InvalidEmailMissingDot_ReturnsFalse()
        {
            string email = "test@examplecom";
            bool result = StringValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPhoneNumber_ValidPhoneNumber_ReturnsTrue()
        {
            string phoneNumber = "1234567890";
            bool result = StringValidator.IsPhoneNumber(phoneNumber);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPhoneNumber_InvalidPhoneNumberTooShort_ReturnsFalse()
        {
            string phoneNumber = "12345";
            bool result = StringValidator.IsPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPhoneNumber_InvalidPhoneNumberContainsLetters_ReturnsFalse()
        {
            string phoneNumber = "12345abcde";
            bool result = StringValidator.IsPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }
    }
}
