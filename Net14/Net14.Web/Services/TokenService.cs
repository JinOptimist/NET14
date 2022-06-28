using Microsoft.IdentityModel.Tokens;
using Net14.Web.Auth;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Net14.Web.Services
{
    [AutoRegister]
    public class TokenService
    {
        SocialUserRepository _socialUserRepository;
        public TokenService(SocialUserRepository socialUserRepository) 
        {
            _socialUserRepository = socialUserRepository;
        } 

        public ClaimsIdentity GetIdentity(string email, string password)
        {
            UserSocial person = _socialUserRepository.GetByEmAndPass(email, password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("token", person.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    "Id");
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        public string GenerateAccessToken(ClaimsIdentity claims) 
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
