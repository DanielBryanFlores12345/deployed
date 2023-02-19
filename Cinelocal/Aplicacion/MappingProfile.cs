using AutoMapper;
using Cinelocal.Modelo;

namespace Cinelocal.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesDto>();
        }
    }
}