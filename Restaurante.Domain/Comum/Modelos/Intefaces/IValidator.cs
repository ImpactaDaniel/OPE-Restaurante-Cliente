using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Domain.Usuarios.Modelos.Intefaces
{
    public interface IValidator<T>
    {
        Resposta Validar(T entidade);
    }
}
