using Microsoft.EntityFrameworkCore;
using SMS.Asignaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Asignaciones.DataAccess
{
    public class AsignacionesDbContext : DbContext
    {
        //public AsignacionesDbContext(DbContextOptions<AsignacionesDbContext> options) : base(options)
        //{

        //}

        public AsignacionesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = SMSAsignaciones; Integrated Security = true");
        //    //optionsBuilder.UseSqlServer(@"Server=sbadesa017;Database=SMSAsignaciones;User Id = sadesa; Password=sadesa123");
        //    optionsBuilder.UseSqlServer(@"Server=.; Database=SMS_Asignaciones; Trusted_Connection=True"); // DBLOCAL-PC-CASA
        //    //comentar OnConfiguring  cuando  se configure en BASE del constructor
        //}

        public DbSet<Asignacion> Asignacion { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Feriado> Feriado { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<SubEquipo> SubEquipo { get; set; }
        public DbSet<Licencia> Licencia { get; set; }
        public DbSet<TipoLicencia> TipoLicencia { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<SubEquipoProyecto> SubEquipoProyecto { get; set; }
    }
}

/*
 NOTA

Una vez tenemos el contexto creado en nuestro proyecto, iremos a la «Consola del Administrador de paquetes», 
y ahí dispondremos de estos comandos:

add-migration {nombre} -Context {contexto}
remove-migration
update-database {nombre} -Context {contexto}
drop-database -Context {contexto}
 
*/
