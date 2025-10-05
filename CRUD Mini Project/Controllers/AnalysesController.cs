using AutoMapper;
using CRUD_Mini_Project.DAL;
using CRUD_Mini_Project.Models;
using CRUD_Mini_Project.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Mini_Project.Controllers
{
    public class AnalysesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly Guid DefaultUserId;
        public AnalysesController(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            DefaultUserId = Guid.Parse(_configuration["SystemSettings:DefaultUserId"]);
        }

        // GET: Analyses
        public async Task<IActionResult> Index()
        {
            var analyses = await _context.AnalysesRepository
                .Include(a => a.parameter)
                .Include(a => a.method)
                .Include(a => a.sample_type)
                .Where(x => x.IsActive == true).ToListAsync();
            var model = _mapper.Map<List<AnalyseViewModel>>(analyses);

            return View(model);
        }

        // GET: Analyses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyse = await _context.AnalysesRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analyse == null)
            {
                return NotFound();
            }

            return View(analyse);
        }

        // GET: Analyses/Create
        public async Task<IActionResult> Create()
        {
            ViewData["parameter_id"] = new SelectList(await _context.ParametersRepository.Where(x => x.IsActive == true).ToListAsync(), "Id", "code");

            ViewData["method_id"] = new SelectList( await _context.MethodsRepository.Where(x => x.IsActive == true).ToListAsync(), "Id", "code");

            ViewData["sample_type_id"] = new SelectList(await _context.SampleTypesRepository.Where(x => x.IsActive == true).ToListAsync(), "Id", "code");

            return View();
        }

        // POST: Analyses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,description,parameter_id,method_id,sample_type_id")] Analyse analyse)
        {
            if (ModelState.IsValid)
            {
                analyse.Id = Guid.NewGuid();
                analyse.CreatedById = DefaultUserId;
                analyse.CreatedOn = DateTime.Now;
                analyse.IsActive = true;
                _context.Add(analyse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analyse);
        }

        // GET: Analyses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyse = await _context.AnalysesRepository.FindAsync(id);
            if (analyse == null)
            {
                return NotFound();
            }
            return View(analyse);
        }

        // POST: Analyses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id)
        {
            var originalAnalyse = await _context.AnalysesRepository
                .FirstOrDefaultAsync(m => m.Id == id);

            if (originalAnalyse == null)
            {
                return NotFound();
            }

            bool isUpdateSuccessful = await TryUpdateModelAsync<Analyse>(
                originalAnalyse,
                "",
                a => a.code,
                a => a.description,
                a => a.parameter_id,  
                a => a.method_id,
                a => a.sample_type_id
            );

            if (isUpdateSuccessful && ModelState.IsValid)
            {
                originalAnalyse.LastUpdateDate = DateTime.Now;
                originalAnalyse.LastUpdateById = DefaultUserId;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyseExists(originalAnalyse.Id))
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
            return View(originalAnalyse);
        }
        // GET: Analyses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyse = await _context.AnalysesRepository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analyse == null)
            {
                return NotFound();
            }

            return View(analyse);
        }

        // POST: Analyses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var analyse = await _context.AnalysesRepository.FindAsync(id);
            if (analyse != null)
            {
                analyse.IsActive = false;
                _context.AnalysesRepository.Update(analyse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyseExists(Guid id)
        {
            return _context.AnalysesRepository.Any(e => e.Id == id);
        }
    }
}
