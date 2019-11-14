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
            var customers = model.GetAllCustomers();
            var account = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 1);
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
            var customers = model.GetAllCustomers();
            var account = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 1);
            var balance = account.Balance;

            //Act
            model.Withdrawl(account.AccountId, 50m);

            //Asset
            Assert.AreEqual((balance - 50m), account.Balance);
        }

        [TestMethod]
        public void TransferTest()
        {
            //Arrange
            var bankRepo = new BankRepository();
            var customers = bankRepo.GetAllCustomers();
            var fromAccount = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 1);
            var toAccount = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == 2);
            var method = new Account();
            var expectedFrom = fromAccount.Balance;
            var expectedTo = toAccount.Balance;

            //Act
            method.Transfer(fromAccount.AccountId, toAccount.AccountId, 100m);

            //Assert
            Assert.AreEqual((expectedFrom - 100m), fromAccount.Balance);
            Assert.AreEqual((expectedTo + 100m), toAccount.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PreventOverdrawInTransfer()
        {
            var model = new Account();
            model.Transfer(1, 2, 53896765);
        }
    }
}
