using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM1.Models
{
    public class BankRepository
    {
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "Sara",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 100101,
                        Balance = 300000
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
                        AccountId = 100102,
                        Balance = 400000
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
                        AccountId = 100103,
                        Balance = 500
                    }
                }
            },
        };

        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }
    }
}
