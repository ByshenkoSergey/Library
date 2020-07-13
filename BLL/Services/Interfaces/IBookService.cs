using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task DeleteBookAsync(Guid id);
        Task<BookAddDTO> GetBookAddDTOAsync(Guid id);
        Task EditBookAsync(BookAddDTO newBookDTO, Guid bookId);
        Task<IEnumerable<BookFormDTO>> GetAllBooksFormDTOAsync();
        Task<FileDTO> GetBookFileAsync(Guid id);
        Task<Guid> AddBookAsync(BookAddDTO newBookDTO);
    }
}