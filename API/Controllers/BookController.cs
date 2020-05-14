using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace API_Laer
{
    [Authorize]
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _service;
        private IWebHostEnvironment _appEnvironment;

        public BookController(IBookService service, IWebHostEnvironment appEnvironment)
        {
            _service = service;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("get/file/{id}")]
        public async Task<IActionResult> GetBookAsync(Guid id)
        {
            try
            {
                var bookFile = await _service.GetBookFileAsync(id);

                if (bookFile == null)
                {
                    return NotFound(new ResponseDTO { Message = "Book not found" });
                }

                return File(bookFile.File, bookFile.FileType, bookFile.FileName);
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [HttpGet("get/form/{id}")]
        public async Task<ActionResult<BookAddDTO>> GetBookAddDTOAsync(Guid id)
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
                    return NotFound(new ResponseDTO { Message = "Books not found" });
                }

                return Ok(new ResponseObjectDTO { ResponseObject = books, Message = "Request successful" });
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


        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutBookAsync(Guid id, BookAddDTO newBookDTO)
        {
            try
            {
                await _service.EditBookAsync(newBookDTO, id);
                return Ok(new ResponseDTO { Message = "Book is puted" });
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

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult> InsertAsync(BookAddDTO bookDTO)
        {
            try
            {
                var id = await _service.AddBookAsync(bookDTO);
                return Ok(new ResponseObjectDTO { ResponseObject = id, Message = "Book info added" });
            }
            catch (ValidationException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("upload/post")]
        public async Task<ActionResult> AddBookFile(IFormFile file)
        {
            try
            {
                string filePath = null;
                var uploads = Path.Combine(_appEnvironment.WebRootPath, "BookLibrary");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (file.Length > 0)
                {
                    filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                return Ok(new ResponseObjectDTO { ResponseObject = new { filePath = filePath, fileType = file.ContentType }, Message = "Book file added" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = e.Message });
            }
        }
    }
}