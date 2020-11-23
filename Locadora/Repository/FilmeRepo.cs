using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;

namespace Locadora.Repository.Interfaces
{
    public class FilmeRepo : IFilmesRepo
    {
        private readonly LocadoraContext _context;

        public FilmeRepo(LocadoraContext context)
        {
            _context = context;
        }

        public async Task<FilmeViewModel> AtualizarFilme(FilmeViewModel filme, int id)
        {   
            var novoFilme = await _context.Filmes.FindAsync(id);
            if(novoFilme == null)
            {
                return null;
            }
            novoFilme = filme.Atualizar(novoFilme);
            
            await _context.SaveChangesAsync();

            return filme;            
        }

        public async Task<Filme> GetFilmeById(int id)
        {
            var film = await _context.Filmes.FindAsync(id);

            return film;
        }

        public List<FilmeViewModel> GetFilmes()
        {
           var filmes = _context.Filmes.ToList();
           var listaFilmes = new List<FilmeViewModel>();
           foreach(Filme filme in filmes)
           {
               listaFilmes.Add(new FilmeViewModel(filme));
           }
           return listaFilmes;
        }

        public async Task SalvarFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<Filme> ExcluirFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if(filme == null)
            {
                return null;
            }
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

    }
}