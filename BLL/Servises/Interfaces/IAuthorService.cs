using BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IAuthorService : IDisposable
    {
        Task<AuthorDTO> GetAuthorDTOAsync(Guid id);
        Task DeleteAuthorAsync(Guid id);
        Task<IEnumerable<AuthorDTO>> GetAllAuthorDTOAsync();
        Task EditAuthorAsync(Guid id, AuthorDTO authorDTO);
        Task<Guid> InsertAuthorAsync(AuthorDTO authorDTO);
    }
}