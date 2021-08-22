namespace Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces
{
    public interface IEncoder
    {
        string Encode(string encode);
        string Decode(string decode);
    }

}
