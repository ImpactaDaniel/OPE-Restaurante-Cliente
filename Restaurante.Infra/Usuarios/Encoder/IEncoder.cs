using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Usuarios.Encryptacao
{
    public interface IEncoder
    {
        string Encode(string encode);
        string Decode(string decode);
    }

}
