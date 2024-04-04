using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyProject.Utils
{
    
public class AuthOptions
{
    public const string ISSUER = "AuthenticationServer";
    public const string AUDIENCE = "AuthenticationClient";
    const string KEY = "my_beloved_keykeykey228228!!!belovedkey";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}
}