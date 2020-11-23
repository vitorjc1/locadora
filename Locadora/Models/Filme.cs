using System.Collections.Generic;

namespace Locadora.Models
{
    public class Filme
    {
        public int FilmeId {get;set;}
        public string Nome {get;set;}
        public string Diretor {get;set;}
        public int Ano {get;set;}
        public ICollection<Cliente> Clientes {get;set;}
        public List<Aluguel> Alugueis{get;set;}
    }
}