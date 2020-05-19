using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BLL.DTOModels;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{


    /// <summary>
    /// Сlass for working with users role
    /// </summary>

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {

       
        private IUserRoleService _userRoleServices;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="userRoleServices"></param>

        public UserRoleController(IUserRoleService userRoleServices)
        {
           _userRoleServices = userRoleServices;
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
                return Ok(new ResponseObjectDTO { ResponseObject = userRoles, Message = "Request successful" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

      
    }
}