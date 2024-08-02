using CasperAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CasperAPI.Repositorios
{
    public class RepositorioEmpleados(ApplicationDBContext context) : IRepositorioEmpleados
    {
        private readonly ApplicationDBContext context = context;

        public async Task<int> Crear(Empleado empleado)
        {
            context.Add(empleado);
            await context.SaveChangesAsync();
            return empleado.Id;
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {
            return await context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> ObtenerPorId(int id)
        {
            return await context.Empleados.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
