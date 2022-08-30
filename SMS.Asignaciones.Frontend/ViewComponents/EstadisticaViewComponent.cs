using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.ViewComponents
{
    [ViewComponent(Name = "Estadistica")]
    public class EstadisticaViewComponent : ViewComponent
    {
        private readonly AsignacionesDbContext _context;

        public EstadisticaViewComponent(AsignacionesDbContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            int anioActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            int diasFeriados = await _context.Feriado.Where(x => x.Fecha.Year == anioActual && x.Fecha.Month == mesActual).CountAsync();

            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.Date.AddMonths(1).AddDays(-1);
            double diasLaborales = Helper.GetBusinessDays(oPrimerDiaDelMes, oUltimoDiaDelMes) - diasFeriados;

            ViewData["Feriados"] = diasFeriados;
            ViewData["Laborales"] = diasLaborales;
            ViewData["Horas"] = diasLaborales * 8;
            ViewData["MesActual"] = Helper.GetNombreMes(DateTime.Now.Month);

            return View("_ViewEstadisticas");
        }
    }
}
