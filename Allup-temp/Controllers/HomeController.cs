using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allup_temp.DataAccesLayer;
using Allup_temp.Models;
using Allup_temp.Models.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup_temp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Categories = await _context.Categories.Where(c=>c.IsDeleted==false && c.IsMain).ToListAsync(),
                Features = await _context.Products.Where(p=>p.IsDeleted==false && p.IsFeatured).ToListAsync(),
                BestSeller = await _context.Products.Where(p => p.IsDeleted == false && p.IsBestSeller).ToListAsync(),
                NewArrival = await _context.Products.Where(p=>p.IsDeleted==false && p.IsNewArrival).ToListAsync()


            };
            return View(vm);
        }
    }
}

