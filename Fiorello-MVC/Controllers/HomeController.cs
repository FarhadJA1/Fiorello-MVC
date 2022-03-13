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
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Product> products = await _context.Products
                .Include(m=>m.Category)
                .Include(m=>m.Images)                
                .ToListAsync();
            ExpertsText expertsText = await _context.ExpertsTexts.FirstOrDefaultAsync();
            List<Experts> experts = await _context.Experts.ToListAsync();
            BlogHeader blogHeader = await _context.BlogHeaders.FirstOrDefaultAsync();
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            List<Testimone> testimones = await _context.Testimones.ToListAsync();
            List<Instagram> instagrams = await _context.Instagrams.ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                Detail = detail,
                Categories = categories,
                Products = products,
                ExpertsText = expertsText,
                Experts=experts,
                BlogHeader=blogHeader,
                Blogs=blogs,
                Testimonials=testimones,
                Instagrams=instagrams
                
            };
            return View(homeVM);
        }
    }
}
