using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmniselloTask.Data;
using OmniselloTask.Models;

namespace OmniselloTask.Controllers
{
    public class VegaetablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VegaetablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vegaetables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vegetable.ToListAsync());
        }

        // GET: Vegaetables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegaetables = await _context.Vegetable
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vegaetables == null)
            {
                return NotFound();
            }

            return View(vegaetables);
        }

        // GET: Vegaetables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegaetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameVegatables")] Vegaetables vegaetables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegaetables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegaetables);
        }

        // GET: Vegaetables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegaetables = await _context.Vegetable.FindAsync(id);
            if (vegaetables == null)
            {
                return NotFound();
            }
            return View(vegaetables);
        }

        // POST: Vegaetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameVegatables")] Vegaetables vegaetables)
        {
            if (id != vegaetables.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegaetables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegaetablesExists(vegaetables.ID))
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
            return View(vegaetables);
        }

        // GET: Vegaetables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegaetables = await _context.Vegetable
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vegaetables == null)
            {
                return NotFound();
            }

            return View(vegaetables);
        }

        // POST: Vegaetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vegaetables = await _context.Vegetable.FindAsync(id);
            if (vegaetables != null)
            {
                _context.Vegetable.Remove(vegaetables);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VegaetablesExists(int id)
        {
            return _context.Vegetable.Any(e => e.ID == id);
        }
    }
}
