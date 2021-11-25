using Microsoft.IdentityModel.Tokens;
using Restaurante.Clientes.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System;

namespace Restaurante.Clientes.Application.Comum
{
    internal class TokenService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        public TokenService(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }
        public OutToken GenerateToken(Cliente cliente)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_tokenConfiguration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {                    
                    new Claim(ClaimTypes.Name, cliente.Nome),
                    new Claim("id", cliente.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(_tokenConfiguration.ValidTime),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = handler.CreateToken(tokenDescriptor);

            var token = handler.WriteToken(securityToken);

            return new OutToken(token, securityToken.ValidFrom, securityToken.ValidTo);

        }
    }
}
