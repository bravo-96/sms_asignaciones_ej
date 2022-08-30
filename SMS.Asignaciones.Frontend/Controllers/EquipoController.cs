using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    [Authorize(Roles = "Operaciones,HRBP,Administración")]
    public class EquipoController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public EquipoController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _context.Equipo.ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Equipo.ToListAsync();
            return PartialView("_ViewAll", model);
        }


        public async Task<PartialViewResult> SubEquipos(int id = 0)
        {
            var equipos = await _context.SubEquipo.Where(x => x.EquipoId == id).ToListAsync();
            SubEquiposViewModel model = new SubEquiposViewModel();
            model.EquipoId = id;
            model.SubEquipos.AddRange(equipos);
            var equipo = await _context.Equipo.FindAsync(id);
            model.Equipo = equipo.Nombre;

            return PartialView("_SubEquipos", model);
        }

        public async Task<PartialViewResult> Proyectos(int id = 0)
        {
            var equipos = await _context.SubEquipoProyecto.Include(x => x.Proyecto).Where(x => x.SubEquipoId == id).ToListAsync();
            ProyectosViewModel model = new ProyectosViewModel();
            model.Proyectos = new List<SubEquipoProyecto>();
            model.SubEquipoId = id;

            if (equipos.Count > 0)
                model.Proyectos.AddRange(equipos);
            var subEquipo = await _context.SubEquipo.FindAsync(id);
            model.SubEquipo = subEquipo.Nombre;

            return PartialView("_Proyectos", model);
        }

        [HttpPost]
        public async Task<IActionResult> HabilitarProyecto(int id, bool checkedState)
        {
            SubEquipoProyecto model = await _context.SubEquipoProyecto.FindAsync(id);
            model.Habilitado = checkedState;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }


        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Equipo model = new Equipo() { Id = 0 };
                return View(model);
            }
            else
            {
                var model = await _context.Equipo.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        public async Task<IActionResult> _CreateOrEditSubEquipo(int equipoId, int id = 0)
        {
            if (id == 0)
            {
                SubEquipo model = new SubEquipo() { Id = 0, EquipoId = equipoId };
                return View(model);
            }
            else
            {
                var model = await _context.SubEquipo.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Nombre")] Equipo model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Equipo.Any(e => e.Nombre.ToLower() == model.Nombre.ToLower());

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
                        if (!EquipoExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Equipo.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditSubEquipo(int id, [Bind("Id,Nombre,EquipoId")] SubEquipo model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.SubEquipo.Any(e => e.Nombre.ToLower() == model.Nombre.ToLower());

                    if (valorEnUso)
                    {
                        return Json(new { isValid = false, valorEnUso = true, html = Helper.RenderRazorViewToString(this, "_CreateOrEditSubEquipo", model) });
                    }
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();

                    int rowsAffected;
                    string sql = "EXEC AltaProyectosXSubEquipos @SubEquipoId";

                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                        new SqlParameter { ParameterName = "@SubEquipoId", Value = model.Id }
                    };

                    rowsAffected = _context.Database.ExecuteSqlRaw(sql, parms.ToArray());
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
                        if (!SubEquipoExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                var equipos = await _context.SubEquipo.Where(x => x.EquipoId == model.EquipoId).ToListAsync();
                SubEquiposViewModel modelo = new SubEquiposViewModel();
                modelo.EquipoId = model.EquipoId;
                modelo.SubEquipos.AddRange(equipos);
                var equipo = await _context.Equipo.FindAsync(model.EquipoId);
                modelo.Equipo = equipo.Nombre;

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_SubEquipos", modelo) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEditSubEquipo", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Equipo.FindAsync(id);

            _context.Equipo.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Equipo.ToListAsync()) });
        }

        [HttpPost, ActionName("DeleteSubEquipo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSubEquipo(int id)
        {
            var modelo = await _context.SubEquipo.FindAsync(id);

            int rowsAffected;
            string sql = "EXEC BajaProyectosXSubEquipos @SubEquipoId";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@SubEquipoId", Value = modelo.Id }
            };

            rowsAffected = _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var equipoId = modelo.EquipoId;

            _context.SubEquipo.Remove(modelo);
            await _context.SaveChangesAsync();

            var equipos = await _context.SubEquipo.Where(x => x.EquipoId == equipoId).ToListAsync();
            SubEquiposViewModel model = new SubEquiposViewModel();
            model.EquipoId = equipoId;
            model.SubEquipos.AddRange(equipos);
            var equipo = await _context.Equipo.FindAsync(equipoId);
            model.Equipo = equipo.Nombre;

            return Json(new { html = Helper.RenderRazorViewToString(this, "_SubEquipos", model) });
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }

        private bool SubEquipoExists(int id)
        {
            return _context.SubEquipo.Any(e => e.Id == id);
        }

    }
}
