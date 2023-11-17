using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI;

public class AuthOptions
{
    public const string ISSUER = "ProductAPI"; // издатель токена
    public const string AUDIENCE = "Clients"; // потребитель токена
    const string KEY = "qwertyuiop[]1234567890";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new (Encoding.UTF8.GetBytes(KEY));
}