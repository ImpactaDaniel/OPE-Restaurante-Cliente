using Restaurante.Application.Comum;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum
{
    public abstract class RequisicaoCliente<TRequisicao> : RequisicaoEntidade<int> 
        where TRequisicao : RequisicaoEntidade<int>
    {
        public string Nome { get; set; }
        public TelefoneRequest Telefone { get; set; }
        public EnderecoRequest Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class TelefoneRequest
    {
        public string DDD { get; set; }
        public string Telefone { get; set; }
    }

    public class EnderecoRequest
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
