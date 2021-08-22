using Restaurante.Domain.Comum.Modelos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Domain.Usuarios.Repositorios
{
    public interface IDomainRepositorio<TEntidade> where TEntidade : IEntidade
    {
        Task<RespostaConsulta<TEntidade>> Salvar(TEntidade entidade, CancellationToken cancellationToken = default);
        RespostaConsulta<TEntidade> Buscar(Func<TEntidade, bool> condicao);
    }
}
