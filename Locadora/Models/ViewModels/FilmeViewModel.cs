namespace Locadora.Models.ViewModels
{
    public class FilmeViewModel
    {
        public int FilmeId {get; set;}
        public string Nome {get; set;}
        public string Diretor {get; set;}
        public int Ano {get; set;}

        public FilmeViewModel(){

        }
        public FilmeViewModel(Filme filme)
        {
            FilmeId = filme.FilmeId;
            Nome = filme.Nome;
            Diretor = filme.Diretor;
            Ano = filme.Ano;
        }

        public Filme Atualizar(Filme filme)
        {
            filme.Nome = Nome;
            filme.Diretor = Diretor;
            filme.Ano = Ano;

            return filme;
        }
    }
}