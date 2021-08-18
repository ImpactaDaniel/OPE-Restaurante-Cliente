using Restaurante.Application.Comum;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum
{
    public abstract class RequisicaoCliente<TRequisicao> : RequisicaoEntidade<int> 
        where TRequisicao : RequisicaoEntidade<int>
    {
        public RequisicaoCliente()
        {
        }
        public RequisicaoCliente(Cliente cliente)
        {
            Nome = cliente.Nome;
            Endereco = cliente.Endereco;
            Telefone = cliente.Telefone;
            Email = cliente.Email;
            Senha = cliente.Senha;
            Id = cliente.Id;
        }
        public string Nome { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
