using Cinelocal.Modelo;
using Cinelocal.Persistencia;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Cinelocal.Aplicacion
{
    public class Consulta
    {
        public class ListaMovies : IRequest<List<MoviesDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaMovies, List<MoviesDto>>
        {
            private readonly ContextoMovie _context;
            private readonly IMapper _mapper;
            public Manejador(ContextoMovie context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<MoviesDto>> Handle(ListaMovies request, CancellationToken cancellationToken)
            {
                var movies = await _context.Movies.ToListAsync();
                var moviesDto = _mapper.Map<List<Movie>, List<MoviesDto>>(movies);
                return moviesDto;
            }
        }
    }
}
