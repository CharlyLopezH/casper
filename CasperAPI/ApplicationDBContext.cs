//using CasperAPI.Entidades;
using CasperAPI.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CasperAPI
{
    public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
    {
        //Definición de tablas para la DB
        public DbSet<Empleado> Empleados { get; set; }


        //Configuración del Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Email)
                .IsUnique(); //Configura el indice unico para email
        
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Codigo)
                .IsUnique();  // Configura el índice único para Codigo

            modelBuilder.Entity<Empleado>()                
                .HasIndex(e => e.CURP)
                .IsUnique();  // Configura el índice único para Codigo                

            modelBuilder.Entity<Empleado>()
                .Property(e => e.CURP)
                .HasColumnType("varchar(19)")
                .HasMaxLength(19);  // Configura el tamaño de campo para CURP                                

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Email)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);  // Configura el tamaño de campo para email                                


            base.OnModelCreating(modelBuilder);
        }

    }

}
