using System.Collections.Generic;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;

namespace Locadora.Repository.Interfaces
{
    public interface IAluguelRepo
    {
         Task<Aluguel> SalvarAluguel(AluguelViewModel aluguel);
         Task<List<AluguelDto>> GetAlugueis(); 
         Task<AluguelDto> GetAluguelById(int id);
         Task<Aluguel> Atualizar(AluguelViewModel aluguel, int id);
         Task<Aluguel> Deletar(AluguelViewModel aluguel);
    }
}