using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Modelos.Intefaces;
using System.Collections.Generic;

namespace Restaurante.Domain.Comum.Modelos.Intefaces
{
    public interface IClienteValidator : IValidator<Cliente>
    {
        bool ValidarEmail(string email, IList<string> erros);
        bool ValidarSenha(string senha, IList<string> erros);
    }
}
