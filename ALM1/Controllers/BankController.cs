using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALM1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALM1.Controllers
{
    public class BankController : Controller
    {
        BankRepository repo = new BankRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(int accountId, decimal amount)
        {
            var customers = repo.GetAllCustomers();
            var account = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == accountId);

            if(account == null)
            {
                TempData["failed"] = $"Kontonummer existerar inte!";
            }
            else
            {
                try
                {
                    repo.Deposit(accountId, amount);
                    TempData["success"] = $"Insättningen på konto {accountId} lyckades! Nytt belopp {account.Balance}";
                }
                catch
                {
                    TempData["failed"] = $"Felaktigt belopp!";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Withdrawl(int accountId, decimal amount)
        {
            var customers = repo.GetAllCustomers();
            var account = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == accountId);

            if (account == null)
            {
                TempData["failed"] = $"Kontonummer existerar inte!";
            }
            else
            {
                try
                {
                    repo.Withdrawl(accountId, amount);
                    TempData["success"] = $"Uttagning på konto {accountId} lyckades! Nytt belopp {account.Balance}";
                }
                catch
                {
                    TempData["failed"] = $"Felaktigt belopp!";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
