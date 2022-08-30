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
    public class PendienteController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public PendienteController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int anioActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            List<ItemViewModel> anios = new List<ItemViewModel>();
            anios.Add(new ItemViewModel() { Id = anioActual, Valor = anioActual.ToString() });

            ViewData["AnioActualId"] = new SelectList(anios, "Id", "Valor", anioActual);

            List<ItemViewModel> meses = new List<ItemViewModel>();
            meses.Add(new ItemViewModel() { Id = mesActual, Valor = Helper.GetNombreMes(mesActual) });

            List<int> mexes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            mexes = mexes.Where(x => x != mesActual).ToList();
            foreach (int mes in mexes)
                meses.Add(new ItemViewModel() { Id = mes, Valor = Helper.GetNombreMes(mes) });

            ViewData["MesActualId"] = new SelectList(meses, "Id", "Valor", mesActual);


            return View();
        }

        public async Task<ActionResult> _ViewAll(int anio = 0, int mes = 0)
        {
            List<PendientesViewModel> model = new List<PendientesViewModel>();

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
            else if (colaborador.Rol.Nombre == "Líder" || colaborador.Rol.Nombre == "Operaciones" || colaborador.Rol.Nombre == "HRBP")
            {
                var owner = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
                colaboradores = colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                colaboradores.AddRange(owner);
            }

            Helper helper = new Helper(_context);

            foreach(var empleado in colaboradores)
            {
                PendientesViewModel pvm = new PendientesViewModel();
                pvm.Anio = anio;
                pvm.EstadoCarga = await helper.GetStatusDeCarga(empleado.Id, anio, mes);
                pvm.HorasExtraCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == empleado.Id && x.HorasExtra).SumAsync(x => x.Horas);
                pvm.HorasMes = await helper.GetDiasLaboralesColaborador(empleado.Id, anio, mes) * 8;
                pvm.HorasNormalesCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == empleado.Id && !x.HorasExtra).SumAsync(x => x.Horas);
                pvm.Legajo = empleado.Legajo;
                pvm.Mes = Helper.GetNombreMes(mes);
                pvm.NombreCompleto = empleado.NombreCompleto;
                pvm.Proveedor = empleado.Proveedor.Nombre;
                pvm.HorasVariables = empleado.HorasVariables;

                model.Add(pvm);
            }


            return PartialView("_ViewAll", model.Where(x => x.EstadoCarga != "FINALIZADA"));
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

        public async Task<IActionResult> Excel(int anio = 0, int mes = 0)
        { 

            List<PendientesViewModel> model = new List<PendientesViewModel>();

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
            else if (colaborador.Rol.Nombre == "Líder" || colaborador.Rol.Nombre == "Operaciones" || colaborador.Rol.Nombre == "HRBP")
            {
                var owner = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
                colaboradores = colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                colaboradores.AddRange(owner);
            }

            Helper helper = new Helper(_context);

            foreach(var empleado in colaboradores)
            {
                PendientesViewModel pvm = new PendientesViewModel();
                pvm.Anio = anio;
                pvm.EstadoCarga = await helper.GetStatusDeCarga(empleado.Id, anio, mes);
                pvm.HorasExtraCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == empleado.Id && x.HorasExtra).SumAsync(x => x.Horas);
                pvm.HorasMes = await helper.GetDiasLaboralesColaborador(empleado.Id, anio, mes) * 8;
                pvm.HorasNormalesCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == empleado.Id && !x.HorasExtra).SumAsync(x => x.Horas);
                pvm.Legajo = empleado.Legajo;
                pvm.Mes = Helper.GetNombreMes(mes);
                pvm.NombreCompleto = empleado.NombreCompleto;
                pvm.Proveedor = empleado.Proveedor.Nombre;
                pvm.HorasVariables = empleado.HorasVariables;

                model.Add(pvm);
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("CargasPendientes");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Año";
                worksheet.Cell(currentRow, 2).Value = "Mes";
                worksheet.Cell(currentRow, 3).Value = "Colaborador";
                worksheet.Cell(currentRow, 4).Value = "Legajo";
                worksheet.Cell(currentRow, 5).Value = "Hs.Mes";
                worksheet.Cell(currentRow, 6).Value = "Hs.Cargadas";
                worksheet.Cell(currentRow, 7).Value = "Hs.Extra";
                worksheet.Cell(currentRow, 8).Value = "Hs.Restantes";
                worksheet.Cell(currentRow, 9).Value = "Estado";
                foreach (var r in model)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = r.Anio;
                    worksheet.Cell(currentRow, 2).Value = r.Mes;
                    worksheet.Cell(currentRow, 3).Value = r.NombreCompleto;
                    worksheet.Cell(currentRow, 4).Value = r.Legajo;
                    worksheet.Cell(currentRow, 5).Value = (r.CargaLibre) ? "Libre" : r.HorasMes;
                    worksheet.Cell(currentRow, 6).Value = r.HorasNormalesCargadas;
                    worksheet.Cell(currentRow, 7).Value = r.HorasExtraCargadas;
                    worksheet.Cell(currentRow, 8).Value = (r.CargaLibre) ? "Libre" : r.HorasRestantes;
                    worksheet.Cell(currentRow, 9).Value = (r.CargaLibre) ? "Libre" : r.EstadoCarga;

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "CargaPendiente_" + anio.ToString() + "-" + mes.ToString() + ".xlsx");
                }
            }

        }



}
}
