using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.DTOModels;
using System;
using BLL.Infrastructure.Exceptions;

namespace API_Laer
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token(LoginUserDTO loginUser)
        {
            try
            {
                var token = await _userService.GetTokenAsync(loginUser.Login, loginUser.Password);
                return Ok(new ResponseObjectDTO  { ResponseObject = token, Message = "Request successful" });
                
            }
            catch (InvalidLogginUserException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }
        [AllowAnonymous]
        [HttpPost("post")]
        public async Task<IActionResult> AddNewUserAsync(NewUserDTO newUser)
        {
            try
            {
                if (newUser.UserRole == null)
                {
                    newUser.UserRole = "User";
                }
                var id = await _userService.AddUserAsync(newUser);
                if (id == default)
                {
                    return BadRequest(new ResponseDTO { Message = "User not added" });
                }
                return Ok(new ResponseObjectDTO { ResponseObject = id, Message = "User is added" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetUserDTOAsync(id);
                return Ok(new ResponseObjectDTO { ResponseObject = user, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("gets")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersDTOAsync();
                return Ok(new ResponseObjectDTO { ResponseObject = users, Message = "Request successful" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, NewUserDTO user)
        {
            try
            {
                await _userService.EditUserAsync(id, user);
                return Ok(new ResponseDTO { Message = "User is puted" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new ResponseDTO { Message = "User is delete" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

    }

}