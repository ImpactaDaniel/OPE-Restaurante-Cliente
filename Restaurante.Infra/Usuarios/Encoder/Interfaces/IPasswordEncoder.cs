namespace Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces
{
    public interface IPasswordEncoder : IEncoder
    {
        bool VerficarSenha(string senha, string senhaEnconder);
    }
}
