using CRUD_Mini_Project.DAL;
using CRUD_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Mini_Project.Controllers
{
    public class ParametersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly Guid DefaultUserId;

        public ParametersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            DefaultUserId = Guid.Parse(_configuration["SystemSettings:DefaultUserId"]);
        }

        // GET: Parameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParametersRepository.Where(x => x.IsActive == true).ToListAsync());
        }

        // GET: Parameters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.ParametersRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,description")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                parameter.Id = Guid.NewGuid();
                parameter.CreatedOn = DateTime.Now;
                parameter.CreatedById = DefaultUserId;
                parameter.IsActive = true;
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameter);
        }

        // GET: Parameters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.ParametersRepository.FindAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            return View(parameter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm]Guid Id)
        {   
            var originalParameter = await _context.ParametersRepository
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (originalParameter == null)
            {
                return NotFound();
            }

            bool isUpdateSuccessful = await TryUpdateModelAsync<Parameter>(
                originalParameter,
                "", 
                p => p.code,
                p => p.description
            );

            if (isUpdateSuccessful && ModelState.IsValid) 
            {
                originalParameter.LastUpdateDate = DateTime.Now;
                originalParameter.LastUpdateById = DefaultUserId;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterExists(originalParameter.Id))
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
            return View(originalParameter);
        }

        // GET: Parameters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.ParametersRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var parameter = await _context.ParametersRepository.FindAsync(id);
            if (parameter != null)
            {
                parameter.IsActive = false;
                _context.ParametersRepository.Update(parameter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParameterExists(Guid id)
        {
            return _context.ParametersRepository.Any(e => e.Id == id);
        }
    }
}
