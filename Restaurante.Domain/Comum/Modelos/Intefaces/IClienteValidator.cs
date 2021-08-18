using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Modelos.Intefaces;

namespace Restaurante.Domain.Comum.Modelos.Intefaces
{
    public interface IClienteValidator : IValidator<Cliente>
    {
        Resposta ValidarEmail(string email);
        Resposta ValidarSenha(string senha);
    }
}
