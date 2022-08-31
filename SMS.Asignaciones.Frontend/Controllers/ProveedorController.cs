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
    //[Authorize(Roles = "Operaciones,HRBP,Administración")]
    public class ProveedorController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public ProveedorController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _context.Proveedor.ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Proveedor.ToListAsync();
            return PartialView("_ViewAll", model);
        }

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Proveedor model = new Proveedor() { Id = 0 };
                return View(model);
            }
            else
            {
                var model = await _context.Proveedor.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Nombre")] Proveedor model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Proveedor.Any(e => e.Nombre.ToLower() == model.Nombre.ToLower());

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
                        if (!ProveedorExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Proveedor.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Proveedor.FindAsync(id);

            _context.Proveedor.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Proveedor.ToListAsync()) });
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.Id == id);
        }


    }
}
