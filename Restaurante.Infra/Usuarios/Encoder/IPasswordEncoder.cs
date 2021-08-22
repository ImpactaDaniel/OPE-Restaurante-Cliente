using Restaurante.Clientes.Infra.Usuarios.Encryptacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Usuarios.Encoder
{
    public interface IPasswordEncoder : IEncoder
    {
        bool VerficarSenha(string senha, string senhaEnconder);
    }
}
