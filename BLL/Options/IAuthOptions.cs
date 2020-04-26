using Microsoft.IdentityModel.Tokens;

namespace BLL.Options
{
    public interface IAuthOptions
    {
        SymmetricSecurityKey symmetricSecurityKey { get; }
    }
}