using AutoMapper;
using Cinelocal.Modelo;
using Cinelocal.Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cinelocal.Aplicacion
{
    public class ConsultarFiltro
    {
        public class MovieOne : IRequest<MoviesDto>
        {
            public string MovieInter { get; set; }
        }

        public class Manejador : IRequestHandler<MovieOne, MoviesDto>
        {
            private readonly ContextoMovie _context;
            public readonly IMapper _mapper;
            public Manejador(ContextoMovie context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<MoviesDto> Handle(MovieOne request, CancellationToken cancellationToken)
            {
                var movie = await _context.Movies.Where(p => p.MoviesInternacionalGuid == request.MovieInter).FirstOrDefaultAsync();

                if (movie == null)
                {
                    throw new Exception("No se encuentra la pelicula");
                }

                var movieDto = _mapper.Map<Movie, MoviesDto>(movie);
                return movieDto;
            }
        }
    }
}