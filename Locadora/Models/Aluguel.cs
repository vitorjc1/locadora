using Locadora.Models.ViewModels;

namespace Locadora.Models
{
    public class Aluguel
    {
        public int AluguelId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        
    }

}