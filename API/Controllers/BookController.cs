using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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

        [HttpGet("get/lightForm/{id}")]
        public async Task<ActionResult<BookOpenDTO>> GetBookOpenDTOAsync(Guid id)
        {
            try
            {
                var book = await _service.GetBookOpenDTOAsync(id);

                if (book == null)
                {
                    return NotFound(new ResponseDTO { Message = "Book not found" });
                }

                return Ok(new ResponseObjectDTO { ResponseObject = book, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpGet("get/form/{id}")]
        public async Task<ActionResult<BookOpenDTO>> GetBookAddDTOAsync(Guid id)
        {
            try
            {
                var book = await _service.GetBookAddDTOAsync(id);

                if (book == null)
                {
                    return NotFound(new ResponseDTO { Message = "Book not found" });
                }

                return Ok(new ResponseObjectDTO { ResponseObject = book, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
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
                    return NotFound(new ResponseDTO { Message="Books not found"});
                }

                return Ok(new ResponseObjectDTO{ ResponseObject = books, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
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

                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

            return Ok(new ResponseDTO { Message = "Book is delete" });
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
       [HttpPut("put/{id}")]
        public async Task<ActionResult> PutBookAsync(Guid id, [FromBody]BookAddDTO book)
        {
            try
            {
                await _service.EditBookAsync(book, id);
                return Ok(new ResponseDTO { Message = "Book is puted"});
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
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
                return Ok(new ResponseObjectDTO {ResponseObject=id, Message = "Book info added" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("upload/post")]
        public async Task<ActionResult> AddBookFile(IFormFile file)
        {
            try
            {
                string filePath = null;
                if (file.Length > 0)
                {
                    filePath = $"BookLibrary/{file.FileName}";
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                return Ok(new ResponseObjectDTO { ResponseObject = filePath, Message="Book file added" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO {  Message = e.Message });
            }
        }
    }
}