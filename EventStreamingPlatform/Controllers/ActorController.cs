﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventStreamingPlatform.Data;
using EventStreamingPlatform.Models;
using ReflectionIT.Mvc.Paging;

namespace EventStreamingPlatform.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actor
        
        public async Task<IActionResult> Index(string sortOrder, int pageNumber=1)
        {
            var actors = _context.Actor.AsQueryable();
            ViewData["NameOrder"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SurnameOrder"] = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";

            switch (sortOrder) 
            {
                case "name_desc":
                    actors = actors.OrderByDescending(a => a.Name);
                    break;

                case "surname_desc":
                    actors = actors.OrderByDescending(a => a.Surname);
                    break;


                default:
                    actors = actors.OrderBy(a => a.Name);
                    break;
            }
            return View(await PaginatedList<Actor>.CreateAsync(actors.AsNoTracking(), pageNumber,3));

            //return View(await _context.Actor.ToListAsync());
        }

        // GET: Actor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Actor == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Actor == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
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
            return View(actor);
        }

        // GET: Actor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actor == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Actor'  is null.");
            }
            var actor = await _context.Actor.FindAsync(id);
            if (actor != null)
            {
                _context.Actor.Remove(actor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
          return _context.Actor.Any(e => e.Id == id);
        }
    }
}
