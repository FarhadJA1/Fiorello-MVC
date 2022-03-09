using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Controllers
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
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderDetail detail = await _context.SliderDetails.FirstOrDefaultAsync();
            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                Detail = detail
            };
            return View(homeVM);
        }
    }
}
