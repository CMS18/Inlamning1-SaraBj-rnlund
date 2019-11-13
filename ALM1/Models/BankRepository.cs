using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM1.Models
{
    public class BankRepository
    {
        public List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "Sara",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 1,
                        Balance = 300000m
                    }
                }
            },
            new Customer
            {
                Id = 2,
                FirstName = "Henrik",
                Accounts = new List<Account>
                {
                    new Account {
                        AccountId = 2,
                        Balance = 400000m
                    }
                }
            },
            new Customer
            {
                Id = 3,
                FirstName = "Winston",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 3,
                        Balance = 500m
                    }
                }
            },
        };

        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public void Deposit(int accountId, decimal amount)
        {
            if (amount < 0) throw new Exception();
            var account = Customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == accountId);

            account.Balance += amount;
        }

        public void Withdrawl(int accountId, decimal amount)
        {
            var account = Customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == accountId);
            if (amount > account.Balance || amount < 0) throw new Exception();

            account.Balance -= amount;
        }
    }
}
