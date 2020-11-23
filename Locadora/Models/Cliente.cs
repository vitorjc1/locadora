using System.Collections.Generic;

namespace Locadora.Models
{
    public class Cliente 
    {
        public int ClienteId {get; set;}
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public ICollection<Filme> Filmes {get;set;} 
        public List<Aluguel> Alugueis {get;set;}
    }
}