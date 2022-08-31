using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.Cryptography;
using SMS.Asignaciones.DataAccess;
using SMS.Asignaciones.Frontend.Models;
using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Controllers
{
    //[Authorize(Roles = "Operaciones,HRBP,Administración")]
    public class ColaboradorController : Controller
    {
        private readonly AsignacionesDbContext _context;
        private readonly IWebHostEnvironment _host;

        public ColaboradorController(AsignacionesDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).Include(x => x.Rol).Include(x => x.SubEquipo).ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> _ViewAll()
        {
            var model = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).ToListAsync();

            foreach(Colaborador empleado in model)
            {
                if (empleado.LiderColaboradorId.HasValue)
                {
                    var lider = await _context.Colaborador.FindAsync(empleado.LiderColaboradorId);
                    empleado.NombreLider = lider.Apellido.ToUpper() + ", " + lider.Nombre;
                }
            }

            return PartialView("_ViewAll", model);
        }

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Colaborador model = new Colaborador() { Id = 0, Equipo = new Equipo() { Id = 0 }, SubEquipo = new SubEquipo() { Id = 0 } , Proveedor = new Proveedor() { Id = 0 }, Rol = new Rol() { Id = 0 } };
                model.Password = HelperCryptography.EncryptPassword("SMSsudamerica");
                model.FechaAlta = DateTime.Today;
                model.HorasVariables = false;


                ViewData["EquipoId"] = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre", model.EquipoId);
                ViewData["SubEquipoId"] = new SelectList(await _context.SubEquipo.Where(x => x.EquipoId == model.EquipoId).ToListAsync(), "Id", "Nombre", model.SubEquipoId);
                ViewData["RolId"] = new SelectList(await _context.Rol.ToListAsync(), "Id", "Nombre", model.RolId);

                List<SelectListItem> itemsTipoContrato = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Relación Dependencia", Value = "0" },
                    new SelectListItem { Text = "Contratado", Value = "1" }
                };
                ViewData["TipoContratoId"] = itemsTipoContrato;

                ViewData["ProveedorId"] = new SelectList(await _context.Proveedor.Where(x => x.Nombre.Contains("SMS")).ToListAsync(), "Id", "Nombre", model.ProveedorId);

                return View(model);
            }
            else
            {
                Colaborador model = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == id).FirstOrDefaultAsync();

                ViewData["EquipoId"] = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre", model.EquipoId);

                List<SelectListItem> itemsSubEquipo = new SelectList(await _context.SubEquipo.Where(x => x.EquipoId == model.EquipoId).ToListAsync(), "Id", "Nombre", model.SubEquipoId).ToList();
                itemsSubEquipo.Insert(0, (new SelectListItem { Text = "Seleccione...", Value = "-1" }));
                ViewData["SubEquipoId"] = itemsSubEquipo;

                ViewData["RolId"] = new SelectList(await _context.Rol.ToListAsync(), "Id", "Nombre", model.RolId);

                List<SelectListItem> itemsTipoContrato = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Relación Dependencia", Value = "0" },
                    new SelectListItem { Text = "Contratado", Value = "1" }
                };
                ViewData["TipoContratoId"] = itemsTipoContrato;

                var proveedores = await _context.Proveedor.ToListAsync();

                if (model.ProveedorId == 1)
                {
                    proveedores = proveedores.Where(x => x.Nombre.Contains("SMS")).ToList();                 
                }
                else
                {
                    proveedores = proveedores.Where(x => !x.Nombre.Contains("SMS")).ToList();
                }

                ViewData["ProveedorId"] = new SelectList(proveedores, "Id", "Nombre", model.ProveedorId);

                if (model.LiderColaboradorId.HasValue)
                {
                    var lider = await _context.Colaborador.FindAsync(model.LiderColaboradorId.Value);
                    model.NombreLider = lider.Nombre = lider.Apellido.ToUpper() + ", " + lider.Nombre + " (Legajo: " + lider.Legajo + ")";
                }               

                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Nombre,Apellido,Lider,LiderSubEquipo,EquipoId,Equipo,ProveedorId,Proveedor,Email,Foto,Password,RolId,Rol,Legajo, SubEquipo,SubEquipoId,FechaAlta,FechaBaja,LiderColaboradorId,TipoContratoId,HorasVariables")] Colaborador model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    bool valorEnUso = _context.Colaborador.Any(e => e.Nombre.ToLower() == model.Nombre.ToLower() && e.Apellido.ToLower() == model.Apellido.ToLower() &&
                    e.EquipoId == model.EquipoId && e.ProveedorId == model.ProveedorId);

                    if (valorEnUso)
                    {
                        return Json(new { isValid = false, valorEnUso = true, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
                    }

                    if (model.SubEquipoId.HasValue && model.SubEquipoId.Value == -1)
                        model.SubEquipoId = null;


                    string avatar = Path.Combine(Path.Combine(_host.WebRootPath, "images"), "avatar.png");

                    model.Foto = await System.IO.File.ReadAllBytesAsync(avatar);

                    if (model.ProveedorId == 0)
                        model.ProveedorId = 1;

                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        if (model.SubEquipoId.HasValue && model.SubEquipoId.Value == -1)
                            model.SubEquipoId = null;

                        if (model.ProveedorId == 0)
                            model.ProveedorId = 1;

                        _context.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ColaboradorExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                    catch(Exception ex)
                    {
                        string err = ex.Message;
                    }
                }

                var modelResultado = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).Include(x => x.Rol).Include(x => x.SubEquipo).ToListAsync();

               foreach (Colaborador empleado in modelResultado)
                {
                    if (empleado.LiderColaboradorId.HasValue)
                    {
                        var lider = await _context.Colaborador.FindAsync(empleado.LiderColaboradorId);
                        empleado.NombreLider = lider.Apellido.ToUpper() + ", " + lider.Nombre;
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", modelResultado) });
            }

            ViewData["EquipoId"] = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre", model.EquipoId);
            ViewData["ProveedorId"] = new SelectList(await _context.Proveedor.ToListAsync(), "Id", "Nombre", model.ProveedorId);
            ViewData["RolId"] = new SelectList(await _context.Rol.ToListAsync(), "Id", "Nombre", model.RolId);

            List<SelectListItem> itemsTipoContrato = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Relación Dependencia", Value = "0" },
                    new SelectListItem { Text = "Contratado", Value = "1" }
                };
            ViewData["TipoContratoId"] = itemsTipoContrato;

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Colaborador.FindAsync(id);

            _context.Colaborador.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).Include(x => x.Rol).Include(x => x.SubEquipo).ToListAsync()) });
        }

        [HttpPost, ActionName("ResetPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassowrdConfirmed(int id)
        {
            var model = await _context.Colaborador.FindAsync(id);
            model.Password = HelperCryptography.EncryptPassword("SMSsudamerica");
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Proveedor).Include(x => x.Rol).Include(x => x.SubEquipo).ToListAsync()) });
        }


        [HttpGet]
        public async Task<JsonResult> GetSubEquipos(int equipoId)
        {
            var model = await _context.SubEquipo.Where(x => x.EquipoId == equipoId).ToListAsync();
            return Json(new SelectList(model.OrderBy(x => x.Id), "Id", "Nombre"));
        }

        [HttpGet]
        public async Task<JsonResult> GetProveedores(int tipoContratoId)
        {
            var proveedores = await _context.Proveedor.ToListAsync();

            if (tipoContratoId == 0)
            {
                proveedores = proveedores.Where(x => x.Nombre.Contains("SMS")).ToList();
            }
            else
            {
                proveedores = proveedores.Where(x => !x.Nombre.Contains("SMS")).ToList();
            }

            return Json(new SelectList(proveedores.OrderBy(x => x.Id), "Id", "Nombre"));
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.Id == id);
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
                Nombre = x.Apellido.ToUpper() + ", " + x.Nombre + " (Legajo: " + x.Legajo + ")"
            }).Take(5).ToListAsync();

            return Json(colaborador);
        }


        public async Task<IActionResult> Excel()
        {
            var model = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.SubEquipo)
                    .Include(x => x.Proveedor).Include(x => x.Rol).ToListAsync();

            foreach (Colaborador empleado in model)
            {
                if (empleado.LiderColaboradorId.HasValue)
                {
                    var lider = await _context.Colaborador.FindAsync(empleado.LiderColaboradorId);
                    empleado.NombreLider = lider.Apellido.ToUpper() + ", " + lider.Nombre;
                }
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Colaboradores");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Legajo";
                worksheet.Cell(currentRow, 2).Value = "Nombre";
                worksheet.Cell(currentRow, 3).Value = "Apellido";
                worksheet.Cell(currentRow, 4).Value = "Tipo Contrato";
                worksheet.Cell(currentRow, 5).Value = "Proveedor";
                worksheet.Cell(currentRow, 6).Value = "Alta";
                worksheet.Cell(currentRow, 7).Value = "Lider";
                worksheet.Cell(currentRow, 8).Value = "Email";
                worksheet.Cell(currentRow, 9).Value = "Rol";
                worksheet.Cell(currentRow, 10).Value = "Equipo";
                worksheet.Cell(currentRow, 11).Value = "Subequipo";
                worksheet.Cell(currentRow, 12).Value = "Baja";
                foreach (var r in model)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = r.Legajo;
                    worksheet.Cell(currentRow, 2).Value = r.Nombre;
                    worksheet.Cell(currentRow, 3).Value = r.Apellido;
                    worksheet.Cell(currentRow, 4).Value = (r.ProveedorId == 1) ? "Rel. Dep." : "Contratado";
                    worksheet.Cell(currentRow, 5).Value = r.Proveedor.Nombre;
                    worksheet.Cell(currentRow, 6).Value = r.FechaAlta;
                    worksheet.Cell(currentRow, 7).Value = r.NombreLider;
                    worksheet.Cell(currentRow, 8).Value = r.Email;
                    worksheet.Cell(currentRow, 9).Value = r.Rol.Nombre;
                    worksheet.Cell(currentRow, 10).Value = r.Equipo.Nombre;
                    worksheet.Cell(currentRow, 11).Value = (r.SubEquipoId.HasValue) ? r.SubEquipo.Nombre: "";
                    worksheet.Cell(currentRow, 12).Value = r.FechaBaja;


                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Colaboradores_" + DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + ".xlsx");
                }
            }

        }

    }
}
