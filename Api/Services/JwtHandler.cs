using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services;

public class JwtHandler
{
    private readonly IConfiguration _config;
    private readonly IConfigurationSection _jwtSettings;

    public JwtHandler(IConfiguration config)
    {
        _config = config;
        _jwtSettings = _config.GetSection("JwtSettings");
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private List<Claim> GetClaims(AppUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };

        foreach (string role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) {
        JwtSecurityToken tokenOptions = new(
            issuer: _jwtSettings["validIssuer"],
            audience: _jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    public string CreateToken(AppUser user, IList<string> roles)
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        List<Claim> claims = GetClaims(user, roles);
        JwtSecurityToken tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
