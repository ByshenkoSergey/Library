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


        
        [HttpPost("post")]
        public async Task<IActionResult> AddNewUserRoleAsync(UserRoleDTO UserRole)
        {
            try
            {
                Guid id = await _userRoleServices.AddUserRoleAsync(UserRole);
                if (id == default)
                {
                    return BadRequest(new ResponseDTO { Message = "User role not added" });
                }
                return Ok(new ResponseObjectDTO { ResponseObject = id,Message = "User role is created" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
        
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserRoleAsync(Guid id)
        {
            try
            {
                var user = await _userRoleServices.GetUserRoleDTOAsync(id);
                return Ok(new ResponseObjectDTO { ResponseObject = user, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        
        [HttpGet("get")]
        public async Task<IActionResult> GetAllUserRoleAsync()
        {
            try
            {
                var users = await _userRoleServices.GetAllUserRoleDTOAsync();
                return Ok(new ResponseObjectDTO { ResponseObject = users, Message = "Request successful" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutUserRoleAsync(Guid id, UserRoleDTO user)
        {
            try
            {
                await _userRoleServices.PutUserRoleAsync(id, user);
                return Ok(new ResponseDTO { Message = "User is puted" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            try
            {
                await _userRoleServices.DeleteUserRoleAsync(id);
                return Ok(new ResponseDTO { Message = "User role is deleted" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
    }
}