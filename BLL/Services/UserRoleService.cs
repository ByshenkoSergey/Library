using BLL.DTOModels;
using DAL.Models.IdentityModels;
using DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly ILogger<UserRoleService> _logger;


        public UserRoleService(IUnitOfWork unit, IMapConfig mapper, ILogger<UserRoleService> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoleDTOAsync()
        {
            var userRoleList = await _unit.UserRoleRepository.GetAllAsync();
            var userRoleListDTO = _mapper.GetMapper().Map<IEnumerable<UserRole>, IEnumerable<UserRoleDTO>>(userRoleList);
            _logger.LogInformation("Return user role list DTO");
            return userRoleListDTO;
        }

        public void Dispose()
        {
            _unit.Dispose();
            _logger.LogInformation("User role repository is disposed");
        }
    }
}
