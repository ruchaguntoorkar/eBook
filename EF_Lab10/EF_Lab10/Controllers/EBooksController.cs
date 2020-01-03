using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_Lab10.Data;
using EF_Lab10.Models;
using Microsoft.AspNetCore.Authorization;

namespace EF_Lab10.Controllers
{
    public class EBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EBooks.Include(e => e.Author);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks
                .Include(e => e.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // GET: EBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "ID");
            return View();
        }

        // POST: EBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BookName,Genre,AuthorId,Author.Name")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "ID", eBook.AuthorId);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "ID", eBook.Author.Name);
            return View(eBook);
        }

        // GET: EBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks.FindAsync(id);
            if (eBook == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "ID", eBook.AuthorId);
            return View(eBook);
        }

        // POST: EBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BookName,Genre,AuthorId")] EBook eBook)
        {
            if (id != eBook.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookExists(eBook.ID))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "ID", eBook.AuthorId);
            return View(eBook);
        }

        // GET: EBooks/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks
                .Include(e => e.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // POST: EBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eBook = await _context.EBooks.FindAsync(id);
            _context.EBooks.Remove(eBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBookExists(int id)
        {
            return _context.EBooks.Any(e => e.ID == id);
        }
    }
}
