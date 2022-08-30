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
    [Authorize]
    public class HoraController : Controller
    {
        private readonly AsignacionesDbContext _context;

        public HoraController(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            List<ItemViewModel> anios = new List<ItemViewModel>();
            List<ItemViewModel> meses = new List<ItemViewModel>();

            var annos = await _context.Periodo.Where(x => x.Habilitado).ToListAsync();

            foreach(Periodo p in annos)
            {
                if (!anios.Where(x => x.Id == p.Anio).Any())
                    anios.Add(new ItemViewModel() { Id = p.Anio, Valor = p.Anio.ToString() });

                if (!meses.Where(x => x.Id == p.Mes).Any())
                    meses.Add(new ItemViewModel() { Id = p.Mes, Valor = Helper.GetNombreMes(p.Mes)});
            }

            if(anios.Count > 0)
            {
                ViewData["AnioActualId"] = new SelectList(anios, "Id", "Valor", anios.FirstOrDefault().Id);
                ViewData["MesActualId"] = new SelectList(meses, "Id", "Valor", meses.FirstOrDefault().Id );
            }

            CargaHabilitadaViewModel model = new CargaHabilitadaViewModel();
            model.Habilitada = (anios.Count > 0);

            return View(model);
        }

        [HttpPost]
        public async Task<List<ItemViewModel>> CargarMeses(int anio)
        {

            List<ItemViewModel> meses = new List<ItemViewModel>();

            var annos = await _context.Periodo.Where(x => x.Habilitado && x.Anio == anio).ToListAsync();

            foreach (Periodo p in annos)
            {
                if (!meses.Where(x => x.Id == p.Mes).Any())
                    meses.Add(new ItemViewModel() { Id = p.Mes, Valor = Helper.GetNombreMes(p.Mes) });
            }
            return meses;
        }

        public async Task<ActionResult> _ViewAll(int anio = 0, int mes = 0, int colaboradorId = 0)
        {
            List<HorasViewModel> model = new List<HorasViewModel>();

            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == id).FirstOrDefaultAsync();

            var miembros = await _context.Colaborador.Include(x => x.Proveedor).Include(x => x.Equipo).Include(x => x.SubEquipo)
                .Where(x => x.FechaBaja == null || (x.FechaBaja.Value.Year == anio &&
                    x.FechaBaja.Value.Month == mes && x.FechaBaja.Value.Day >= DateTime.Now.Day)).ToListAsync();

            if(colaboradorId > 0)
            {
                miembros = miembros.Where(x => x.Id == colaboradorId).ToList();
            }
            else
            {
                if (colaborador.Rol.Nombre == "Colaborador")
                {
                    miembros = miembros.Where(x => x.Id == colaborador.Id).ToList();
                }
                else if (colaborador.Rol.Nombre == "Líder" || colaborador.Rol.Nombre == "Operaciones" || colaborador.Rol.Nombre == "HRBP")
                {
                    var owner = miembros.Where(x => x.Id == colaborador.Id).ToList();
                    miembros = miembros.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                    miembros.AddRange(owner);
                }
            }

            Helper _helper = new Helper(_context);

            foreach (Colaborador recurso in miembros)
            {
                HorasViewModel hvm = new HorasViewModel();

                hvm.DiasLicencia = await _helper.GetDiasLicencia(recurso.Id, anio, mes);
                hvm.Anio = anio;
                hvm.Mes = mes;
                hvm.ColaboradorId = recurso.Id;
                hvm.Fecha = DateTime.Now.Date;
                hvm.Foto = recurso.Foto;
                hvm.HorasMes = await _helper.GetDiasLaboralesColaborador(recurso.Id, anio, mes) * 8;
                hvm.NombreColaborador = recurso.Apellido + ", " + recurso.Nombre;
                hvm.TipoRegistro = recurso.Proveedor.Nombre;
                hvm.HorasCargadas = await _helper.GetHorasNormalesCargadas(recurso.Id, anio, mes);
                hvm.HorasExtra = await _helper.GetHorasExtraCargadas(recurso.Id, anio, mes);
                hvm.Equipo = recurso.Equipo.Nombre;
                hvm.SubEquipo = (recurso.SubEquipoId.HasValue) ? recurso.SubEquipo.Nombre : string.Empty;
                hvm.Legajo = (!string.IsNullOrEmpty(recurso.Legajo)) ? recurso.Legajo : "?-????";
                hvm.ColaboradorIdSeleccionado = colaboradorId;
                hvm.HorasVariables = recurso.HorasVariables;

                if (hvm.HorasCargadas > 0)
                {
                    hvm.Asignaciones.Clear();
                    var asignaciones = await _context.Asignacion.Include(x => x.Proyecto).Where(x => x.Mes == mes && x.Anio == anio && x.ColaboradorId == recurso.Id).ToListAsync();

                    foreach(Asignacion asignadas in asignaciones)
                    {
                        HorasAsignadas ha = new HorasAsignadas();

                        ha.AsignacionId = asignadas.Id;
                        ha.ProyectoId = asignadas.ProyectoId;
                        ha.ProyectoNombre = asignadas.Proyecto.Nombre;
                        ha.Horas = asignadas.Horas;
                        ha.ColaboradorIdSeleccionado = colaboradorId;

                        hvm.Asignaciones.Add(ha);
                    }
                }

                model.Add(hvm);
            }

            return PartialView("_ViewAll", model.OrderBy(x => x.NombreColaborador));
        }

        public async Task<IActionResult> _CargaHoras(int colaboradorId, int anio, int mes, int colaboradorIdSeleccionado)
        {
            HorasAsignadas model = new HorasAsignadas();
            model.ColaboradorId = colaboradorId;
            model.Horas = 0;
            model.Anio = anio;
            model.Mes = mes;
            model.HorasExtra = false;
            model.AsignacionId = 0;
            model.ColaboradorIdSeleccionado = colaboradorIdSeleccionado;

            //Que proyectos puede ver?
            Colaborador col = await _context.Colaborador.Where(x => x.Id == colaboradorId)
                .Include(x => x.Rol).Include(x => x.Proveedor).Include(x => x.Equipo).Include(x => x.SubEquipo).FirstOrDefaultAsync();

            List<int> ListSubEquiposId = new List<int>();
            List<int> ListProyectosId = new List<int>();

            if (col.SubEquipoId.HasValue)
            {
                ListSubEquiposId = await _context.SubEquipo.Where(x => x.Id == col.SubEquipoId.Value).Select(x => x.Id).ToListAsync();
                ListProyectosId = await _context.SubEquipoProyecto.Where(x => ListSubEquiposId.Contains(x.SubEquipoId) && x.Habilitado).Select(x => x.ProyectoId).ToListAsync();
                ViewData["ProyectoId"] = new SelectList(await _context.Proyecto.Where(x => ListProyectosId.Contains(x.Id)).ToListAsync(), "Id", "Nombre", model.ProyectoId);
            }
            else
            {
                ViewData["ProyectoId"] = new SelectList(await _context.Proyecto.ToListAsync(), "Id", "Nombre", model.ProyectoId);
            }

            return View(model);            
        }

        public async Task<IActionResult> _VerCarga(int colaboradorId, int anio, int mes, int colaboradorIdSeleccionado)
        {
            List<HorasAsignadas> model = new List<HorasAsignadas>();

            var asignaciones = _context.Asignacion.Include(x => x.Proyecto)
                .Where(x => x.ColaboradorId == colaboradorId && x.Anio == anio && x.Mes == mes)
                .ToList();

            foreach (Asignacion registro in asignaciones)
            {
                HorasAsignadas ha = new HorasAsignadas();
                ha.AsignacionId = registro.Id;
                ha.Anio = registro.Anio;
                ha.ColaboradorId = registro.ColaboradorId;
                ha.Horas = registro.Horas;
                ha.ProyectoId = registro.ProyectoId;
                ha.ProyectoNombre = registro.Proyecto.Nombre;
                ha.HorasExtra = registro.HorasExtra;
                ha.Mes = registro.Mes;
                ha.ColaboradorIdSeleccionado = colaboradorIdSeleccionado;

                model.Add(ha);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cargar(int id, [Bind("ColaboradorId,ProyectoId,Horas,ProyectoNombre,Anio,Mes,HorasExtra,AsignacionId,ColaboradorIdSeleccionado")] HorasAsignadas model)
        {
            if (ModelState.IsValid)
            {
                bool valorEnUso = model.Horas <= 0;

                if (valorEnUso)
                {
                    ViewData["ProyectoId"] = new SelectList(await _context.Proyecto.ToListAsync(), "Id", "Nombre", model.ProyectoId);
                    return Json(new { isValid = false, valorEnUso = true, html = Helper.RenderRazorViewToString(this, "_CargaHoras", model) });
                }

                Asignacion registro = new Asignacion();
                registro.Horas = model.Horas;
                registro.Anio = model.Anio;
                registro.Mes = model.Mes;
                registro.ProyectoId = model.ProyectoId;
                registro.ColaboradorId = model.ColaboradorId;
                registro.Fecha = DateTime.Today;
                registro.HorasExtra = model.HorasExtra;

                await _context.AddAsync(registro);
                await _context.SaveChangesAsync();

                List<HorasViewModel> modelo = new List<HorasViewModel>();

                int idusuario = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
                var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == idusuario).FirstOrDefaultAsync();

                //var miembros = await _context.Colaborador.Include(x => x.Proveedor).Include(x => x.Equipo).Include(x => x.SubEquipo).ToListAsync();

                var miembros = await _context.Colaborador.Include(x => x.Proveedor).Include(x => x.Equipo).Include(x => x.SubEquipo)
                    .Where(x => x.FechaBaja == null || (x.FechaBaja.Value.Year == model.Anio &&
                        x.FechaBaja.Value.Month == model.Mes && x.FechaBaja.Value.Day >= DateTime.Now.Day)).ToListAsync();

                if (model.ColaboradorIdSeleccionado.Value > 0)
                {
                    miembros = miembros.Where(x => x.Id == model.ColaboradorIdSeleccionado.Value).ToList();
                }
                else
                {
                    if (colaborador.Rol.Nombre == "Colaborador")
                    {
                        miembros = miembros.Where(x => x.Id == colaborador.Id).ToList();
                    }
                    else if (colaborador.Rol.Nombre == "Líder" || colaborador.Rol.Nombre == "Operaciones" || colaborador.Rol.Nombre == "HRBP")
                    {
                        var owner = miembros.Where(x => x.Id == colaborador.Id).ToList();
                        miembros = miembros.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
                        miembros.AddRange(owner);
                    }
                }


                Helper _helper = new Helper(_context);

                foreach (Colaborador recurso in miembros)
                {
                    HorasViewModel hvm = new HorasViewModel();

                    hvm.DiasLicencia = await _helper.GetDiasLicencia(recurso.Id, model.Anio, model.Mes);
                    hvm.Anio = model.Anio;
                    hvm.Mes = model.Mes;
                    hvm.ColaboradorId = recurso.Id;
                    hvm.Fecha = DateTime.Now.Date;
                    hvm.Foto = recurso.Foto;
                    hvm.HorasMes = await _helper.GetDiasLaboralesColaborador(recurso.Id, model.Anio, model.Mes) * 8;
                    hvm.NombreColaborador = recurso.Apellido + ", " + recurso.Nombre;
                    hvm.TipoRegistro = recurso.Proveedor.Nombre;
                    hvm.HorasCargadas = await _helper.GetHorasNormalesCargadas(recurso.Id, model.Anio, model.Mes);
                    hvm.HorasExtra = await _helper.GetHorasExtraCargadas(recurso.Id, model.Anio, model.Mes);
                    hvm.Equipo = recurso.Equipo.Nombre;
                    hvm.SubEquipo = (recurso.SubEquipoId.HasValue) ? recurso.SubEquipo.Nombre : string.Empty;
                    hvm.Legajo = recurso.Legajo;
                    hvm.ColaboradorIdSeleccionado = model.ColaboradorIdSeleccionado;

                    if (hvm.HorasCargadas > 0)
                    {
                        hvm.Asignaciones.Clear();
                        var asignaciones = await _context.Asignacion.Include(x => x.Proyecto).Where(x => x.Mes == model.Mes && x.Anio == model.Anio && x.ColaboradorId == recurso.Id).ToListAsync();

                        foreach (Asignacion asignadas in asignaciones)
                        {
                            HorasAsignadas ha = new HorasAsignadas();

                            ha.AsignacionId = asignadas.Id;
                            ha.ProyectoId = asignadas.ProyectoId;
                            ha.ProyectoNombre = asignadas.Proyecto.Nombre;
                            ha.Horas = asignadas.Horas;
                            ha.ColaboradorIdSeleccionado = model.ColaboradorIdSeleccionado;

                            hvm.Asignaciones.Add(ha);
                        }
                    }

                    modelo.Add(hvm);
                }



                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", modelo.OrderBy(x => x.NombreColaborador )) });
            }

            ViewData["ProyectoId"] = new SelectList(await _context.Proyecto.ToListAsync(), "Id", "Nombre", model.ProyectoId);

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CargaHoras", new { colaboradorId = model.ColaboradorId, anio = model.Anio, mes = model.Mes }) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelo = await _context.Asignacion.FindAsync(id);
            var colaboradorId = modelo.ColaboradorId;
            var anio = modelo.Anio;
            var mes = modelo.Mes;

            _context.Asignacion.Remove(modelo);
            await _context.SaveChangesAsync();

            List<HorasAsignadas> model = new List<HorasAsignadas>();

            var asignaciones = _context.Asignacion.Include(x => x.Proyecto)
                .Where(x => x.ColaboradorId == colaboradorId && x.Anio == anio && x.Mes == mes)
                .ToList();

            foreach (Asignacion registro in asignaciones)
            {
                if (!model.Where(x => x.ProyectoId == registro.ProyectoId && !x.HorasExtra).Any())
                {

                    HorasAsignadas ha = new HorasAsignadas();
                    ha.Anio = registro.Anio;
                    ha.Mes = registro.Mes;
                    ha.ColaboradorId = registro.ColaboradorId;
                    ha.Horas = registro.Horas;
                    ha.ProyectoId = registro.ProyectoId;
                    ha.ProyectoNombre = registro.Proyecto.Nombre;
                    ha.HorasExtra = registro.HorasExtra;
                    ha.AsignacionId = registro.Id;

                    model.Add(ha);
                }
                else
                {
                    if (!registro.HorasExtra)
                    {
                        var hae = model.Where(x => x.ProyectoId == registro.ProyectoId).FirstOrDefault();
                        hae.Horas += registro.Horas;
                    }
                    else
                    {
                        if (!model.Where(x => x.ProyectoId == registro.ProyectoId && x.HorasExtra == registro.HorasExtra).Any())
                        {
                            HorasAsignadas ha = new HorasAsignadas();
                            ha.Anio = registro.Anio;
                            ha.Mes = registro.Mes;
                            ha.ColaboradorId = registro.ColaboradorId;
                            ha.Horas = registro.Horas;
                            ha.ProyectoId = registro.ProyectoId;
                            ha.ProyectoNombre = registro.Proyecto.Nombre;
                            ha.HorasExtra = registro.HorasExtra;
                            ha.AsignacionId = registro.Id;

                            model.Add(ha);
                        }
                        else
                        {
                            var hae = model.Where(x => x.ProyectoId == registro.ProyectoId && x.HorasExtra == registro.HorasExtra).FirstOrDefault();
                            hae.Horas += registro.Horas;
                        }

                    }
                }
            }

            return Json(new { html = Helper.RenderRazorViewToString(this, "_VerCarga", model) });
        }

        [HttpPost]
        public async Task<JsonResult> SearchColaborador(string Prefix, int Anio, int Mes)
        {
            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Include(x => x.SubEquipo).Where(x => x.Id == id).FirstOrDefaultAsync();

            var colaboradores = await _context.Colaborador
                    .Where(x => x.Nombre.StartsWith(Prefix) || x.Apellido.StartsWith(Prefix))
                .Select(x => new ColaboradorSuggesterViewModel()
                {
                    Id = x.Id,
                    FechaBaja = x.FechaBaja,
                    LiderColaboradorId = x.LiderColaboradorId,
                    Legajo = x.Legajo,
                    Nombre = x.Apellido.ToUpper() + ", " + x.Nombre + " (Legajo: " + x.Legajo + ")"
                }).Take(5).ToListAsync();

            if (colaborador.Rol.Nombre == "Colaborador")
            {
                colaboradores = colaboradores.Where(x => x.Id == colaborador.Id).ToList();
            }
            else if (colaborador.Rol.Nombre == "Líder")
            {
                colaboradores = colaboradores.Where(x => x.LiderColaboradorId == colaborador.Id).ToList();
            }

            colaboradores = colaboradores.Where(x => x.FechaBaja == null || (x.FechaBaja.Value.Year == Anio &&
                    x.FechaBaja.Value.Month == Mes && x.FechaBaja.Value.Day >= DateTime.Now.Day)).ToList();

            return Json(colaboradores);
        }

    }
}
