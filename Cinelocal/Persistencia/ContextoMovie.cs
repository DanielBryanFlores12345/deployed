using Cinelocal.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cinelocal.Persistencia
{
    public class ContextoMovie: DbContext
    {
        public ContextoMovie(DbContextOptions<ContextoMovie> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}

