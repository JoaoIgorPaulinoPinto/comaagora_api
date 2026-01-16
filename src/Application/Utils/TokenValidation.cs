using System.IdentityModel.Tokens.Jwt;

namespace Comaagora_API.Application.Utils;

public class TokenValidation
{
    public bool TokenExpirou(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        var expClaim = jwt.Claims.FirstOrDefault(c => c.Type == "exp");
        if (expClaim == null)
            return true; // sem exp = considera inválido

        var expUnix = long.Parse(expClaim.Value);
        var expDate = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;

        return DateTime.UtcNow > expDate;
    }
}

