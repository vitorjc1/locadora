using System.Collections.Generic;

namespace Locadora.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int ClienteId {get;set;}
        public string Nome {get;set;}
        public string Telefone {get;set;}

        public Cliente Atualizar (Cliente cliente)
        {
            cliente.Nome = Nome;
            cliente.Telefone = Telefone;

            return cliente;
        }
        
    }
}