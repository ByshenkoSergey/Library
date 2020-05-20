using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BLL.Services.Interfaces;

namespace API_Laer
{

    /// <summary>
    /// Сlass for working with book authors
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    
    public class AuthorController : ControllerBase
    {
        private IAuthorService _service;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="service"></param>
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Receiving the author by id/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorAsync(Guid id)
        {
            var author = await _service.GetAuthorDTOAsync(id);

            if (author == null)
            {
                return NotFound(new ResponseDTO { Message = "Author not found" });
            }

            return Ok(new ResponseObjectDTO { ResponseObject = author, Message = "Request successful" });
        }


        /// <summary>
        /// Receiving the all author/ protected / role for access - Moderator
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorAsync()
        {
            try
            {
                var authorList = await _service.GetAllAuthorDTOAsync();
                return Ok(new ResponseObjectDTO { ResponseObject = authorList, Message = "Request successful" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }


        /// <summary>
        /// Change author by id number/ protected / role for access - Moderator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutAuthorDTOAsync(Guid id, AuthorDTO authorDTO)
        {
            try
            {
                await _service.EditAuthorAsync(id, authorDTO);
                return Ok(new ResponseDTO { Message = "Update is complite" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }


        /// <summary>
        /// Delete author by id number/ protected / role for access - Moderator 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAuthorDTOAsync(Guid id)
        {
            try
            {
                await _service.DeleteAuthorAsync(id);
                return Ok(new ResponseDTO { Message = "Author is delete" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
    }
}