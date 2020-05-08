using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.DTOModels;
using System;
using BLL.Infrastructure.Exceptions;

namespace API_Laer
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IUserRoleService _userRoleServices;

        public AccountController(IUserService userService, IUserRoleService userRoleServices)
        {
            _userService = userService;
            _userRoleServices = userRoleServices;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token(LoginUserDTO loginUser)
        {
                try
                {
                    var token = await _userService.GetTokenAsync(loginUser.Login, loginUser.Password);
                    return Ok(token);
                }
                catch (BLL.Infrastructure.Exceptions.InvalidLogginUserException e)
                {
                    return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
                }
            

            

        }
        [AllowAnonymous]
        [HttpPost("user/post")]
        public async Task<IActionResult> AddNewUserAsync(NewUserDTO newUser)
        {
            try
            {
                if (newUser.UserRole == null)
                {
                    newUser.UserRole = "User";
                }
                
                Guid id = await _userService.AddUserAsync(newUser);
                if (id == default)
                {
                    return BadRequest(new ResponseDTO { Text = "New user not added" });
                }
                return Created("https://localhost:44397/api/account/user/post", new ResponseDTO { Text = "New user is created" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
            }
        }

        [HttpGet("user/get/{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetUserDTOAsync(id);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
            }
        }

        [HttpGet("user/get")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersDTOAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
            }
        }

        [Authorize]
        [HttpPut("user/put/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, NewUserDTO user)
        {
            try
            {
                await _userService.EditUserAsync(id, user);
                return Ok(new ResponseDTO { Text = "User is correct" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
            }
        }

        [HttpDelete("user/delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new ResponseDTO { Text = "User is deleted" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Text = $"{e.Message}" });
            }        
        }
        //
      

    }

}