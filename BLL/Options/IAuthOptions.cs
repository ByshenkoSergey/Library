using Microsoft.IdentityModel.Tokens;

namespace BL.Options
{
    public interface IAuthOptions
    {
        SymmetricSecurityKey symmetricSecurityKey { get; }
    }
}