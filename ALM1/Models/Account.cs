using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
    

        public void Transfer(int fromAccount, int toAccount, decimal amount)
        {
            BankRepository bankRepo = new BankRepository();
            var customers = bankRepo.GetAllCustomers();
            var from = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == fromAccount);
            var to = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == toAccount);

            if(from == null || to == null || amount > from.Balance || amount <= 0) throw new ArgumentOutOfRangeException();

            from.Balance -= amount;
            to.Balance += amount;
        }
    }
}
