using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.DTOModels;
using System;
using BLL.Infrastructure.Exceptions;

namespace API_Laer
{

    /// <summary>
    /// Сlass for working with users
    /// </summary>

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IUserService _userService;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="userService"></param>

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        /// <summary>
        /// A method for generating a JWT access token/ available to anonymous users
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token(LoginUserDTO loginUser)
        {
            try
            {
                var token = await _userService.GetTokenAsync(loginUser.Login, loginUser.Password);
                return Ok(new ResponseObjectDTO { ResponseObject = token, Message = "Request successful" });

            }
            catch (InvalidLogginUserException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }

        /// <summary>
        /// A method for create new user(registration)/ available to anonymous users
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Receiving the user by id/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
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

        /// <summary>
        /// Receiving the all users/ protected / role for access - Admin
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// Change user by id number/ protected / role for access - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>

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


        /// <summary>
        /// Delete user by id number/ protected / role for access - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
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