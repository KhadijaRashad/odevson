using HAYVANB.Data;
using HAYVANB.Models;
using HAYVANB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HAYVANB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel HomeVM = new HomeViewModel()

            {
                Urun = _context.Urun.Include(m => m.Kategori).ToList(),
                Kategori = _context.Kategori.ToList(),
                IndirimliUrunler = _context.IndirimliUrunler.Where(x => (x.Baslangic <= DateTime.Now && x.Bitis > DateTime.Now)).ToList()

            };

            return View(HomeVM);
        }

        public IActionResult Contact()
        {
            return View();
        }

        

        

        
    }
}