using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
