using Microsoft.AspNetCore.Mvc;
using SMS.Asignaciones.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Asignaciones.Frontend.ViewComponents
{
    [ViewComponent(Name = "Avatar")]
    public class AvatarViewComponent : ViewComponent
    {
        private readonly AsignacionesDbContext _context;

        public AvatarViewComponent(AsignacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            //int id = int.Parse(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(x => x.Type == "Id").FirstOrDefault().Value);

            //var colaborador = await _context.Colaborador.FindAsync(id);
            //ViewData["Foto"] = colaborador.Foto;

            return View("_ViewAvatar");
        }
    }
}
