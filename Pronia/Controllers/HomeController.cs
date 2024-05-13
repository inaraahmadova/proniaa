using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccesLayer;
using Pronia.ViewModels;
using Pronia.ViewModels.Sliders;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaContext _context;
        public HomeController(ProniaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                Categories = await _context.Categories.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),

            };
            return View(vm);
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> Shop()
        {
            return View();
        }

        public async Task<IActionResult> Test(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var cat = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Content(cat.Name);
        }

    } }







