using AutoMapper;
using Sala_Reuniao_API.DTOs.Usuarios;
using Sala_Reuniao_API.Models;

namespace Sala_Reuniao_API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Usuario -> UsuarioReadDTO
            CreateMap<Usuario, UsuarioReadDTO>();

            // UsuarioCreateDTO -> Usuario
            CreateMap<UsuarioCreateDTO, Usuario>();

            //UsuarioUpdateDTO -> Usuario
            CreateMap<UsuarioUpdateDTO, Usuario>();

            //Usario -> UsuarioUpdateDTO (caso precise retornar info em updates)
            CreateMap<Usuario, UsuarioUpdateDTO>();
        }
    }
}
