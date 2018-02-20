using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workshopmvc.Models;

namespace Workshopmvc.Controllers
{
    public class CarroControler : Controller
    {
        private readonly CarroContext _context;

        public CarroControler(CarroContext context)
        {
            _context = context;
        }

        // GET: CarroControler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: CarroControler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: CarroControler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarroControler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Modelo,Año,cilindraje")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: CarroControler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        // POST: CarroControler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Modelo,Año,cilindraje")] Carro carro)
        {
            if (id != carro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.ID))
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
            return View(carro);
        }

        // GET: CarroControler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: CarroControler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
