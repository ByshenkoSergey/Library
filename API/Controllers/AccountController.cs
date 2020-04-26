using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace API_Laer
{
    [Authorize(Roles = "Admin")]
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
            try
            {
                var token = await _service.GetTokenAsync(loginUser.Login, loginUser.Password);
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
        [HttpPost("post")]
        public async Task<IActionResult> AddNewUserAsync(NewUserDTO newUser)
        {
            try
            {
                Guid id = await _service.AddUserAsync(newUser);
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

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            try
            {
                var user = await _service.GetUserDTOAsync(id);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var users = await _service.GetAllUsersDTOAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("put/{id}")]
        public async Task<IActionResult> EditUserAsync(Guid id, NewUserDTO user)
        {
            try
            {
                await _service.EditUserAsync(id, user);
                return Ok("Edit user is compleate");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _service.DeleteUserAsync(id);
                return Ok("User is deleted");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }        
        }
    }


}