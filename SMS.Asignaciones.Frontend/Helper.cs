using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.DataAccess;
using SMS.Asignaciones.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend
{
    public class Helper
    {
        private readonly AsignacionesDbContext _context;

        public Helper(AsignacionesDbContext context)
        {
            _context = context;
        }

        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );
                viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static double GetBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

        public static string GetNombreMes(int mes)
        {
            string nombre = "Mes no válido";

            switch(mes)
            {
                case 1: nombre = "ENERO"; break;
                case 2: nombre = "FEBRERO"; break;
                case 3: nombre = "MARZO"; break;
                case 4: nombre = "ABRIL"; break;
                case 5: nombre = "MAYO"; break;
                case 6: nombre = "JUNIO"; break;
                case 7: nombre = "JULIO"; break;
                case 8: nombre = "AGOSTO"; break;
                case 9: nombre = "SEPTIEMBRE"; break;
                case 10: nombre = "OCTUBRE"; break;
                case 11: nombre = "NOVIEMBRE"; break;
                case 12: nombre = "DICIEMBRE"; break;
            }

            return nombre;
        }

        public async Task<int> GetDiasLicencia(int colaboradorId, int anio, int mes)
        {
            var licencias = await _context.Licencia.Where(x => x.ColaboradorId == colaboradorId && x.Desde.Month == mes && x.Desde.Year == anio).ToListAsync();

            int diasLicencia = 0;

            foreach (var dia in licencias)
            {
                TimeSpan difFechas = dia.Hasta - dia.Desde;
                diasLicencia += difFechas.Days + 1;
            }

            return diasLicencia;
        }

        public async Task<int> GetDiasFeriados(int anio, int mes)
        {
            return await _context.Feriado.Where(x => x.Fecha.Year == anio && x.Fecha.Month == mes).CountAsync();
        }

        public int GetDiasLaborales(int anio, int mes)
        {
            DateTime oPrimerDiaDelMes = new DateTime(anio, mes, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.Date.AddMonths(1).AddDays(-1);
            return int.Parse((GetBusinessDays(oPrimerDiaDelMes, oUltimoDiaDelMes)).ToString());
        }

        public async Task<int> GetDiasProporcionales(int colaboradorId, int anio, int mes)
        {
            int dias = 0;
            int diasLaborales = 0;

            Colaborador empleado = await _context.Colaborador.FindAsync(colaboradorId);

            if (empleado.FechaAlta.HasValue)
            {
                var fechaAlta = empleado.FechaAlta.Value;
                if (fechaAlta.Year == anio && fechaAlta.Month == mes)
                {
                    DateTime primerDiaMes = new DateTime(anio, mes, 1);

                    DateTime oPrimerDiaDelMes = new DateTime(anio, mes, fechaAlta.Day);
                    DateTime oUltimoDiaDelMes = primerDiaMes.Date.AddMonths(1).AddDays(-1);
                    dias = int.Parse((GetBusinessDays(oPrimerDiaDelMes, oUltimoDiaDelMes)).ToString());

                    //DateTime oPrimerDiaDelMesLaboral = new DateTime(anio, mes, 1);
                    //DateTime oUltimoDiaDelMesLaboral = oPrimerDiaDelMesLaboral.Date.AddMonths(1).AddDays(-1);
                    //diasLaborales = int.Parse((GetBusinessDays(oPrimerDiaDelMesLaboral, oUltimoDiaDelMesLaboral)).ToString());

                    //dias = diasLaborales - dias;
                }
            }

            if (empleado.FechaBaja.HasValue)
            {
                var fechaBaja = empleado.FechaBaja.Value;
                if (fechaBaja.Year == anio && fechaBaja.Month == mes)
                {
                    DateTime oPrimerDiaDelMes = new DateTime(anio, mes, 1);
                    DateTime oUltimoDiaDelMes = new DateTime(anio, mes, fechaBaja.Day);
                    dias = int.Parse((GetBusinessDays(oPrimerDiaDelMes, oUltimoDiaDelMes)).ToString());
                }
            }

            return (dias < 0) ? dias * -1 : dias ;
        }

        public async Task<int> GetDiasLaboralesColaborador(int colaboradorId, int anio, int mes)
        {
            int diasLaborales = GetDiasLaborales(anio, mes);
            int diasProporcionales = await GetDiasProporcionales(colaboradorId, anio, mes);

            if (diasProporcionales > 0)
                diasLaborales = diasProporcionales;

            int diasLicencia = await GetDiasLicencia(colaboradorId, anio, mes);
            int diasFeriados = await GetDiasFeriados(anio, mes);
            return diasLaborales - (diasLicencia + diasFeriados);
        }

        public async Task<int> GetHoraRestanteParaCargarMes(int colaboradorId, int anio, int mes)
        {
            int cantHoras = 0;
            int totalHoras = await GetDiasLaboralesColaborador(colaboradorId, anio, mes) * 8;
            int totalHorasCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == colaboradorId).SumAsync(x => x.Horas);
            cantHoras = totalHoras - totalHorasCargadas;
            return cantHoras;
        }

        public async Task<string> GetStatusDeCarga(int colaboradorId, int anio, int mes)
        {
            int totalHoras = await GetDiasLaboralesColaborador(colaboradorId, anio, mes) * 8;
            int totalHorasCargadas = await _context.Asignacion.Where(x => x.Anio == anio && x.Mes == mes && x.ColaboradorId == colaboradorId).SumAsync(x => x.Horas);

            string status = "PENDIENTE";

            if (totalHoras > totalHorasCargadas && totalHorasCargadas > 0)
            {
                status = "PARCIAL";
            }
            else if (totalHoras > totalHorasCargadas && totalHorasCargadas == 0)
            {
                status = "PENDIENTE";
            }
            else if (totalHoras < totalHorasCargadas)
            {
                status = "FINALIZADA";
            }
            else if (totalHoras == totalHorasCargadas)
            {
                status = "FINALIZADA";
            }

            return status;
        }

        public async Task<int> GetHorasNormalesCargadas(int colaboradorId, int anio, int mes)
        {
            return await _context.Asignacion.Where(x => x.Mes == mes && x.Anio == anio && x.ColaboradorId == colaboradorId).SumAsync(x => x.Horas);
        }

        public async Task<int> GetHorasExtraCargadas(int colaboradorId, int anio, int mes)
        {
            return await _context.Asignacion.Where(x => x.Mes == mes && x.Anio == anio && x.ColaboradorId == colaboradorId && x.HorasExtra).SumAsync(x => x.Horas);
        }
    }
}


