using BLL.DTOModels;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;

        public AuthorService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> GetAuthorDTOAsync(Guid id)
        {
            var author = await _unit.AuthorRepository.GetAsync(id);

            if (author == null)
            {
                return null;
            }

            return _mapper.GetMapper().Map<Author, AuthorDTO>(author);
        }

        public void Dispose()
        {
            _unit.Dispose();
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            try
            {
                _unit.AuthorRepository.Delete(id);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorDTOAsync()
        {
            return _mapper.GetMapper().Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(await _unit.AuthorRepository.GetAllAsync());
        }

        public async Task EditAuthorAsync(Guid id, AuthorDTO authorDTO)
        {
            try
            {
                var author = _mapper.GetMapper().Map<AuthorDTO, Author>(authorDTO);
                _unit.AuthorRepository.Edit(author, id);
                await _unit.SaveChangeAsync();
            }

            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<Guid> InsertAuthorAsync(AuthorDTO authorDTO)
        {
            var author = _mapper.GetMapper().Map<Author>(authorDTO);
            _unit.AuthorRepository.Add(author);
            await _unit.SaveChangeAsync();
            return await _unit.AuthorRepository.GetModelIdAsync(author.AuthorName);
        }
                
    }

}
