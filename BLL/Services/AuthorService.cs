using BLL.DTOModels;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IUnitOfWork unit, IMapConfig mapper, ILogger<AuthorService> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public async Task<AuthorDTO> GetAuthorDTOAsync(Guid id)
        {
            var author = await _unit.AuthorRepository.GetAsync(id);

            if (author == null)
            {
                _logger.LogWarning("Author not found");
                return null;
            }

            _logger.LogInformation("Return author DTO");
            return _mapper.GetMapper().Map<Author, AuthorDTO>(author);
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            try
            {
                _unit.AuthorRepository.Delete(id);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Author is deleted");
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorDTOAsync()
        {
            var authorList = await _unit.AuthorRepository.GetAllAsync();
            var authorListDTO = _mapper.GetMapper().Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authorList);
            _logger.LogInformation("Return author list DTO");
            return authorListDTO; 
        }

        public async Task EditAuthorAsync(Guid id, AuthorDTO authorDTO)
        {
            try
            {
                var author = _mapper.GetMapper().Map<AuthorDTO, Author>(authorDTO);
                _unit.AuthorRepository.Edit(author, id);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Author is puted");
            }

            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public void Dispose()
        {
            _unit.Dispose();
            _logger.LogInformation("Author reposytory is dispose");
        }


    }

}
