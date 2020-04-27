using BLL.DTOModels;
using DAL.Models.IdentityModels;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;


        public UserRoleService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<UserRoleDTO> GetUserRoleDTOAsync(Guid id)
        {
            var userRole = await _unit.UserRoleRepository.GetAsync(id);

            if (userRole == null)
            {
                return null;
            }

            return _mapper.GetMapper().Map<UserRole, UserRoleDTO>(userRole);
        }

        public async Task DeleteUserRoleAsync(Guid id)
        {
            try
            {
                _unit.UserRoleRepository.Delete(id);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoleDTOAsync()
        {
            return _mapper.GetMapper().Map<IEnumerable<UserRole>, IEnumerable<UserRoleDTO>>(await _unit.UserRoleRepository.GetAllAsync());
        }

        public async Task EditUserRoleAsync(Guid id, UserRoleDTO userRoleDTO)
        {
            try
            {
                var userRole = _mapper.GetMapper().Map<UserRoleDTO, UserRole>(userRoleDTO);
                _unit.UserRoleRepository.Edit(userRole, id);
                await _unit.SaveChangeAsync();
            }

            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<Guid> AddUserRoleAsync(UserRoleDTO userRoleDTO)
        {
            var userRole = _mapper.GetMapper().Map<UserRole>(userRoleDTO);
            _unit.UserRoleRepository.Add(userRole);
            await _unit.SaveChangeAsync();
            return await _unit.UserRoleRepository.GetModelIdAsync(userRole.RoleName);
        }

        public void Dispose()
        {
            _unit.Dispose();
        }
    }
}
