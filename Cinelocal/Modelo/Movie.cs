using System;

namespace Cinelocal.Modelo
{
    public class Movie
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
}
