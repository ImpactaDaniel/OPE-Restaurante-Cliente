using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Infra.Usuarios.Clientes;

namespace Restaurante.Infra.Comum.Persistencia
{
    public class RestauranteDbContext : DbContext,
        IRestauranteDbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }
    }
}
