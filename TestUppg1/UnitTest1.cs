using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUppg1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanNotDepositUnderBalance()
        {
        }
    }
}
