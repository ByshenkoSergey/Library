using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BL.DTOModels;

namespace API_Laer
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    
    public class AccountController : ControllerBase
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token(LoginUserDTO loginUser)
        {
            var token = await _service.GetTokenAsync(loginUser.Login, loginUser.Password);

            return new ObjectResult(token);
        }
    }


}