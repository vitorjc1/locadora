using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;
using Locadora.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{   
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesRepo _context;
        private readonly LocadoraContext _DbContext;
        
        public ClienteController(IClientesRepo context, LocadoraContext DbContext)
        {
            _context = context;
            _DbContext = DbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cl = await _context.GetClientesById(id);
            if(cl == null)
            {
                return NotFound(new Mensagem{mensagem="Cliente inexistente."});
            }
            return Ok(cl);

        } 

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return Ok(_context.GetClientes());
        } 

        [HttpPost]
        public async Task<ActionResult<Cliente>> CadastrarCliente(Cliente cliente)
        {   
            await _context.SalvarCliente(cliente); 
            return Ok(cliente);            
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> Atualizar(ClienteViewModel cliente)
        {
            var novoCliente = await _context.AtualizarCliente(cliente);
            if(novoCliente == null)
            {
                return NotFound(new Mensagem{mensagem="Cliente inexistente."});
            }
            return Ok(novoCliente);            
        }
 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Excluir(int id)
        {
            var cli = await _context.ExcluirCliente(id);
            if(cli == null)
            {
                return NotFound(new Mensagem{mensagem = "Cliente inexistente."});
            }
            return Ok(cli);
        }
    }
}