using System.Collections.Generic;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;

namespace Locadora.Repository.Interfaces
{
    public interface IClientesRepo
    {
        Task<Cliente> GetClientesById(int id);
        IEnumerable<Cliente> GetClientes();
        Task SalvarCliente(Cliente cliente);  
        Task<IEnumerable<FilmeViewModel>> Alugueis(int cliId);
        Task<Cliente> AtualizarCliente(ClienteViewModel cliente);
        Task<Cliente> ExcluirCliente (int id);
    }
}