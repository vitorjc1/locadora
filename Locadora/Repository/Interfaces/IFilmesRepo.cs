using System.Collections.Generic;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;

namespace Locadora.Repository.Interfaces
{
    public interface IFilmesRepo 
    {
        Task<Filme> GetFilmeById(int id);
        List<FilmeViewModel> GetFilmes();
        Task SalvarFilme (Filme filme);
        Task<FilmeViewModel> AtualizarFilme(FilmeViewModel filme, int id);
        Task<Filme> ExcluirFilme(int id);
    }
}