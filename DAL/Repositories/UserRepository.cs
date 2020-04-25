﻿using DAL.Context;
using DAL.Models.IdentityModels;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class UserRepository : IUserRepository
    {
        private LibraryDataBaseContext _context;
        


        public UserRepository(LibraryDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new ArgumentException("Do not serch this user");
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync<ApplicationUser>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    throw new ArgumentException("Do not serch this user");
                }
                _context.Users.Remove(user);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void EditUser(Guid id, ApplicationUser newUser)
        {
            try
            {
                if (newUser == null)
                {
                    throw new ArgumentNullException("ApplicationUser is null");
                }
                var user =  _context.Users.FindAsync(id).Result;

                if (user == null)
                {
                    throw new ArgumentException("Do not serch this user");
                }

                _context.Entry<ApplicationUser>(user).State = EntityState.Modified;
                AddUser(newUser);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void AddUser(ApplicationUser newUser)
        {
            try
            {
                if (newUser == null)
                {
                    throw new ArgumentNullException("ApplicationUser is null");
                }
                                _context.Users.Add(newUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> GetUserIdAsync(string userName)
        {
            try
            {
                var users = await _context.Users.ToListAsync<ApplicationUser>();

                if (users == null)
                {
                    throw new ArgumentException("Do not serch this user");
                }

                Guid userId = default;

                foreach (var user in users)
                {
                    if (user.UserName == userName)
                    {
                        userId = user.Id;
                        break;
                    }
                }

                if (userId == default)
                {
                    throw new ArgumentException("User is not serch");
                }

                return userId;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
       
    }
}
