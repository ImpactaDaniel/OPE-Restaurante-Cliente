using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Infra.Comum.Persistencia;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public class ClienteRepositorio :
        RepositorioDados<IRestauranteDbContext, Cliente>,
        IClienteDomainRepositorio
    {
        public ClienteRepositorio(IRestauranteDbContext clientesRepositorio) : base(clientesRepositorio)
        {
        }

        public async Task<Cliente> Buscar(int id, CancellationToken cancellationToken = default) =>
            await All()
                .Include(c => c.Endereco)
                .Include(c => c.Telefone)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Endereco> BuscarEndereco(int id, CancellationToken cancellationToken = default) =>
            await Data
                .Enderecos
                .FirstOrDefaultAsync(e => e.Id == id);
        public async Task<Telefone> BuscarTelefone(int id, CancellationToken cancellationToken = default) =>
            await Data
                .Telefones
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<bool> Deletar(int id, CancellationToken cancellationToken = default)
        {
            var cliente = await Data.Clientes.FindAsync(id);

            if (cliente is null)
                return false;

            Data.Clientes.Remove(cliente);

            await Data.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
