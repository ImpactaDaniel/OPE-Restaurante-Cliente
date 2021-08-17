using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Domain.Usuarios.Modelos
{
    public class Cliente : Entidade<int>
    {
        public string Nome { get; private set; }
        public Telefone Telefone { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente()
        {
        }

        public Cliente(string nome, Telefone telefone, Endereco endereco)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public Cliente AtualizarNome(string nome)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            if (Nome != nome)
                Nome = nome;
            return this;
        }

        public Cliente AtualizarTelefone(Telefone telefone)
        {
            Telefone = telefone;
            return this;
        }

        public Cliente AtualizarTelefone(string ddd, string numero)
        {
            Telefone = new Telefone(ddd, numero);
            return this;
        }

        public Cliente AtualizarEndereco(Endereco endereco)
        {
            Endereco = endereco;
            return this;
        }
    }
}
