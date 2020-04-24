using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BL.Options
{
    public class AuthOptions
    {
        public const string issuer = "Library"; // издатель токена

        public const string audience = "AuthClient"; // потребитель токена

        private const string key = "New_Key_For_TextLibrary_27_03_20_20_11_37_19_89";   // ключ для шифрации

        public const int lifeTime = 10000; // время жизни токена 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}
