using BLL.DTOModels;
using BLL.Infrastructure.Exceptions;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly ILogger<BookService> _logger;


        public BookService(IUnitOfWork unit, IMapConfig mapper, ILogger<BookService> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }


        public async Task<BookAddDTO> GetBookAddDTOAsync(Guid id)
        {
            var book = await _unit.BookRepository.GetAsync(id);

            if (book == null)
            {
                _logger.LogWarning("Book not found");
                return null;
            }
            try
            {
                _logger.LogInformation("Return BookAdd DTO");
                return _mapper.GetMapper().Map<Book, BookAddDTO>(book);
            }
            catch (Exception)
            {
                _logger.LogError("File address is failrule");
                throw new ValidationException("File address is failrule", "");
            }

        }


        public async Task<FileDTO> GetBookFileAsync(Guid id)
        {
            var book = await _unit.BookRepository.GetAsync(id);

            if (book == null)
            {
                _logger.LogWarning("Book not found");
                return null;
            }
            try
            {
                var filePath = book.FilePath;
                if (!File.Exists(filePath))
                {
                    _logger.LogWarning("Book address not found");
                    return null;
                }

                var memory = new MemoryStream();

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;

                _logger.LogInformation("Return book file DTO");
                return new FileDTO { File = memory, FileType = book.FileType, FileName = book.BookName };
            }
            catch (Exception)
            {
                _logger.LogError("Download is failrule");
                throw new ValidationException("Download is failrule", "");
            }

        }

        public async Task DeleteBookAsync(Guid id)
        {
            try
            {
                var book = await _unit.BookRepository.GetAsync(id);
                _unit.BookRepository.Delete(id);
                DeleteBookFile(book.FilePath);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Book is deleted");
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw new ValidationException(e.Message, "");
            }
        }

        public async Task<IEnumerable<BookFormDTO>> GetAllBooksFormDTOAsync()
        {
            try
            {
                var bookList = await _unit.BookRepository.GetAllAsync();
                var bookListFormDTO = _mapper.GetMapper().Map<IEnumerable<Book>, IEnumerable<BookFormDTO>>(bookList);
                _logger.LogInformation("Return book list form DTO");
                return bookListFormDTO;
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }
        public async Task<Guid> AddBookAsync(BookAddDTO newBookDTO)
        {
            if (!newBookDTO.FilePath.EndsWith(".txt"))
            {

                _logger.LogWarning("Format file is not validate");
                throw new ValidationException("Format file is not validate", "");
            }

            if (await BookAvailabilityCheckAsync(newBookDTO))
            {
                _logger.LogWarning("Such a book already exists");
                throw new ValidationException("Such a book already exists", "");
            }

            try
            {
                var book = _mapper.GetMapper().Map<BookAddDTO, Book>(newBookDTO);
                _unit.BookRepository.Add(book);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Book is added");
                return await _unit.BookRepository.GetModelIdAsync(book.BookName);
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task EditBookAsync(BookAddDTO newBookDTO, Guid bookId)
        {
            try
            {
                var book = _mapper.GetMapper().Map<BookAddDTO, Book>(newBookDTO);
                _unit.BookRepository.Edit(book, bookId);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Book is puted");
            }
            catch (ValidationException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

       
        private void DeleteBookFile(string bookFileAddress)
        {
            try
            {
                var file = new FileInfo(bookFileAddress);
                file.Delete();
                _logger.LogInformation("Book is deleted");
            }

            catch (ArgumentException)
            {
                _logger.LogError("Book file not found!");
                throw new ArgumentException("Book file not found!");
            }
        }

        private async Task<bool> BookAvailabilityCheckAsync(BookAddDTO newBookDTO)
        {
            var bookList = await _unit.BookRepository.GetAllAsync();
            var bookDTOList = _mapper.GetMapper().Map<IEnumerable<Book>, IEnumerable<BookAddDTO>>(bookList);

            foreach (var book in bookDTOList)
            {
                if (book.BookName == newBookDTO.BookName && book.AuthorName == newBookDTO.AuthorName && book.PublisherName == newBookDTO.PublisherName)
                {
                    _logger.LogInformation("Such a book already exists");
                    return true;
                }
            }
            _logger.LogInformation("Such a book is not exists");
            return false;
        }

        public void Dispose()
        {
            _unit.Dispose();
            _logger.LogInformation("Book repository is disposed");
        }



    }

}

