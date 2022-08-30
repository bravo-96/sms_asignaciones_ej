using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.DataAccess;
using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Controllers
{
    [Authorize(Roles = "Operaciones,HRBP,Administración")]
    public class FeriadoController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public FeriadoController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _context.Feriado.ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Feriado.ToListAsync();
            return PartialView("_ViewAll", model);
        }

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Feriado model = new Feriado() { Id = 0, Fecha  = DateTime.Today };
                return View(model);
            }
            else
            {
                var model = await _context.Feriado.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Motivo,Fecha")] Feriado model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Feriado.Any(e => e.Motivo.ToLower() == model.Motivo.ToLower() && e.Fecha == model.Fecha);

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
                        if (!FeriadoExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Feriado.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Feriado.FindAsync(id);

            _context.Feriado.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Feriado.ToListAsync()) });
        }

        private bool FeriadoExists(int id)
        {
            return _context.Feriado.Any(e => e.Id == id);
        }

    }
}
