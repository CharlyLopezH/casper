using AutoMapper;
using CasperAPI.DTOs;
using CasperAPI.Entidades;
using CasperAPI.Repositorios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace CasperAPI.Endpoints
{
    public static class EmpleadosEndpoints
    {
        public static RouteGroupBuilder MapEmpleados(this RouteGroupBuilder group)
        {
            group.MapPost("/", CrearEmpleado);
            group.MapGet("/", ObtenerEmpleados).CacheOutput(c=>c.Expire(TimeSpan.FromSeconds(30)).Tag("empleados-get"));
            group.MapGet("/empleados/{id:int}", ObtenerPorId);
            group.MapPut("/empleados/{id:int}",ActualizarEmpleado);
            group.MapDelete("/empleados/{id:int}", BorrarEmpleado);
            return group;
        }

 

        static async Task<Results<NoContent, NotFound>> ActualizarEmpleado(int id,
            CrearEmpleadoDTO crearEmpleadoDTO,
            IRepositorioEmpleados repositorio,
            IOutputCacheStore outputCacheStore, IMapper mapper)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return TypedResults.NotFound();
            }

            var genero = mapper.Map<Empleado>(crearEmpleadoDTO);
            genero.Id = id;

            await repositorio.Actualizar(genero);
            await outputCacheStore.EvictByTagAsync("generos-get", default);
            return TypedResults.NoContent();
        }

        static async Task<Ok<List<EmpleadoDTO>>> ObtenerEmpleados(IRepositorioEmpleados repositorio, IMapper mapper)
        {
            var empleados = await repositorio.ObtenerTodos();
            var empleadosDTO = mapper.Map<List<EmpleadoDTO>>(empleados);
            return TypedResults.Ok(empleadosDTO);
        }

        static async Task<Created<EmpleadoDTO>> CrearEmpleado(CrearEmpleadoDTO crearEmpleadoDTO,
            IRepositorioEmpleados repositorio, IOutputCacheStore outputCacheStore, IMapper mapper)
        {
            var empleado = mapper.Map<Empleado>(crearEmpleadoDTO);
            var id = await repositorio.Crear(empleado);
            await outputCacheStore.EvictByTagAsync("empleados-get", default);
            var empleadoDTO = mapper.Map<EmpleadoDTO>(empleado);
            return TypedResults.Created($"/empleados/{id}", empleadoDTO);
        }

        static async Task<Results<Ok<EmpleadoDTO>, NotFound>> ObtenerPorId(int id,
            IRepositorioEmpleados repositorio,IMapper mapper)
        {
            var empleado = await repositorio.ObtenerPorId(id);

            if (empleado is null)
            {
                return TypedResults.NotFound();
            }

            var empleadoDTO = mapper.Map<EmpleadoDTO>(empleado);
            return TypedResults.Ok(empleadoDTO);
        }

        static async Task<Results<NoContent,NotFound>> BorrarEmpleado(int id, IRepositorioEmpleados repositorio, IOutputCacheStore outputCacheStore)
        {
            var existe = await repositorio.Existe(id);  
            if (!existe)
            {
                return TypedResults.NotFound();
            }
            await repositorio.Borrar(id);
            await outputCacheStore.EvictByTagAsync("empleados-get", default);
            return TypedResults.NoContent();
        }
    }
}
