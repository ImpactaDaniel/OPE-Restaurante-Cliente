using Restaurante.Domain.Comum.Modelos;

namespace Restaurante.Domain.Usuarios.Modelos
{
    public class Cliente : Entidade<int>
    {
        public string Nome { get; private set; }
        public Telefone Telefone { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Endereco Endereco { get; private set; }
        public Cliente()
        {
        }

        public Cliente(string nome, string email, string senha, Telefone telefone, Endereco endereco)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            ValidarStringNullOrEmpty(email, "E-mail");
            ValidarStringNullOrEmpty(senha, "Senha");
            Email = email;
            Senha = senha;
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

        public Cliente AtualizarSenha(string senha)
        {
            ValidarStringNullOrEmpty(senha, "Senha");
            if (Senha != senha)
                Senha = senha;
            return this;
        }
    }
}
