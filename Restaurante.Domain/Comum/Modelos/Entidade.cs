using System;

namespace Restaurante.Domain.Comum.Modelos
{
    public abstract class Entidade<TId> : IEntidade
    {
        public TId Id { get; private set; } = default;

        protected void ValidarStringNullOrEmpty(string valor, string nomeArgumento)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentException($"{nomeArgumento} precisa ter um valor!");
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Entidade<TId> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            if (Id.Equals(default) || other.Id.Equals(default))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entidade<TId> primeiro, Entidade<TId> segundo)
        {
            if (primeiro is null && segundo is null)
            {
                return true;
            }

            if (primeiro is null || segundo is null)
            {
                return false;
            }

            return primeiro.Equals(segundo);
        }

        public static bool operator !=(Entidade<TId> primeiro, Entidade<TId> segundo) => !(primeiro == segundo);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}
