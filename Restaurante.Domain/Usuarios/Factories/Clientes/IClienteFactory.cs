using Restaurante.Domain.Comum;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Domain.Usuarios.Factories.Clientes
{
    public interface IClienteFactory : IFactory<Cliente>
    {
        IClienteFactory ComTelefone(string ddd, string numero);
        IClienteFactory ComTelefone(Telefone telefone);
        IClienteFactory ComEndereco(Endereco endereco);
        IClienteFactory ComNome(string nome);
        IClienteFactory ComSenha(string senha);
        IClienteFactory ComEmail(string email);
    }
}
