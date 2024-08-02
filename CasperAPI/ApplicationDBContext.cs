//using CasperAPI.Entidades;
using CasperAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CasperAPI
{
    public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
    {
        //Definición de tablas para la DB
        public DbSet<Empleado> Empleados { get; set; }
    }
}
