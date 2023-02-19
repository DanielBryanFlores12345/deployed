using Cinelocal.Modelo;
using Cinelocal.Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;

namespace Cinelocal.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public int MovieId { get; set; }
            public string Nombre { get; set; }
            public string Region { get; set; }
            public string Idioma { get; set; }
            public string Duracion { get; set; }
            public string Poster { get; set; }
            public DateTime? FechaLanzamiento { get; set; }
            public string MoviesInternacionalGuid { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Nombre).NotEmpty();
                RuleFor(p => p.FechaLanzamiento).NotEmpty();
            }
        }
        public class Manejador: IRequestHandler <Ejecuta>
        {
            public readonly ContextoMovie _context;
            public Manejador(ContextoMovie context)
            {
                _context = context;
            }

            public async Task<Unit> Handle  (Ejecuta request, CancellationToken cancellationToken)
            {
                var movies = new Movie
                {
                    Nombre = request.Nombre,
                    Region = request.Region,
                    Idioma = request.Idioma,
                    Duracion = request.Duracion,
                    Poster = request.Poster,
                    FechaLanzamiento = request.FechaLanzamiento,
                    MoviesInternacionalGuid = Convert.ToString(Guid.NewGuid())
                };
                _context.Movies.Add(movies);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar la pelicula");
            }
        }
    }

}
