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
    public class LicenciaController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public LicenciaController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Licencia.ToListAsync();
            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Licencia.Include(x => x.Colaborador).Include(x => x.TipoLicencia).ToListAsync();
            return PartialView("_ViewAll", model);
        }

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Licencia model = new Licencia() { Id = 0, Desde = DateTime.Today, Hasta = DateTime.Today };
                ViewData["TipoLicenciaId"] = new SelectList(await _context.TipoLicencia.ToListAsync(), "Id", "Descripcion", model.TipoLicenciaId);
                return View(model);
            }
            else
            {
                var model = await _context.Licencia.Include(x => x.Colaborador).Include(x => x.TipoLicencia).Where(x => x.Id == id).FirstOrDefaultAsync();
                model.Nombre = model.Colaborador.Apellido.ToUpper() + ", " + model.Colaborador.Nombre + " (Legajo: " + model.Colaborador.Legajo + ")";
                if (model == null)
                {
                    return NotFound();
                }
                ViewData["TipoLicenciaId"] = new SelectList(await _context.TipoLicencia.ToListAsync(), "Id", "Descripcion", model.TipoLicenciaId);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Colaborador,ColaboradorId,TipoLicencia,TipoLicenciaId,Desde,Hasta")] Licencia model)
        {
            if (ModelState.IsValid)
            {
                if (model.ColaboradorId == 0)
                {
                    ViewData["TipoLicenciaId"] = new SelectList(await _context.TipoLicencia.ToListAsync(), "Id", "Descripcion", model.TipoLicenciaId);
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
                }


                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Licencia.Any(e => e.ColaboradorId == model.ColaboradorId && e.TipoLicenciaId == model.TipoLicenciaId 
                            && e.Desde == model.Desde && e.Hasta == model.Hasta);

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
                        if (!LicenciaExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Licencia.Include(x => x.Colaborador).Include(x => x.TipoLicencia).ToListAsync()) });
            }
            ViewData["TipoLicenciaId"] = new SelectList(await _context.TipoLicencia.ToListAsync(), "Id", "Descripcion", model.TipoLicenciaId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Licencia.FindAsync(id);

            _context.Licencia.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Licencia.Include(x => x.Colaborador).Include(x => x.TipoLicencia).ToListAsync()) });
        }

        private bool LicenciaExists(int id)
        {
            return _context.Licencia.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<JsonResult> SearchColaborador(string Prefix)
        {

            var colaborador = await _context.Colaborador
                .Where(x => x.Nombre.StartsWith(Prefix) || x.Apellido.StartsWith(Prefix))
            .Select(x => new ColaboradorSuggesterViewModel()
            {
                Id = x.Id,
                Legajo = x.Legajo,
                Nombre = x.Apellido.ToUpper() + ", "  + x.Nombre + " (Legajo: " + x.Legajo + ")"
            }).Take(5).ToListAsync();


            colaborador = colaborador.Where(x => x.FechaBaja == null || (x.FechaBaja.Value.Year == DateTime.Now.Year &&
                    x.FechaBaja.Value.Month == DateTime.Now.Month && x.FechaBaja.Value.Day >= DateTime.Now.Day)).ToList();

            return Json(colaborador);
        }

    }
}
