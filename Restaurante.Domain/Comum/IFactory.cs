using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Domain.Comum
{
    public interface IFactory<out TEntidade> where TEntidade : IEntidade
    {
        TEntidade Build();
    }
}
