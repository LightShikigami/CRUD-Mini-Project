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
    public class SampleTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly Guid DefaultUserId;
        public SampleTypesController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            DefaultUserId = Guid.Parse(_configuration["SystemSettings:DefaultUserId"]);
        }

        // GET: SampleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleTypesRepository.Where(x => x.IsActive == true).ToListAsync());
        }

        // GET: SampleTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleType = await _context.SampleTypesRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleType == null)
            {
                return NotFound();
            }

            return View(sampleType);
        }

        // GET: SampleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,description")] SampleType sampleType)
        {
            if (ModelState.IsValid)
            {
                sampleType.Id = Guid.NewGuid();
                sampleType.CreatedOn = DateTime.Now;
                sampleType.CreatedById = DefaultUserId;
                sampleType.IsActive = true;
                _context.Add(sampleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleType);
        }

        // GET: SampleTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleType = await _context.SampleTypesRepository.FindAsync(id);
            if (sampleType == null)
            {
                return NotFound();
            }
            return View(sampleType);
        }

        // POST: SampleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]Guid Id)
        {
            var sampleType = await _context.SampleTypesRepository.FirstOrDefaultAsync(x => x.Id == Id);
            if (sampleType == null)
                return NotFound();

            bool isUpdateSuccessful = await TryUpdateModelAsync<SampleType>(
                sampleType,
                "",
                p => p.code,
                p => p.description
            );

            if (isUpdateSuccessful && ModelState.IsValid)
            {
                sampleType.LastUpdateById = DefaultUserId; 
                sampleType.LastUpdateDate = DateTime.Now;
                try
                {                 
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleTypeExists(sampleType.Id))
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

            return View(sampleType);
        }

        // GET: SampleTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleType = await _context.SampleTypesRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sampleType == null)
            {
                return NotFound();
            }

            return View(sampleType);
        }

        // POST: SampleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sampleType = await _context.SampleTypesRepository.FindAsync(id);
            if (sampleType != null)
            {
                sampleType.IsActive = false;
                _context.SampleTypesRepository.Update(sampleType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleTypeExists(Guid id)
        {
            return _context.SampleTypesRepository.Any(e => e.Id == id);
        }
    }
}
