using System.IdentityModel.Tokens.Jwt;

namespace Comaagora_API.Application.Utils;

public class TokenValidation
{
    public bool TokenExpirou(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return true; // sem token = inválido/expirado

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var expClaim = jwt.Claims.FirstOrDefault(c => c.Type == "exp");
            if (expClaim == null)
                return true;

            if (!long.TryParse(expClaim.Value, out var expUnix))
                return true;    

            var expDate = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;
            return DateTime.UtcNow > expDate;
        }
        catch
        {
            return true; // token malformado = inválido
        }
    }

}

