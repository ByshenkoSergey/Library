using System;
using System.Threading.Tasks;
using BLL.DTOModels;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{

    /// <summary>
    /// Сlass for working with users role
    /// </summary>
    [Authorize(Roles = "Admin")]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleServices;
        private readonly ILogger<UserRoleController> _logger;


        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="userRoleServices"></param>
        /// <param name="logger"></param>
        public UserRoleController(IUserRoleService userRoleServices, ILogger<UserRoleController> logger)
        {
            _userRoleServices = userRoleServices;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }


        /// <summary>
        /// Receiving the all users role/ protected / role for access - Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("gets")]
        public async Task<IActionResult> GetAllUserRoleAsync()
        {
            try
            {
                var userRoles = await _userRoleServices.GetAllUserRoleDTOAsync();
                _logger.LogInformation("Request successful");
                return Ok(new ResponseObjectDTO { ResponseObject = userRoles, Message = "Request successful" });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
    }
}