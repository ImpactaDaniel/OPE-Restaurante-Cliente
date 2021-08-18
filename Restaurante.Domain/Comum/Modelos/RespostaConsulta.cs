using System.Collections.Generic;

namespace Restaurante.Domain.Comum.Modelos
{
    public class RespostaConsulta<T>
    {
        public bool Sucesso { get; set; }
        public IEnumerable<string> Erros { get; }
        public T Resposta { get; }

        public RespostaConsulta(T resposta)
        {
            Resposta = resposta;
            Sucesso = true;
        }

        public RespostaConsulta(IEnumerable<string> erros)
        {
            Sucesso = false;
            Erros = erros;
        }
    }
}
