using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BLL.DTOModels;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {

       
        private IUserRoleService _userRoleServices;

        public UserRoleController(IUserRoleService userRoleServices)
        {
           _userRoleServices = userRoleServices;
        }
               
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