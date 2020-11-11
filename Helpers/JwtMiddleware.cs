using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Framework.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserRepo userRepo)
        {
            var token = context.Request.Headers["Authorization"]
                            .FirstOrDefault()?
                            .Split(" ")
                            .Last();

            if (token != null)
                attatchUserToContext(context, userRepo, token);
            await _next(context);
        }

        private void attatchUserToContext(HttpContext context, IUserRepo repo, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);

                context.Items["User"] = repo.GetById(userId);
            }
            catch
            {

            }
        }
    }
}