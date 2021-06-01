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
using Microsoft.Extensions.Logging;

namespace API_Laer
{

    /// <summary>
    /// Сlass for working with users
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger<BookController> _logger;


        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="service"></param>
        /// <param name="appEnvironment"></param>
        /// <param name="logger"></param>
        public BookController(IBookService service, IWebHostEnvironment appEnvironment, ILogger<BookController> logger)
        {
            _service = service;
            _appEnvironment = appEnvironment;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }


        /// <summary>
        /// Receiving the book file by id/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/file/{id}")]
        public async Task<IActionResult> GetBookFileAsync(Guid id)
        {
            try
            {
                var bookFile = await _service.GetBookFileAsync(id);

                if (bookFile == null)
                {
                    _logger.LogWarning("Book file not found");
                    return NotFound(new ResponseDTO { Message = "Book not found" });
                }

                _logger.LogInformation("Request successful");
                return File(bookFile.File, bookFile.FileType, bookFile.FileName);
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        /// <summary>
        /// Receiving the book by id/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/form/{id}")]
        public async Task<IActionResult> GetBookAddDTOAsync(Guid id)
        {
            try
            {
                var book = await _service.GetBookAddDTOAsync(id);

                if (book == null)
                {
                    _logger.LogWarning("Book not found");
                    return NotFound(new ResponseDTO { Message = "Book not found" });
                }
                _logger.LogInformation("Request successful");
                return Ok(new ResponseObjectDTO { ResponseObject = book, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        /// <summary>
        /// Receiving the all books/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<BookFormDTO>>> GetBooksFormAsync()
        {
            try
            {
                var books = await _service.GetAllBooksFormDTOAsync();

                if (books == null)
                {
                    _logger.LogWarning("Books not found");
                    return NotFound(new ResponseDTO { Message = "Books not found in date base" });
                }

                _logger.LogInformation("Request successful");
                return Ok(new ResponseObjectDTO { ResponseObject = books, Message = "Request successful" });
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        /// <summary>
        /// Change book by id number/ protected / role for access - Moderator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newBookDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutBookAsync(Guid id, BookAddDTO newBookDTO)
        {
            try
            {
                await _service.EditBookAsync(newBookDTO, id);
                _logger.LogInformation("Book is puted");
                return Ok(new ResponseDTO { Message = "Book is puted" });
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        /// <summary>
        /// A method for create new book/ protected / role for access - Moderator
        /// </summary>
        /// <param name="bookDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult> InsertAsync(BookAddDTO bookDTO)
        {
            try
            {
                var id = await _service.AddBookAsync(bookDTO);
                if (id == default)
                {
                    _logger.LogWarning("Book not added");
                    return BadRequest(new ResponseDTO { Message = "Book not added" });
                }
                _logger.LogInformation("User is added");
                return Ok(new ResponseObjectDTO { ResponseObject = id, Message = "Book info added" });
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


        /// <summary>
        /// Add a book file to the server storage/ protected/ role for access - Moderator
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
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
                    using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fileStream);
                }
                _logger.LogInformation("Book file is added");
                return Ok(new ResponseObjectDTO { ResponseObject = new { filePath, fileType = file.ContentType }, Message = "Book file added" });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = e.Message });
            }
        }


        /// <summary>
        /// Delete book by id number/ protected / role for access - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [Authorize(Roles = "Moderator")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBookAsync(Guid id)
        {
            try
            {
                await _service.DeleteBookAsync(id);
                _logger.LogInformation("Book is deleted");
                return Ok(new ResponseDTO { Message = "Book is delete" });
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }
    }
}