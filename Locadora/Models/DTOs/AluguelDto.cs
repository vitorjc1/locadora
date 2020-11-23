using System.Collections.Generic;

namespace Locadora.Models
{
    public class AluguelDto
    {
        public int AluguelId {get;set;}
        public int ClienteId {get;set;}
        public string Cliente {get;set;}
        public int FilmeId {get;set;}
        public string Filme {get;set;}

        public AluguelDto (Aluguel aluguel)
        {
            AluguelId = aluguel.AluguelId;
            ClienteId = aluguel.Cliente.ClienteId;
            Cliente = aluguel.Cliente.Nome;
            FilmeId = aluguel.Filme.FilmeId;
            Filme = aluguel.Filme.Nome;
        }
    }
}