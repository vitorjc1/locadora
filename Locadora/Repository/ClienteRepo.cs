using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;
using Locadora.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class ClienteRepo : IClientesRepo
    {

        private readonly LocadoraContext _context;

        public ClienteRepo(LocadoraContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public async Task<Cliente> GetClientesById(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task SalvarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmeViewModel>> Alugueis(int cliId)
        {
            var cliente = await _context.Clientes.Include(f => f.Filmes).FirstOrDefaultAsync(c => c.ClienteId == cliId);
            if(cliente == null)
            {
                return null;
            }
            var filmeViewModelList = cliente.Filmes.Select(s => new FilmeViewModel(s));
            
            return filmeViewModelList;
        }

        public async Task<Cliente> AtualizarCliente (ClienteViewModel cliente)
        {
            var novoCliente = await _context.Clientes.FindAsync(cliente.ClienteId);
            if(novoCliente == null)
            {
                return null;
            }
            novoCliente = cliente.Atualizar(novoCliente);
            
            await _context.SaveChangesAsync();

            return novoCliente;
        }
 
        public async Task<Cliente> ExcluirCliente (int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(f => f.ClienteId == id);
            if(cliente == null)
            {
                return null;
            }
            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return cliente;
        }
    }
}
