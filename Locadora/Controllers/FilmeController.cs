using System.Collections.Generic;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;
using Locadora.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [ApiController]
    [Route("api/filme")]
    public class FilmeController : ControllerBase
    {   
        private readonly IFilmesRepo _filmeContext;
        
        public FilmeController(IFilmesRepo filmeContext)
        {
            _filmeContext = filmeContext;
        } 

        [HttpGet]
        public ActionResult<List<Filme>> GetFilmes()
        {
            var filmes = _filmeContext.GetFilmes();
            if(filmes == null)
            {
                return NotFound(new Mensagem{mensagem="Não há filmes cadastrados."});
            }
            return Ok(filmes);            
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilmeId(int id)
        {
            var filme = await _filmeContext.GetFilmeById(id);
            if(filme == null)
            {
                return NotFound(new Mensagem{mensagem="Filme inexistente"});
            }
            return Ok(filme);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> CadastrarFilme(Filme filme)
        {
           await _filmeContext.SalvarFilme(filme);
           return Ok(filme);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FilmeViewModel>> Alterar(FilmeViewModel filme, int id)
        {
            var novoFilme = await _filmeContext.AtualizarFilme(filme, id);
            if(novoFilme == null)
            {
                return NotFound(new Mensagem{mensagem="Filme não cadastrado"});
            }
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Filme>> Excluir(int id)
        {
            var filme =  await _filmeContext.ExcluirFilme(id);
            if(filme == null)
            {
                return NotFound(new Mensagem{mensagem="Filme inexistente."});
            }

            return Ok(filme);
        }

    }
}