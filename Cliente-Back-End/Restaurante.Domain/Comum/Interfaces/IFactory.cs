using Restaurante.Domain.Comum.Modelos.Intefaces;

namespace Restaurante.Domain.Comum
{
    public interface IFactory<out TEntidade> where TEntidade : IEntidade
    {
        TEntidade Build();
    }
}
