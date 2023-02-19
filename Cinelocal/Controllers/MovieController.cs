using Cinelocal.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinelocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MoviesDto>>> GetMovies()
        {
            return await _mediator.Send(new Consulta.ListaMovies());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesDto>> GetMovieInter(string id)
        {
            return await _mediator.Send(new ConsultarFiltro.MovieOne { MovieInter = id });
        }
    }
}