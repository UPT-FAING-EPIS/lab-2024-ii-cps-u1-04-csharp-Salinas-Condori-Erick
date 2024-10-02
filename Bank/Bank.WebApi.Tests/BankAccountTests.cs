using Bank.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.WebApi.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 12.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert is handled by the ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsNegative_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -1.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert is handled by the ExpectedException
        }
    }
}
