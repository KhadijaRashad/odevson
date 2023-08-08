using HAYVANB.Data;
using HAYVANB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HAYVANB.Areas.Admin.Controllers
{
    public class IIndirimliUrunlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IIndirimliUrunlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IndirimliUrunler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IndirimliUrunler.Include(i => i.Urun);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/IndirimliUrunler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirimliUrunler = await _context.IndirimliUrunler
                .Include(i => i.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indirimliUrunler == null)
            {
                return NotFound();
            }

            return View(indirimliUrunler);
        }

        // GET: Admin/IndirimliUrunler/Create
        public IActionResult Create()
        {
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad");
            return View();
        }

        // POST: Admin/IndirimliUrunler/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunId,Oran,Baslangic,Bitis,DigerKampanya")] IndirimliUrunler indirimliUrunler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indirimliUrunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", indirimliUrunler.UrunId);
            return View(indirimliUrunler);
        }

        // GET: Admin/IndirimliUrunler/Edit/5 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirimliUrunler = await _context.IndirimliUrunler.FindAsync(id);
            if (indirimliUrunler == null)
            {
                return NotFound();
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", indirimliUrunler.UrunId);
            return View(indirimliUrunler);
        }

        // POST: Admin/IndirimliUrunler/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunId,Oran,Baslangic,Bitis,DigerKampanya")] IndirimliUrunler indirimliUrunler)
        {
            if (id != indirimliUrunler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indirimliUrunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndirimliUrunlerExists(indirimliUrunler.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", indirimliUrunler.UrunId);
            return View(indirimliUrunler);
        }

        // GET: Admin/IndirimliUrunler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirimliUrunler = await _context.IndirimliUrunler
                .Include(i => i.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indirimliUrunler == null)
            {
                return NotFound();
            }

            return View(indirimliUrunler);
        }

        // POST: Admin/IndirimliUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indirimliUrunler = await _context.IndirimliUrunler.FindAsync(id);
            _context.IndirimliUrunler.Remove(indirimliUrunler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndirimliUrunlerExists(int id)
        {
            return _context.IndirimliUrunler.Any(e => e.Id == id);
        }
    }
}
