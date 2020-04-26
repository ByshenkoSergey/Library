using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task DeleteBookAsync(Guid id);
        void Dispose();
        Task EditBookAsync(BookAddDTO newBookDTO, Guid bookId);
        Task<IEnumerable<BookFormDTO>> GetAllBooksFormDTOAsync();
        Task<BookOpenDTO> GetBookOpenDTOAsync(Guid id);
        Task<Guid> AddBookAsync(BookAddDTO newBookDTO);
    }
}