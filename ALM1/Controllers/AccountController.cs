using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALM1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int fromAccount, int toAccount, decimal amount)
        {
            BankRepository bankRepo = new BankRepository();
            var customers = bankRepo.GetAllCustomers();
            var from = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == fromAccount);
            var to = customers.SelectMany(c => c.Accounts).SingleOrDefault(a => a.AccountId == toAccount);

            if (from == null)
            {
                TempData["result"] = "Kan ej hitta konto med kontonummer: " + fromAccount;
            }
            else if (to == null)
            {
                TempData["result"] = "Kan ej hitta konto med kontonummer: " + toAccount;
            }
            else if (amount > from.Balance)
            {
                TempData["result"] = "Det finns inte tillräckligt med pengar på konto " + from.AccountId + " för att genomföra överföringen.";
            }
            else if (amount <= 0)
            {
                TempData["result"] = "För lågt belopp.";
            }
            else
            {
                from.Balance -= amount;
                to.Balance += amount;
                TempData["result"] = "Överföring godkänd. Nytt saldo för konto " + from.AccountId + " är " + from.Balance + ". Nytt saldo för konto " + to.AccountId + " är " + to.Balance;
            }

            return RedirectToAction("Index");
        }
    }
}
