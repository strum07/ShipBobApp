using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShipBobApp.Data;
using ShipBobApp.Models;

namespace ShipBobApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShipBobAppContext _context;

        public OrdersController(ShipBobAppContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var search = from s in _context.Orders.Include(o => o.Customer)
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.RecipientName.Contains(searchString)
                                               || s.Customer.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "NameSortParm":
                    search = search.OrderByDescending(s => s.RecipientName);
                    break;
              
                default:
                    search = search.OrderBy(s => s.Customer.FullName);
                    break;
            }   

            return View(await search.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id,bool? concurrencyError)
        {
          


            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(d => d.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }

            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                                                      + "was modified by another user after you got the original values. "
                                                      + "The delete operation was canceled and the current values in the "
                                                      + "database have been displayed. If you still want to delete this "
                                                      + "record, click the Delete button again. Otherwise "
                                                      + "click the Back to List hyperlink.";
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,TrackingId,RecipientName,StreetAddress,City,State,ZipCode,UserId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FulName", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(i => i.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.OrderId == id);
            
            
            
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,TrackingId,RecipientName,StreetAddress,City,State,ZipCode,UserId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if(id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(d => d.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }

            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                                                      + "was modified by another user after you got the original values. "
                                                      + "The delete operation was canceled and the current values in the "
                                                      + "database have been displayed. If you still want to delete this "
                                                      + "record, click the Delete button again. Otherwise "
                                                      + "click the Back to List hyperlink.";
            }

            return View(order);

        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Order order)
        {
            try
            {
                if (await _context.Orders.AnyAsync(m => m.OrderId == order.OrderId))
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = order.OrderId });
            }
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
