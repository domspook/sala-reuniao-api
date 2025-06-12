using AutoMapper;
using Sala_Reuniao_API.DTOs.Reservas;
using Sala_Reuniao_API.DTOs.Salas;
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

            //Sala -> SalaReadDTO
            CreateMap<Sala, SalaReadDTO>();

            //SalaCreateDTO -> Sala
            CreateMap<SalaCreateDTO, Sala>();

            //SalaUpdateDTO -> Sala
            CreateMap<SalaUpdateDTO, Sala>();

            //ReservaCreateDTO -> Reserva
            CreateMap<ReservaCreateDTO, Reserva>();

            //Reserva -> ReservaReadDTO
            CreateMap<Reserva, ReservaReadDTO>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Sala, opt => opt.MapFrom(opt => opt.Sala.Nome));
        }
    }
}