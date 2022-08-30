using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SMS.Asignaciones.Cryptography;
using SMS.Asignaciones.DataAccess;
using SMS.Asignaciones.Frontend.Models;
using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AsignacionesDbContext _context;
        private readonly IWebHostEnvironment _host;

        public HomeController(ILogger<HomeController> logger, AsignacionesDbContext context, IWebHostEnvironment host)
        {
            _logger = logger;
            _context = context;
            _host = host;
        }      


        [Authorize]
        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            int anioActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            int diasFeriados = await _context.Feriado.Where(x => x.Fecha.Year == anioActual && x.Fecha.Month == mesActual).CountAsync();

            DateTime date = DateTime.Now;
            DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.Date.AddMonths(1).AddDays(-1);
            int diasLaborales = int.Parse((Helper.GetBusinessDays(oPrimerDiaDelMes, oUltimoDiaDelMes) - diasFeriados).ToString());

            model.Feriados = diasFeriados;
            model.DiasLaborales = int.Parse(diasLaborales.ToString());
            model.HorasMes = diasLaborales * 8;
            model.MesActual = Helper.GetNombreMes(DateTime.Now.Month);

            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Where(x => x.Id == id).FirstOrDefaultAsync();

            model.Rol = colaborador.Rol.Nombre;
            model.Equipo = colaborador.Equipo.Nombre;

            var miembros = await _context.Colaborador.ToListAsync();

            //if (colaborador.Lider)
            //{
            //    miembros = miembros.Where(x => x.EquipoId == colaborador.EquipoId).ToList();
            //}

            //if (!colaborador.Lider && colaborador.Rol.Nombre == "Colaborador")
            //{
            //    miembros = miembros.Where(x => x.Id == id).ToList();
            //}

            model.Colaboradores = miembros.Count;
            int pendientesDeCarga = model.Colaboradores * model.HorasMes;

            List<int> ids = miembros.Select(x => x.Id).ToList();

            int horasCargadas = await _context.Asignacion.Where(x => x.Mes == mesActual && x.Anio == anioActual && ids.Contains(x.ColaboradorId)).SumAsync(x => x.Horas);
            model.HorasPendientesCarga = pendientesDeCarga - horasCargadas;

            return View(model);
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> _ModificaDatos()
        {
            ModificaDatosViewModel model = new ModificaDatosViewModel();

            int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);
            var colaborador = await _context.Colaborador.Include(x => x.Equipo).Include(x => x.Rol).Where(x => x.Id == id).FirstOrDefaultAsync();

            model.ColaboradorId = id;
            model.FotoActual = colaborador.Foto;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificaDatos(int id, [Bind("ColaboradorId,NewPassword,ConfirmaNewPassword,FotoActual")] ModificaDatosViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //string avatar = Path.Combine(Path.Combine(_host.WebRootPath, "images"), "avatar.png");

                    //model.Foto = await System.IO.File.ReadAllBytesAsync(avatar);

                    bool valorEnUso = (model.NewPassword != model.ConfirmaNewPassword);

                    if (valorEnUso)
                    {
                        return Json(new { isValid = false, valorEnUso = true, html = Helper.RenderRazorViewToString(this, "_ModificaDatos", model) });
                    }

                    var colaborador = await _context.Colaborador.FindAsync(model.ColaboradorId);
                    colaborador.Password = HelperCryptography.EncryptPassword(model.NewPassword);
                    _context.Entry(colaborador).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                     throw; 
                }

                return Json(new { isValid = true });
            }


            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_ModificaDatos", model) });
        }


        public IActionResult Login()
        {
            //string pwd = HelperCryptography.EncryptPassword("Gonzoopera1942");

            //RESCUE: DATO INICIAL PARA PONER EN MARCHA LA APLICACION
            ////string avatar = Path.Combine(Path.Combine(_host.WebRootPath, "images"), "avatar.png");

            ////Colaborador model = new Colaborador();

            ////model.Foto =  System.IO.File.ReadAllBytes(avatar);
            ////model.Password = HelperCryptography.EncryptPassword("SMSsudamerica");
            ////model.Apellido = "Darretta";
            ////model.Email = "mdarretta@sms-sudamerica.com";
            ////model.EquipoId = 4;
            ////model.RolId = 5;
            ////model.Lider = true;
            ////model.Nombre = "Mariano Gabriel";
            ////model.ProveedorId = 1;

            ////_context.Add(model);
            ////_context.SaveChanges();
            LoginMessageViewModel model = new LoginMessageViewModel() { Mensaje = string.Empty };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string ReturnUrl)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                LoginMessageViewModel model = new LoginMessageViewModel();
                model.Mensaje = "Campos obligatorios!";
                return View(model);
            }

            var colaborador = await _context.Colaborador.Include(x => x.Rol).Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if(colaborador == null)
            {
                LoginMessageViewModel model = new LoginMessageViewModel();
                model.Mensaje = "No tiene acceso!";
                return View(model);
            }


            bool valido = HelperCryptography.CompareEncryptPassword(password, colaborador.Password) && colaborador.Rol.Nombre != "Sin acceso";

            if (valido)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, colaborador.Apellido + ", " + colaborador.Nombre),
                    new Claim(ClaimTypes.Email, colaborador.Email),
                    new Claim(ClaimTypes.Role, colaborador.Rol.Nombre),
                    new Claim("Id", colaborador.Id.ToString())
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, "login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Index" : ReturnUrl);
            }
            else
            {
                LoginMessageViewModel model = new LoginMessageViewModel();
                model.Mensaje = "Email y/o Password incorrectos!";
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
