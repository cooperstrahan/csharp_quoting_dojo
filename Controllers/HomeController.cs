using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteRanks.Models;

namespace QuoteRanks.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult AddQuote(Quotes q )
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO quote_table (name, quote) VALUES ('{q.name}', '{q.quote}')";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quote_table");
            ViewBag.Quotes = AllQuotes;
            return View();
        }

    }
}
