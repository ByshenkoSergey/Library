using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BLL.Options
{
    public class AuthOptions : IAuthOptions
    {
        private readonly string _secretKey;

        public AuthOptions(string secretKey)
        {
            _secretKey = secretKey;
        }

        public const string issuer = "Library"; // издатель токена

        public const string audience = "AuthClient"; // потребитель токена

        public const int lifeTime = 10000; // время жизни токена 
        public SymmetricSecurityKey symmetricSecurityKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            }
        }

    }
}
