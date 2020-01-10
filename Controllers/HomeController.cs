using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly DbContext context;

        //public HomeController(SearchContext context)
        //{
        //    this.context = context;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Domain, Depth")] Input input)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("Domain", input.Domain + "," + input.Depth);
                return RedirectToAction(nameof(Index), "Save");
            }
            return View(input);
        }

        public IActionResult Index()
        {
            return View(new Input());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
