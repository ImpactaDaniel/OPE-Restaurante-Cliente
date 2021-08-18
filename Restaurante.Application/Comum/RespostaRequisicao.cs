using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Application.Comum
{
    public class RespostaRequisicao<T> : Resposta
    {
        public T Entidade { get; }
        public RespostaRequisicao(Resposta resposta, T entidade) : base(resposta.Sucesso, resposta.Erros)
        {
            Entidade = entidade;
        }
        public RespostaRequisicao(T entidade)
        {
            Entidade = entidade;
        }
    }
}
