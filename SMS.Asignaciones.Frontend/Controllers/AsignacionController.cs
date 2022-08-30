using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    [Authorize(Roles = "Operaciones,HRBP,Administración,Líder")]
    public class AsignacionController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public AsignacionController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int anioActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            List<ItemViewModel> anios = new List<ItemViewModel>();

            //if (mesActual == 1)
            //    anios.Add(new ItemViewModel() { Id = anioActual - 1, Valor = (anioActual - 1).ToString() });

            anios.Add(new ItemViewModel() { Id = anioActual, Valor = anioActual.ToString() });

            //if(mesActual == 12)
            //    anios.Add(new ItemViewModel() { Id = anioActual+1, Valor = (anioActual+1).ToString() });

            ViewData["AnioActualId"] = new SelectList(anios, "Id", "Valor", anioActual);

            List<ItemViewModel> meses = new List<ItemViewModel>();

            meses.Add(new ItemViewModel() { Id = mesActual, Valor = Helper.GetNombreMes(mesActual) });
            //meses.Add(new ItemViewModel() { Id = DateTime.Now.AddMonths(-1).Month, Valor = Helper.GetNombreMes(DateTime.Now.AddMonths(-1).Month) });

            List<int> mexes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            mexes = mexes.Where(x => x != mesActual).ToList();
            foreach (int mes in mexes)
                meses.Add(new ItemViewModel() { Id = mes, Valor = Helper.GetNombreMes(mes) });



            ViewData["MesActualId"] = new SelectList(meses, "Id", "Valor", mesActual);

            List<SelectListItem> itemsProveedorId = new SelectList(await _context.Proveedor.ToListAsync(), "Id", "Nombre").ToList();
            itemsProveedorId.Insert(0, (new SelectListItem { Text = "", Value = "-1" }));

            List<SelectListItem> itemsProyectoId = new SelectList(await _context.Proyecto.ToListAsync(), "Id", "Nombre").ToList();
            itemsProyectoId.Insert(0, (new SelectListItem { Text = "", Value = "-1" }));

            List<SelectListItem> itemsEquipoId = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre").ToList();
            itemsEquipoId.Insert(0, (new SelectListItem { Text = "", Value = "-1" }));

            ViewData["ProveedorId"] = itemsProveedorId;
            ViewData["ProyectoId"] = itemsProyectoId;
            ViewData["EquipoId"] = itemsEquipoId;

            return View();
        }

        public async Task<ActionResult> _ViewAll(int anio = 0, int mes = 0, int proveedorId = 0, int proyectoId = 0, int equipoId = 0)
        {
            List<AsignacionesViewModel> model = new List<AsignacionesViewModel>();

            anio = (anio > 0) ? anio : DateTime.Now.Year;
            mes = (mes > 0) ? mes : DateTime.Now.Month;

            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == id).FirstOrDefaultAsync();

            var colaboradores = await _context.Colaborador.Include(x => x.Proveedor).Where(x => !x.FechaBaja.HasValue ||
                    (x.FechaBaja.Value.Year == anio && x.FechaBaja.Value.Month == mes)).ToListAsync();

            if (colaborador.Rol.Nombre == "Colaborador")
            {
                colaboradores = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
            }
            else if (colaborador.Rol.Nombre == "Líder")
            {
                var owner = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
                colaboradores = colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                colaboradores.AddRange(owner);
            }

            List<int> ListaColaboradorId = new List<int>();

            if (colaborador.Rol.Nombre == "Administración" || colaborador.Rol.Nombre == "HRBP" || colaborador.Rol.Nombre == "Operaciones")
            {
                ListaColaboradorId.AddRange(colaboradores.Select(x => x.Id).ToList());
            } 
            else
            {
                ListaColaboradorId.AddRange(colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).Select(x => x.Id).ToList());
            }              

            var asignaciones = await _context.Asignacion.Include(x => x.Colaborador).ThenInclude(x => x.Proveedor)
                .Include(x => x.Colaborador).ThenInclude(x => x.Equipo)
                .Include(x => x.Proyecto).Where(x => x.Anio == anio && x.Mes == mes && ListaColaboradorId.Contains(x.ColaboradorId)).ToListAsync();

            if (proyectoId > 0)
            {
                asignaciones = asignaciones.Where(x => x.ProyectoId == proyectoId).ToList();
            }

            if(proveedorId > 0)
            {
                List<int> iduProveedor = await _context.Colaborador.Where(x => x.ProveedorId == proveedorId).Select(x => x.Id).ToListAsync();
                asignaciones = asignaciones.Where(x => iduProveedor.Contains(x.ColaboradorId)).ToList();
            }

            if (equipoId > 0)
            {
                List<int> iduEquipo = await _context.Colaborador.Where(x => x.EquipoId == equipoId).Select(x => x.Id).ToListAsync();
                asignaciones = asignaciones.Where(x => iduEquipo.Contains(x.ColaboradorId)).ToList();
            }

            foreach (Asignacion item in asignaciones)
            {
                AsignacionesViewModel avm = new AsignacionesViewModel();

                avm.Anio = anio;
                avm.ColaboradorNombre = item.Colaborador.Apellido + ", " + item.Colaborador.Nombre;
                avm.Horas = item.Horas;
                avm.ProyectoNombre = item.Proyecto.Nombre;
                avm.EquipoNombre = item.Colaborador.Equipo.Nombre;
                avm.ProovedorNombre = item.Colaborador.Proveedor.Nombre;
                avm.Extras = item.HorasExtra;

                model.Add(avm);
            }

            
            return PartialView("_ViewAll", model);
        }

        [HttpPost]
        public List<ItemViewModel> CargarMeses(int anio)
        {
            int anioActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            List<ItemViewModel> meses = new List<ItemViewModel>();

            if (anio == anioActual)
            {
                meses.Add(new ItemViewModel() { Id = mesActual, Valor = Helper.GetNombreMes(mesActual) });
                meses.Add(new ItemViewModel() { Id = DateTime.Now.AddMonths(-1).Month, Valor = Helper.GetNombreMes(DateTime.Now.AddMonths(-1).Month) });
            }

            if (anio > anioActual)
            {
                meses.Add(new ItemViewModel() { Id = 1, Valor = Helper.GetNombreMes(1) });
            }

            if (anio < anioActual)
            {
                meses.Add(new ItemViewModel() { Id = 12, Valor = Helper.GetNombreMes(12) });
            }

            meses.Add(new ItemViewModel() { Id = mesActual, Valor = Helper.GetNombreMes(mesActual) });

            //return Json(meses, new Newtonsoft.Json.JsonSerializerSettings());
            return meses;
        }

        public async Task<IActionResult> Excel(int anio = 0, int mes = 0, int proveedorId = 0, int proyectoId = 0, int equipoId = 0)
        {
            List<AsignacionesViewModel> model = new List<AsignacionesViewModel>();

            anio = (anio > 0) ? anio : DateTime.Now.Year;
            mes = (mes > 0) ? mes : DateTime.Now.Month;

            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == id).FirstOrDefaultAsync();

            var colaboradores = await _context.Colaborador.Include(x => x.Proveedor).Where(x => !x.FechaBaja.HasValue ||
                    (x.FechaBaja.Value.Year == anio && x.FechaBaja.Value.Month == mes)).ToListAsync();

            if (colaborador.Rol.Nombre == "Colaborador")
            {
                colaboradores = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
            }
            else if (colaborador.Rol.Nombre == "Líder")
            {
                var owner = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
                colaboradores = colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                colaboradores.AddRange(owner);
            }

            List<int> ListaColaboradorId = new List<int>();

            if (colaborador.Rol.Nombre == "Administración" || colaborador.Rol.Nombre == "HRBP" || colaborador.Rol.Nombre == "Operaciones")
            {
                ListaColaboradorId.AddRange(colaboradores.Select(x => x.Id).ToList());
            }
            else
            {
                ListaColaboradorId.AddRange(colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).Select(x => x.Id).ToList());
            }

            var asignaciones = await _context.Asignacion.Include(x => x.Colaborador).ThenInclude(x => x.Proveedor)
                .Include(x => x.Colaborador).ThenInclude(x => x.Equipo)
                .Include(x => x.Proyecto).Where(x => x.Anio == anio && x.Mes == mes && ListaColaboradorId.Contains(x.ColaboradorId)).ToListAsync();

            if (proyectoId > 0)
            {
                asignaciones = asignaciones.Where(x => x.ProyectoId == proyectoId).ToList();
            }

            if (proveedorId > 0)
            {
                List<int> iduProveedor = await _context.Colaborador.Where(x => x.ProveedorId == proveedorId).Select(x => x.Id).ToListAsync();
                asignaciones = asignaciones.Where(x => iduProveedor.Contains(x.ColaboradorId)).ToList();
            }

            if (equipoId > 0)
            {
                List<int> iduEquipo = await _context.Colaborador.Where(x => x.EquipoId == equipoId).Select(x => x.Id).ToListAsync();
                asignaciones = asignaciones.Where(x => iduEquipo.Contains(x.ColaboradorId)).ToList();
            }

            foreach (Asignacion item in asignaciones)
            {
                AsignacionesViewModel avm = new AsignacionesViewModel();

                avm.Anio = anio;
                avm.ColaboradorNombre = item.Colaborador.Apellido + ", " + item.Colaborador.Nombre;

                var col = await _context.Colaborador.FindAsync(item.ColaboradorId);

                avm.Legajo = col.Legajo;
                avm.Horas = item.Horas;
                avm.Extras = item.HorasExtra;
                avm.ProyectoNombre = item.Proyecto.Nombre;
                avm.EquipoNombre = item.Colaborador.Equipo.Nombre;
                avm.ProovedorNombre = item.Colaborador.Proveedor.Nombre;

                model.Add(avm);
            }

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Asignaciones");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Legajo";
                    worksheet.Cell(currentRow, 2).Value = "Colaborador";
                    worksheet.Cell(currentRow, 3).Value = "Proveedor";
                    worksheet.Cell(currentRow, 4).Value = "Proyecto";
                    worksheet.Cell(currentRow, 5).Value = "Equipo";
                    worksheet.Cell(currentRow, 6).Value = "Horas";
                    worksheet.Cell(currentRow, 7).Value = "Tipo Horas";
                foreach (var r in model)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = r.Legajo;
                        worksheet.Cell(currentRow, 2).Value = r.ColaboradorNombre;
                        worksheet.Cell(currentRow, 3).Value = r.ProovedorNombre;
                        worksheet.Cell(currentRow, 4).Value = r.ProyectoNombre;
                        worksheet.Cell(currentRow, 5).Value = r.EquipoNombre;
                        worksheet.Cell(currentRow, 6).Value = r.Horas;
                        worksheet.Cell(currentRow, 7).Value = (r.Extras) ? "Extra" : "Normales";

                }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();

                        return File(
                            content,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "Asignaciones_" + anio.ToString() +"-" + mes.ToString() + ".xlsx");
                    }
                }
           
        }


    }
}
