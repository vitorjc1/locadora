using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Models;
using Locadora.Models.ViewModels;
using Locadora.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
 {  
    public class AluguelRepo : IAluguelRepo
    {
        private readonly LocadoraContext _context;
        public AluguelRepo(LocadoraContext context)
        {
            _context = context;
        }
        public async Task<Aluguel> SalvarAluguel(AluguelViewModel aluguel)
        {
            var filme = await _context.Filmes.FindAsync(aluguel.FilmeId);
            var cliente = await _context.Clientes.FindAsync(aluguel.ClienteId);

            if(filme == null || cliente == null)
            {
                return null;
            }
 
            Aluguel NovoAluguel = new Aluguel();

            NovoAluguel.Filme = filme;
            NovoAluguel.Cliente = cliente;

            _context.Alugueis.Add(NovoAluguel);

            await _context.SaveChangesAsync();

            return NovoAluguel;
        }

        public async Task<List<AluguelDto>> GetAlugueis()
        {
            var alugueis = await _context.Alugueis.Include(f => f.Filme).Include(c => c.Cliente).ToListAsync();
            var listaAlugueis = new List<AluguelDto>();
            foreach(Aluguel aluguel in alugueis)
            {
                listaAlugueis.Add(new AluguelDto(aluguel));
            }

            return listaAlugueis;
        }

        public async Task<AluguelDto> GetAluguelById(int id)
        {
            var aluguel = await _context.Alugueis.Include(f => f.Filme).Include(c => c.Cliente).FirstOrDefaultAsync(x => x.AluguelId == id);
            if(aluguel == null)
            {
                return null; 
            }
            var novoAluguel = new AluguelDto(aluguel); 
            
            return novoAluguel;
        }

        public async Task<Aluguel> Atualizar(AluguelViewModel aluguel, int id)
        {
            var aluguelNovo = await _context.Alugueis.FindAsync(id);
            if(aluguelNovo == null)
            {
                return null;
            }
           aluguelNovo.ClienteId = aluguel.ClienteId;
           aluguelNovo.FilmeId = aluguel.FilmeId;

            _context.Alugueis.Update(aluguelNovo);
            await _context.SaveChangesAsync();

            return aluguelNovo;

        }

        public async Task<Aluguel> Deletar(AluguelViewModel aluguel)
        {
            var aluguelDeletado = await _context.Alugueis.FindAsync(aluguel.AluguelId);
            if(aluguelDeletado == null)
            {
                return null;
            }

            _context.Alugueis.Remove(aluguelDeletado);
            await _context.SaveChangesAsync();
            
            return aluguelDeletado;            
        }
    }
}