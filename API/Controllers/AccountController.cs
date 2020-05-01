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
                    return BadRequest(e.Message);
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
                    return BadRequest("New user not added");
                }
                return Created("api/account/post", $"New user is created, new user id - {id}");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
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
            catch (BLL.Infrastructure.Exceptions.ValidationException e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("user/put/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, NewUserDTO user)
        {
            try
            {
                await _userService.EditUserAsync(id, user);
                return Ok("Edit user is compleate");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("user/delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("User is deleted");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }        
        }

        [Authorize]
        [HttpPost("userrole/post")]
        public async Task<IActionResult> AddNewUserRoleAsync(UserRoleDTO UserRole)
        {
            try
            {
                Guid id = await _userRoleServices.AddUserRoleAsync(UserRole);
                if (id == default)
                {
                    return BadRequest("New user not added");
                }
                return Created("api/account/post", $"New user is created, new user id - {id}");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("userrole/get/{id}")]
        public async Task<IActionResult> GetUserRoleAsync(Guid id)
        {
            try
            {
                var user = await _userRoleServices.GetUserRoleDTOAsync(id);
                return Ok(user);
            }
            catch (BLL.Infrastructure.Exceptions.ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("userrole/get")]
        public async Task<IActionResult> GetAllUserRoleAsync()
        {
            try
            {
                var users = await _userRoleServices.GetAllUserRoleDTOAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("userrole/put/{id}")]
        public async Task<IActionResult> EditUserRoleAsync(Guid id, UserRoleDTO user)
        {
            try
            {
                await _userRoleServices.EditUserRoleAsync(id, user);
                return Ok("Edit user is compleate");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("userrole/delete/{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            try
            {
                await _userRoleServices.DeleteUserRoleAsync(id);
                return Ok("UserRole is deleted");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}