using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

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
        public async Task<ActionResult<PhysicalFileResult>> GetBookFileAsync(Guid id)
        {
            try
            {
                var bookFile = await _service.GetBookFileAsync(id);

                if (bookFile == null)
                {
                    return NotFound();
                }

                return PhysicalFile(bookFile.BookFilePath, bookFile.ContentType, bookFile.BookName);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get/form/{id}")]
        public async Task<ActionResult<BookFileDTO>> GetBookAddDTOAsync(Guid id)
        {
            try
            {
                var bookDTO = await _service.GetBookAddDTOAsync(id);

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

            return Ok();
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> EditBookAsync(BookAddDTO newBookDTO, Guid id)
        {
            try
            {
                await _service.EditBookAsync(newBookDTO, id);
                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (NullReferenceException e)
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
                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("upload/post")]
        public async Task<ActionResult> AddBookFile(IFormFile file)
        {
            try
            {
                string contentInfo = file.ContentType;
                string filePath = null;
                if (file.Length > 0)
                {
                                        filePath = $"BookLibrary/{file.FileName}";
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                return Ok(new { filePath = filePath, contentInfo = contentInfo });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Text = e.Message });
            }
        }
    }
}