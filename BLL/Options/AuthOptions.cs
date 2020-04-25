using BLL.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BL.Options
{
    public class AuthOptions : IAuthOptions
    {
        private readonly AppSettings _appSettings;


        public AuthOptions(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public const string issuer = "Library"; // издатель токена

        public const string audience = "AuthClient"; // потребитель токена

        public const int lifeTime = 10000; // время жизни токена 
        public SymmetricSecurityKey symmetricSecurityKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            }
        }

    }
}
