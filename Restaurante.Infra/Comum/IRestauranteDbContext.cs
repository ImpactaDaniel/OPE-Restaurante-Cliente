using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Infra.Comum.Persistencia;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public interface IRestauranteDbContext : IDbContext
    {
        DbSet<Cliente> Clientes { get; }
        DbSet<Endereco> Enderecos { get; }        
        DbSet<Telefone> Telefones { get; }
    }
}
