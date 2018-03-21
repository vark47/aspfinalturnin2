using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateFinal.Data;
using RealEstateFinal.Models;

namespace RealEstateFinal.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.Listings.ToListAsync());
        }
     
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
     
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
