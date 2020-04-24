using BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IBookService
    {
        Task DeleteBookAsync(Guid id);
        void Dispose();
        Task EditBookAsync(BookAddDTO newBookDTO, Guid bookId);
        Task<IEnumerable<BookFormDTO>> GetAllBooksFormDTOAsync();
        Task<BookOpenDTO> GetBookOpenDTOAsync(Guid id);
        Task<Guid> InsertBookAsync(BookAddDTO newBookDTO);
    }
}