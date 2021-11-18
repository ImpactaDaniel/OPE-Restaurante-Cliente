using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using System;

namespace Restaurante.Clientes.Infra.Usuarios.Encoder
{
    internal class SenhaEncoder : IPasswordEncoder
    {
        public string Decode(string decode)
        {
            throw new NotImplementedException();
        }

        public string Encode(string encode)
        {
            const int WorkFactor = 14;
            return BCrypt.Net.BCrypt.HashPassword(encode, WorkFactor);
        }

        public bool VerficarSenha(string senha, string senhaEnconder)
        {

            return BCrypt.Net.BCrypt.Verify(senha, senhaEnconder);
        }
    }
}
