using DAL.Context;
using DAL.Models.IdentityModels;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private LibraryDataBaseContext _context;
        


        public UserRoleRepository(LibraryDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUserRole> GetUserRoleAsync(Guid id)
        {

            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null)
                {
                    throw new ArgumentException("Do not serch this role");
                }
                return role;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<IEnumerable<ApplicationUserRole>> GetAllUserRolesAsync()
        {
            try
            {
                return await _context.Roles.ToListAsync<ApplicationUserRole>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteUserRoleAsync(Guid id)
        {
            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null)
                {
                    throw new ArgumentException("Do not serch this role");
                }
                _context.Roles.Remove(role);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task EditUserRoleAsync(Guid id, ApplicationUserRole newRole)
        {
            try
            {
                if (newRole == null)
                {
                    throw new ArgumentNullException("ApplicationUserRole is null");
                }
                var role = await _context.Roles.FindAsync(id);

                if (role == null)
                {
                    throw new ArgumentException("Do not serch this role");
                }

                _context.Entry<ApplicationUserRole>(role).State = EntityState.Modified;
                await _context.Roles.AddAsync(newRole);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task InsertUserRoleAsync(ApplicationUserRole newRole)
        {
            try
            {
                if (newRole == null)
                {
                    throw new ArgumentNullException("ApplicationUserRole is null");
                }

                await _context.Roles.AddAsync(newRole);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Guid> GetUserRoleIdAsync(string roleName)
        {
            try
            {
                var roles = await _context.Roles.ToListAsync<ApplicationUserRole>();

                if (roles == null)
                {
                    throw new ArgumentException("Do not serch this role");
                }

                Guid roleId = default;

                foreach (var role in roles)
                {
                    if (role.Name == roleName)
                    {
                        roleId = role.Id;
                        break;
                    }
                }

                if (roleId == default)
                {
                    throw new ArgumentException("User role is not serch");
                }

                return roleId;
            }
            catch (Exception)
            {
                throw;
            }


        }
        
    }
}
