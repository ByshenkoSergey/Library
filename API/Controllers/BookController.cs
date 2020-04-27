using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace API_Laer
{
    [Authorize]
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<BookOpenDTO>> GetBookOpenDTOAsync(Guid id)
        {
            try
            {
                var bookDTO = await _service.GetBookOpenDTOAsync(id);

                if (bookDTO == null)
                {
                    return NotFound();
                }

                return Ok(new ObjectResult(bookDTO));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<BookFormDTO>>> GetBooksFormAsync()
        {
            try
            {
                var books = await _service.GetAllBooksFormDTOAsync();

                if (books == null)
                {
                    return NotFound();
                }

                return Ok(new ObjectResult(books));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBookAsync(Guid id)
        {
            try
            {
                await _service.DeleteBookAsync(id);
            }
            catch (ValidationException e)
            {

                return BadRequest(e.Message);
            }

            return Ok("Book is deleted");
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> EditBookAsync(BookAddDTO newBookDTO, Guid id)
        {
            try
            {
                await _service.EditBookAsync(newBookDTO, id);
                return Ok("Edit book complite");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult> InsertAsync(BookAddDTO bookDTO)
        {
            try
            {
                var id = await _service.AddBookAsync(bookDTO);
                return Ok($"Book is added, new Id is {id}");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}