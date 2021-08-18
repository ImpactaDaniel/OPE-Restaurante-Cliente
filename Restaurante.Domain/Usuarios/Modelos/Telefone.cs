using Restaurante.Domain.Comum.Modelos;
using System;
using System.Linq;

namespace Restaurante.Domain.Usuarios.Modelos
{
    public class Telefone : Entidade<int>
    {
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        private Telefone()
        {
        }
        public Telefone(string ddd, string numero)
        {
            Validar(ddd, numero);
            DDD = ddd;
            Numero = numero;
        }

        public Telefone AtualizarDDD(string ddd)
        {
            ValidarDDD(ddd);
            DDD = ddd;
            return this;
        }

        public Telefone AtualizarNumero(string numero)
        {
            ValidarNumeroTelefone(numero);
            Numero = Numero;
            return this;
        }

        private void Validar(string ddd, string numero)
        {
            ValidarDDD(ddd);
            ValidarNumeroTelefone(numero);
        }

        private void ValidarNumeroTelefone(string numero)
        {
            ValidarStringNullOrEmpty(numero, "Número de telefone");
            if (numero.Length > 7 && numero.Length < 10 && numero.All(char.IsDigit))
                return;
            throw new ArgumentException("Número do telefone deve conter somente números e ter 8 ou 9 dígitos!");
        }


        private void ValidarDDD(string ddd)
        {
            ValidarStringNullOrEmpty(ddd, "DDD");
            if (ddd.Length == 2 && ddd.All(char.IsDigit))
                return;
            throw new ArgumentException("DDD deve conter somente números e conter somente 2 dígitos!");
        }

        public static bool operator ==(Telefone primeiro, Telefone segundo) => primeiro.Equals(segundo);

        public static bool operator !=(Telefone primeiro, Telefone segundo) => !primeiro.Equals(segundo);
        public override bool Equals(object obj)
        {
            var equals = base.Equals(obj);
            var other = obj as Telefone;
            return equals || Numero == other.Numero && DDD == other.DDD;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
