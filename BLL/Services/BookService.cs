using BLL.DTOModels;
using BLL.Infrastructure.Exceptions;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
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


        public BookService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task DeleteBookAsync(Guid id)
        {
            try
            {
                var book = await _unit.BookRepository.GetAsync(id);
                _unit.BookRepository.Delete(id);
                DeleteBookFile(book.FilePath);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
                throw new ValidationException(e.Message, "");
            }
        }

        public async Task<BookAddDTO> GetBookAddDTOAsync(Guid id)
        {
            var book = await _unit.BookRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }
            try
            {
                return _mapper.GetMapper().Map<Book, BookAddDTO>(book);
            }
            catch (Exception)
            {
                throw new ValidationException("File address is failrule", "");
            }

        }

        public async Task<FileDTO> GetBookFileAsync(Guid id)
        {
            var book = await _unit.BookRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }
            try
            {
                var filePath = book.FilePath;
                if (!File.Exists(filePath))
                {
                    return null;
                }

                var memory = new MemoryStream();

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;

                return new FileDTO { File = memory, FileType = book.FileType, FileName = book.BookName };
            }
            catch (Exception)
            {
                throw new ValidationException("Download is failrule", "");
            }

        }
        public async Task<IEnumerable<BookFormDTO>> GetAllBooksFormDTOAsync()
        {
            try
            {
                var bookList = await _unit.BookRepository.GetAllAsync();
                return _mapper.GetMapper().Map<IEnumerable<Book>, IEnumerable<BookFormDTO>>(bookList);
            }
            catch (ValidationException e)
            {
                throw e;
            }
        }
        public async Task<Guid> AddBookAsync(BookAddDTO newBookDTO)
        {
            if (!newBookDTO.FilePath.EndsWith(".txt"))
            {
                throw new ValidationException("Format file is not validate", "");
            }

            if (await BookAvailabilityCheckAsync(newBookDTO))
            {
                throw new ValidationException("Such a book already exists", "");
            }

            try
            {
                var book = _mapper.GetMapper().Map<BookAddDTO, Book>(newBookDTO);
                _unit.BookRepository.Add(book);
                await _unit.SaveChangeAsync();
                return await _unit.BookRepository.GetModelIdAsync(book.BookName);
            }
            catch (ValidationException e)
            {
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
            }
            catch (ValidationException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            _unit.Dispose();
        }

        private void DeleteBookFile(string bookFileAddress)
        {
            try
            {
                var file = new FileInfo(bookFileAddress);
                file.Delete();
            }

            catch (ArgumentException)
            {
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
                    return true;
                }
            }
            return false;
        }


    }

}

