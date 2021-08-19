using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Comum.Persistencia
{
    public class RepositorioDados<TDbContext, TEntidade> : IDomainRepositorio<TEntidade>
        where TEntidade : class, IEntidade
        where TDbContext : IDbContext
    {
        protected RepositorioDados(TDbContext db) => Data = db;
        protected TDbContext Data { get; }

        protected IQueryable<TEntidade> All() => Data.Set<TEntidade>();

        public virtual async Task<RespostaConsulta<TEntidade>> Salvar(TEntidade entidade, CancellationToken cancellationToken = default)
        {
            try
            {
                Data.Update(entidade);
                await Data.SaveChangesAsync(cancellationToken);
                return new RespostaConsulta<TEntidade>(entidade);
            }
            catch(Exception e)
            {
                return RetornaErro<TEntidade>(e.Message);
            }
            
        }

        protected RespostaConsulta<T> RetornaErro<T>(string erro)
        {
            var erros = new List<string>(1)
            {
                erro
            };
            return new RespostaConsulta<T>(erros);
        }
        public async Task<RespostaConsulta<TEntidade>> Buscar(Func<TEntidade, bool> condicao, CancellationToken cancellationToken = default)
        {
            var entidade = All().FirstOrDefault(condicao);
            if (entidade is null)
                return RetornaErro<TEntidade>($"{nameof(TEntidade)} não encontrada!");

            return new RespostaConsulta<TEntidade>(entidade);
        }
    }
}
