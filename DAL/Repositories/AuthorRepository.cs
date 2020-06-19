using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        
        public AuthorRepository(LibraryDataBaseContext context)
    : base(context) 
        {
           
        }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var authorList = await GetAllAsync();
            foreach (var author in authorList)
            {
                if (author.AuthorName == name)
                {
                  return author.AuthorId;
                }
            }
            return default;
        }
    }
}
