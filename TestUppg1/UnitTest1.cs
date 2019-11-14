using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ALM1.Models;
using System.Linq;

namespace TestUppg1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HighAmountTest()
        {
            var model = new BankRepository();
            model.Withdrawl(1, 53896765);
        }

        [TestMethod]
        public void DepositTest()
        {
            //Arrange
            var model = new BankRepository();
            var account = model.Customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 1);
            var balance = account.Balance;

            //Act
            model.Deposit(account.AccountId, 40m);

            //Assert
            Assert.AreEqual((balance + 40m), account.Balance);
        }

        [TestMethod]
        public void WithdrawlTest()
        {
            //Arrange
            var model = new BankRepository();
            var account = model.Customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 1);
            var balance = account.Balance;

            //Act
            model.Withdrawl(account.AccountId, 50m);

            //Asset
            Assert.AreEqual((balance - 50m), account.Balance);
        }
    }
}
