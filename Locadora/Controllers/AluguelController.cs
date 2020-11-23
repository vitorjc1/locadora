using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;
using Locadora.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
    [ApiController]
    [Route("api/aluguel")]
    public class AluguelController:ControllerBase
    {
        private readonly IClientesRepo _ClienteContext;
        private readonly IFilmesRepo _FilmesContext;
        private readonly LocadoraContext _Locadora;
        private readonly IAluguelRepo _AluguelContext;

        public AluguelController(IClientesRepo ClienteContext, IFilmesRepo FilmeContext, LocadoraContext locadora, IAluguelRepo AluguelContext)
        {
            _ClienteContext = ClienteContext;
            _FilmesContext = FilmeContext;
            _Locadora = locadora;
            _AluguelContext = AluguelContext;
        }
 
        [HttpPost]
        public async Task<ActionResult<AluguelViewModel>> AlugarFilme(AluguelViewModel aluguelViewModel)
        {
            var novoAluguel = await _AluguelContext.SalvarAluguel(aluguelViewModel);
            return Ok(aluguelViewModel);    
        }

        [HttpGet("cliente/{cliId}")]
        public async Task<ActionResult<List<Filme>>> GetAlugueisCliente(int cliId)
        {
            var filmesAlugados = await _ClienteContext.Alugueis(cliId);
            
            if(filmesAlugados == null)
            {
                return NotFound(new Mensagem{mensagem = "Cliente inexistente."});
            }
            
            return Ok(filmesAlugados);
        } 

        [HttpGet]
        public async Task<ActionResult> GetAlugueis()
        {
           var alugueis = await _AluguelContext.GetAlugueis();
           return Ok(alugueis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AluguelDto>> GetAluguel(int id)
        {
            var aluguel = await _AluguelContext.GetAluguelById(id);

            if(aluguel == null)
            {
                return NotFound(new Mensagem{mensagem="Aluguel inexistente."});
            }

            return Ok(aluguel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AluguelDto>> Atualizar(AluguelViewModel aluguel, int id)
        {
            var novoAluguel = await _AluguelContext.Atualizar(aluguel, id);

            if(novoAluguel == null)
            {
                return NotFound(new Mensagem{mensagem="Aluguel inexistente."});
            }

            return Ok(novoAluguel);
        }
     
    }
}