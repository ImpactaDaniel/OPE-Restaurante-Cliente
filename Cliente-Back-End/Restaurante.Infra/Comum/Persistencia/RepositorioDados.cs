using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Comum.Persistencia
{
    public class RepositorioDados<TEntidade> : IDomainRepositorio<TEntidade>
        where TEntidade : class, IEntidade
    {

        public virtual async Task<RespostaConsulta<TEntidade>> Salvar(TEntidade entidade, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

        }

        protected RespostaConsulta<T> RetornaErro<T>(string erro)
        {
            throw new NotImplementedException();
        }
        public RespostaConsulta<TEntidade> Buscar(Func<TEntidade, bool> condicao)
        {
            throw new NotImplementedException();
        }
    }
}
