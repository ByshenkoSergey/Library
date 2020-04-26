using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;


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
                return new ObjectResult(token);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }

        }
        [Authorize]
        [HttpPost("post/user")]
        public async Task<IActionResult> AddNewUserAsync(NewUserDTO newUser)
        {
            try
            {
                Guid id = await _userService.AddUserAsync(newUser);
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

        [HttpGet("get/user/{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetUserDTOAsync(id);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get/user")]
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
        [HttpPut("put/user/{id}")]
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

        [HttpDelete("delete/user/{id}")]
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
        [HttpPost("post/userrole")]
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

        [HttpGet("get/userrole/{id}")]
        public async Task<IActionResult> GetUserRoleAsync(Guid id)
        {
            try
            {
                var user = await _userRoleServices.GetUserRoleDTOAsync(id);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get/userrole")]
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
        [HttpPut("put/userrole/{id}")]
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

        [HttpDelete("delete/userrole/{id}")]
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