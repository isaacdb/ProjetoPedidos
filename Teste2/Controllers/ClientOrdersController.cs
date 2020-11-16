using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste2.Data;
using Teste2.Models;
using Teste2.Models.ViewModels;
using Teste2.Services;

namespace Teste2.Controllers
{
    public class ClientOrdersController : Controller
    {
        private readonly Teste2Context _context;
       // private readonly ClientService _clientService;

        public ClientOrdersController(Teste2Context context)
        {
            _context = context;
        }

        // GET: ClientOrders
        public async Task<IActionResult> Index()
        {
            var teste2Context = _context.ClientOrder.Include(c => c.Client);
            return View(await teste2Context.ToListAsync());
        }

        public IActionResult Search()
        {
            return View();
        } 

        // GET: ClientOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrder
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientOrder == null)
            {
                return NotFound();
            }

            return View(clientOrder);
        }

        // GET: ClientOrders/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            return View();
        }

        // POST: ClientOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateClientOrder,ClientId")] ClientOrder clientOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", clientOrder.ClientId);
            return View(clientOrder);
        }

        // GET: ClientOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrder.FindAsync(id);
            if (clientOrder == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", clientOrder.ClientId);
            return View(clientOrder);
        }

        // POST: ClientOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateClientOrder,ClientId")] ClientOrder clientOrder)
        {
            if (id != clientOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientOrderExists(clientOrder.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", clientOrder.ClientId);
            return View(clientOrder);
        }

        // GET: ClientOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrder
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientOrder == null)
            {
                return NotFound();
            }

            return View(clientOrder);
        }

        // POST: ClientOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientOrder = await _context.ClientOrder.FindAsync(id);
            _context.ClientOrder.Remove(clientOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientOrderExists(int id)
        {
            return _context.ClientOrder.Any(e => e.Id == id);
        }
    }
}
