using Apiteste.Controllers.Data;
using Apiteste.Controllers.Data.Dtos;
using Apiteste.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apiteste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeControler: ControllerBase
    {
        private FilmeContext _context;
        public FilmeControler(FilmeContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
                Diretor = filmeDto.Diretor,

            };
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new {Id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id) 
        {
           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
           if(filme != null)
           {
               ReadFilmeDto filmeDto = new ReadFilmeDto
               {
                   Titulo = filme.Titulo,
                   Genero = filme.Genero,
                   Duracao = filme.Duracao,
                   Diretor = filme.Diretor,
                   Id = filme.Id,
                   HoraDaConsulta = DateTime.Now
               };
               return Ok(filme);
           }
           return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
             if(filme != null)
           {
               return NotFound();
           }

           filme.Titulo = filmeDto.Titulo;
           filme.Genero = filmeDto.Genero;
           filme.Duracao = filmeDto.Duracao;
           filme.Diretor = filmeDto.Diretor;
           _context.SaveChanges();
           return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
             if(filme != null){
                 return NotFound();
             }
             _context.Remove(filme);
             _context.SaveChanges();
             return NoContent();
        }      
    }
}