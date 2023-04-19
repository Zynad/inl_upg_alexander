using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApp.Helpers;

public class TokenValidation
{
    private readonly IConfiguration _config;

    public TokenValidation(IConfiguration config)
    {
        _config = config;
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidIssuer = _config.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
            ValidateAudience = true,
            ValidAudience = _config.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
            ClockSkew = TimeSpan.FromSeconds(0),
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            return true;
        }
        catch (SecurityTokenValidationException)
        {
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
