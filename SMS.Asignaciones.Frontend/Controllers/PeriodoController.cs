using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.DataAccess;
using SMS.Asignaciones.Frontend.Models;
using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SMS.Asignaciones.Frontend.Controllers
{
    //[Authorize(Roles = "Operaciones,HRBP,Administración")]
    public class PeriodoController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public PeriodoController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _context.Periodo.ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Periodo.ToListAsync();
            return PartialView("_ViewAll", model);
        }

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Periodo model = new Periodo() { Id = 0, Anio = DateTime.Today.Year, Mes = DateTime.Today.Month, Habilitado = false };

                List<ItemViewModel> anios = new List<ItemViewModel>();
                DateTime fecha = DateTime.Today;
                anios.Add(new ItemViewModel() { Id = fecha.AddYears(-1).Year, Valor = fecha.AddYears(-1).Year.ToString() });
                anios.Add(new ItemViewModel() { Id = fecha.Year, Valor = fecha.Year.ToString() });
                anios.Add(new ItemViewModel() { Id = fecha.AddYears(+1).Year, Valor = fecha.AddYears(+1).Year.ToString() });

                ViewData["Anio"] = new SelectList(anios, "Id", "Valor", model.Anio);

                List<ItemViewModel> meses = new List<ItemViewModel>();

                meses.Add(new ItemViewModel() { Id = 1, Valor = "ENERO" });
                meses.Add(new ItemViewModel() { Id = 2, Valor = "FEBRERO" });
                meses.Add(new ItemViewModel() { Id = 3, Valor = "MARZO" });
                meses.Add(new ItemViewModel() { Id = 4, Valor = "ABRIL" });
                meses.Add(new ItemViewModel() { Id = 5, Valor = "MAYO" });
                meses.Add(new ItemViewModel() { Id = 6, Valor = "JUNIO" });
                meses.Add(new ItemViewModel() { Id = 7, Valor = "JULIO" });
                meses.Add(new ItemViewModel() { Id = 8, Valor = "AGOSTO" });
                meses.Add(new ItemViewModel() { Id = 9, Valor = "SEPTIEMBRE" });
                meses.Add(new ItemViewModel() { Id = 10, Valor = "OCTUBRE" });
                meses.Add(new ItemViewModel() { Id = 11, Valor = "NOVIEMBRE" });
                meses.Add(new ItemViewModel() { Id = 12, Valor = "DICIEMBRE" });

                ViewData["Mes"] = new SelectList(meses, "Id", "Valor", model.Mes);

                return View(model);
            }
            else
            {
                var model = await _context.Periodo.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                List<ItemViewModel> anios = new List<ItemViewModel>();
                DateTime fecha = DateTime.Today;
                anios.Add(new ItemViewModel() { Id = fecha.AddYears(-1).Year, Valor = fecha.AddYears(-1).Year.ToString() });
                anios.Add(new ItemViewModel() { Id = fecha.Year, Valor = fecha.Year.ToString() });
                anios.Add(new ItemViewModel() { Id = fecha.AddYears(+1).Year, Valor = fecha.AddYears(+1).Year.ToString() });

                ViewData["Anio"] = new SelectList(anios, "Id", "Valor", model.Anio);

                List<ItemViewModel> meses = new List<ItemViewModel>();

                meses.Add(new ItemViewModel() { Id = 1, Valor = "ENERO" });
                meses.Add(new ItemViewModel() { Id = 2, Valor = "FEBRERO" });
                meses.Add(new ItemViewModel() { Id = 3, Valor = "MARZO" });
                meses.Add(new ItemViewModel() { Id = 4, Valor = "ABRIL" });
                meses.Add(new ItemViewModel() { Id = 5, Valor = "MAYO" });
                meses.Add(new ItemViewModel() { Id = 6, Valor = "JUNIO" });
                meses.Add(new ItemViewModel() { Id = 7, Valor = "JULIO" });
                meses.Add(new ItemViewModel() { Id = 8, Valor = "AGOSTO" });
                meses.Add(new ItemViewModel() { Id = 9, Valor = "SEPTIEMBRE" });
                meses.Add(new ItemViewModel() { Id = 10, Valor = "OCTUBRE" });
                meses.Add(new ItemViewModel() { Id = 11, Valor = "NOVIEMBRE" });
                meses.Add(new ItemViewModel() { Id = 12, Valor = "DICIEMBRE" });

                ViewData["Mes"] = new SelectList(meses, "Id", "Valor", model.Mes);

                return View(model);
            }


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Anio,Mes,Habilitado")] Periodo model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Periodo.Any(e => e.Anio == model.Anio && e.Mes == model.Mes );

                    if (valorEnUso)
                    {
                        return Json(new { isValid = false, valorEnUso = true, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
                    }
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PeriodoExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Periodo.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Periodo.FindAsync(id);

            _context.Periodo.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Periodo.ToListAsync()) });
        }

        private bool PeriodoExists(int id)
        {
            return _context.Periodo.Any(e => e.Id == id);
        }

    }
}
