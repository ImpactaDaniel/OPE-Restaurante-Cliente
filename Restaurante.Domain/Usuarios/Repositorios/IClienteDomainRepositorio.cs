using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Usuarios.Modelos;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Domain.Usuarios.Repositorios
{
    public interface IClienteDomainRepositorio : IDomainRepositorio<Cliente>
    {
        Task<RespostaConsulta<Cliente>> Logar(string email, string password, CancellationToken cancellationToken = default);
        Task<RespostaConsulta<Cliente>> Buscar(int id, CancellationToken cancellationToken = default);
        Task<RespostaConsulta<Endereco>> BuscarEndereco(int id, CancellationToken cancellationToken = default);
        Task<bool> Deletar(int id, CancellationToken cancellationToken = default);
        Task<RespostaConsulta<Telefone>> BuscarTelefone(int id, CancellationToken cancellationToken = default);
    }
}
