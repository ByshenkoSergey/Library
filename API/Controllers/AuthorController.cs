using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BLL.Services.Interfaces;

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
            var author = await _service.GetAuthorDTOAsync(id);

            if (author == null)
            {
                return NotFound(new ResponseDTO { Message = "Author not found" });
            }

            return Ok(new ResponseObjectDTO { ResponseObject = author, Message = "Request successful" });
        }


        [Authorize(Roles = "Admin, Moderator, SuperUser")]
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

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult<int>> PostAuthorDTOAsync(AuthorDTO authorDTO)
        {
            try
            {
                var id = await _service.InsertAuthorAsync(authorDTO);
                return Ok(new ResponseObjectDTO { ResponseObject = id, Message = "Author added" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        [Authorize(Roles = "Admin, Moderator")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAuthorDTOAsync(Guid id)
        {
            try
            {
                await _service.DeleteAuthorAsync(id);
                return Ok(new ResponseDTO { Message = "Author is delete"});
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
    }
}