using Restaurante.Domain.Comum.Modelos;
using System;
using System.Linq;

namespace Restaurante.Domain.Usuarios.Modelos
{
    public class Endereco : Entidade<int>
    {
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        private Endereco()
        {
        }

        public Endereco(string cep, string logradouro, string bairro, string numero, string complemento)
        {
            Validar(cep, logradouro, bairro, numero);
            CEP = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
        }

        public Endereco(string cep)
        {
            CEP = cep;
        }

        public Endereco AtualizarCEP(string cep)
        {
            ValidarCEP(cep);
            CEP = cep;
            return this;
        }

        public Endereco AtualizarNumero(string numero)
        {
            if(Numero != numero)
                Numero = numero;
            return this;
        }

        public Endereco AtualizarComplemento(string complemento)
        {
            if(Complemento != complemento)
                Complemento = complemento;
            return this;
        }

        public Endereco AtualizarLogradouro(string logradouro)
        {
            if (Logradouro != logradouro)
                Logradouro = logradouro;
            return this;
        }

        public Endereco AtualizarBairro(string bairro)
        {
            if (Bairro != bairro)
                Bairro = bairro;
            return this;
        }

        private void Validar(string cep, string logradouro, string bairro, string numero)
        {
            ValidarStringNullOrEmpty(bairro, "Bairro");
            ValidarStringNullOrEmpty(numero, "Número");
            ValidarStringNullOrEmpty(logradouro, "Logradouro");
            ValidarCEP(cep);
        }
        private void ValidarCEP(string cep)
        {
            ValidarStringNullOrEmpty(cep, "CEP");
            if (!cep.All(char.IsDigit))
                throw new ArgumentException("CEP deve conter somente dígitos!");
            if (cep.Length != 8)
                throw new ArgumentException("CEP deve conter 8 dígitos!");
        }


        public static bool operator ==(Endereco primeiro, Endereco segundo) => primeiro.Equals(segundo);

        public static bool operator !=(Endereco primeiro, Endereco segundo) => !primeiro.Equals(segundo);
        public override bool Equals(object obj)
        {
            var equals = base.Equals(obj);
            var other = obj as Endereco;
            return equals || CEP == other.CEP && Numero == other.Numero && Complemento == other.Complemento;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
