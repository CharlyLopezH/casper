using AutoMapper;
using CasperAPI.DTOs;
using CasperAPI.Entidades;

namespace CasperAPI.Utilidades
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CrearEmpleadoDTO, Empleado>();
            CreateMap<Empleado,EmpleadoDTO>();
        }
    }
}
