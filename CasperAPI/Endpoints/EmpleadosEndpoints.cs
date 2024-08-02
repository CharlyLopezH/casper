using AutoMapper;
using CasperAPI.DTOs;
using CasperAPI.Entidades;
using CasperAPI.Repositorios;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CasperAPI.Endpoints
{
    public static class EmpleadosEndpoints
    {
        public static RouteGroupBuilder MapEmpleados(this RouteGroupBuilder group)
        {
            group.MapPut("/", CrearEmpleado);
            group.MapGet("/", ObtenerEmpleados);
            group.MapGet("/{id:int}", ObtenerPorId);
            return group;
        }

        static async Task<Ok<List<EmpleadoDTO>>> ObtenerEmpleados(IRepositorioEmpleados repositorio, IMapper mapper)
        {
            var empleados = await repositorio.ObtenerTodos();
            var empleadosDTO = mapper.Map<List<EmpleadoDTO>>(empleados);
            return TypedResults.Ok(empleadosDTO);
        }

        static async Task<Created<CrearEmpleadoDTO>> CrearEmpleado(CrearEmpleadoDTO crearEmpleadoDTO, 
            IRepositorioEmpleados repositorio, IMapper mapper)
        {
            var empleado = mapper.Map<Empleado>(crearEmpleadoDTO); 
            var id = await repositorio.Crear(empleado);


            var empleadoDTO = mapper.Map<CrearEmpleadoDTO>(empleado);
            return TypedResults.Created($"/empleados/{id}", empleadoDTO);
        }

        static async Task<Results<Ok<Empleado>, NotFound>> ObtenerPorId(int id,
            IRepositorioEmpleados repositorio)
        {
            var empleado = await repositorio.ObtenerPorId(id);

            if (empleado is null)
            {
                return TypedResults.NotFound();
            }

            //var empleado = mapper.Map<ActorDTO>(actor);
            return TypedResults.Ok(empleado);
        }
    }
}
