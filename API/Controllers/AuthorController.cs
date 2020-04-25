using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Service.Interfaces;
using BL.DTOModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API_Laer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        
        [HttpGet("get/{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }

            var author = await _service.GetAuthorDTOAsync(id);

            if (author == null)
            {
                return NotFound("Author not found!");
            }

            return Ok(author);
        }

        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Moderator")]
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorAsync()
        {
            try
            {
                return Ok(await _service.GetAllAuthorDTOAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult<int>> PostAuthorDTOAsync(AuthorDTO authorDTO)
        {
            try
            {
                return Ok(await _service.InsertAuthorAsync(authorDTO));
            }
            catch (Exception e)// to do conkreate error
            {
                return BadRequest(e.Message);
            }
        }


        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutAuthorDTOAsync(Guid id, AuthorDTO authorDTO)
        {
            try
            {
                await _service.EditAuthorAsync(id, authorDTO);
                return Ok("Update is complite");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        //[HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAuthorDTOAsync(Guid id)
        {
            try
            {
                await _service.DeleteAuthorAsync(id);
                return Ok("Author is delete");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}