using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Mini_Project.DAL;
using CRUD_Mini_Project.Models;

namespace CRUD_Mini_Project.Controllers
{
    public class MethodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly Guid DefaultUserId;

        public MethodsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            DefaultUserId = Guid.Parse(_configuration["SystemSettings:DefaultUserId"]);
        }

        // GET: Methods
        public async Task<IActionResult> Index()
        {
            return View(await _context.MethodsRepository.Where(x => x.IsActive == true).ToListAsync());
        }

        // GET: Methods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @method = await _context.MethodsRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@method == null)
            {
                return NotFound();
            }

            return View(@method);
        }

        // GET: Methods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Methods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,description")] Method @method)
        {
            if (ModelState.IsValid)
            {
                @method.Id = Guid.NewGuid();
                @method.CreatedById = DefaultUserId;
                @method.CreatedOn = DateTime.Now;
                @method.IsActive = true;
                _context.Add(@method);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@method);
        }

        // GET: Methods/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @method = await _context.MethodsRepository.FindAsync(id);
            if (@method == null)
            {
                return NotFound();
            }
            return View(@method);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]Guid id)
        {
            var originalMethod = await _context.MethodsRepository
                .FirstOrDefaultAsync(m => m.Id == id);

            if (originalMethod == null)
            {
                return NotFound();
            }

            bool isUpdateSuccessful = await TryUpdateModelAsync<Method>(
                originalMethod,
                "", 
                m => m.code,
                m => m.description
            );

            if (isUpdateSuccessful && ModelState.IsValid)
            {
                originalMethod.LastUpdateDate = DateTime.Now;
                originalMethod.LastUpdateById = DefaultUserId;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodExists(originalMethod.Id))
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

            return View(originalMethod);
        }

        // GET: Methods/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @method = await _context.MethodsRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@method == null)
            {
                return NotFound();
            }

            return View(@method);
        }

        // POST: Methods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @method = await _context.MethodsRepository.FindAsync(id);
            if (@method != null)
            {
                @method.IsActive = false;
                _context.MethodsRepository.Update(@method);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodExists(Guid id)
        {
            return _context.MethodsRepository.Any(e => e.Id == id);
        }
    }
}
