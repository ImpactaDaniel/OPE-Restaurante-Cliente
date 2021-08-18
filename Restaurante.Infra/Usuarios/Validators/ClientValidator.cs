using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;

namespace Restaurante.Infra.Usuarios.Validators
{
    internal class ClientValidator : IClienteValidator
    {
        public Resposta Validar(Cliente entidade)
        {
            throw new System.NotImplementedException();
        }

        public Resposta ValidarEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Resposta ValidarSenha(string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}
