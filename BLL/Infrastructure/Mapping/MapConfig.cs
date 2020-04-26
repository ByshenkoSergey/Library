using AutoMapper;
using BLL.DTOModels;
using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.UnitOfWork;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Mapping
{
    public class MapConfig : IMapConfig
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;

        public MapConfig(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IMapper GetMapper()
        {
            _mapper = new MapperConfiguration(cnf =>
            {
                cnf.CreateMap<Author, AuthorDTO>();
                cnf.CreateMap<User, NewUserDTO>();
                cnf.CreateMap<AuthorDTO, Author>();
                cnf.CreateMap<PublishingHouse, PublishingHouseDTO>();
                cnf.CreateMap<PublishingHouseDTO, PublishingHouse>();
                cnf.CreateMap<Book, BookOpenDTO>()
                               .ForMember("BookText", o => o.MapFrom(p => GetBookTextAsync(p.BookFileAddress).Result));

                cnf.CreateMap<Book, BookFormDTO>()
                               .ForMember("PublishingHouseName", opt => opt.MapFrom(p => GetPublishingHouseNameAsync(p.PublishingHouseId).Result))
                               .ForMember("AuthorName", opt => opt.MapFrom(a => GetAuthorNameAsync(a.AuthorId).Result));

                cnf.CreateMap<BookAddDTO, Book>()
                               .ForMember("PublishingHouseId", opt => opt.MapFrom(p => GetPublishingHouseIdAsync(p.PublishingHouseName).Result))
                               .ForMember("AuthorId", opt => opt.MapFrom(p => GetAuthorIdAsync(p.AuthorName).Result))
                               .ForMember("Rating", opt => opt.MapFrom(p => 0));

                cnf.CreateMap<Book, BookAddDTO>()
                               .ForMember("PublishingHouseName", opt => opt.MapFrom(p => GetPublishingHouseNameAsync(p.PublishingHouseId).Result))
                               .ForMember("AuthorName", opt => opt.MapFrom(a => GetAuthorNameAsync(a.AuthorId).Result));

                cnf.CreateMap<User, NewUserDTO>()
                                .ForMember("UserRole", opt => opt.MapFrom(p => GetUserRoleName(p.ApplicationUserRoleId).Result));
                
                cnf.CreateMap<NewUserDTO, User>()
                                .ForMember("ApplicationUserRoleId", opt => opt.MapFrom(p => GetUserRoleId(p.UserRole).Result));



            }).CreateMapper();
            return _mapper;

        }

        #region NewUserDTOToApplicationUser
        private async Task<string> GetUserRoleName(Guid applicationUserRoleId)
        {
            var role = await _unit.UserRoleRepository.GetAsync(applicationUserRoleId);
            
            if (role == default)
            {
                throw new ValidationException("User role not found", "");
            }
            return role.RoleName;
        }
        #endregion

        #region ApplicationUserToNewUserDTO
        private async Task<Guid> GetUserRoleId(string applicationUserRoleName)
        {
            var roleId = await _unit.UserRoleRepository.GetModelIdAsync(applicationUserRoleName);
            if (roleId == default)
            {
                throw new ValidationException("User role not found", "");
            }
            return roleId;
        }
        #endregion

        #region MapBookToBookFormDTO
        private async Task<string> GetBookTextAsync(string bookFileAddress)
        {
            try
            {
                using (FileStream fs = new FileStream(bookFileAddress, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        return await sr.ReadToEndAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region MapBookAddDTOToBook
        private async Task<Guid> GetPublishingHouseIdAsync(string publishingHouseName)
        {
            var PublishingHouseList = await _unit.PublishingHouseRepository.GetAllAsync();

            foreach (var publishingHouse in PublishingHouseList)
            {
                if (publishingHouseName == publishingHouse.PublishingHouseName)
                {
                    return publishingHouse.PublishingHouseId;
                }
            }

            var newPublishingHouse = new PublishingHouse
            {
                PublishingHouseName = publishingHouseName
            };

            _unit.PublishingHouseRepository.Add(newPublishingHouse);
            await _unit.SaveChangeAsync();

            var id = await _unit.PublishingHouseRepository.GetModelIdAsync(newPublishingHouse.PublishingHouseName);
            return id;

        }

        private async Task<Guid> GetAuthorIdAsync(string authorName)
        {
            try
            {
                var authorList = await _unit.AuthorRepository.GetAllAsync();

                Author newAuthor = null;

                foreach (var author in authorList)
                {
                    if (authorName == author.AuthorName)
                    {
                        newAuthor = author;
                        break;
                    }
                }
                if (newAuthor == null)
                {
                    newAuthor = new Author()
                    {
                        AuthorName = authorName
                    };
                    _unit.AuthorRepository.Add(newAuthor);
                    await _unit.SaveChangeAsync();
                }
                return await _unit.AuthorRepository.GetModelIdAsync(newAuthor.AuthorName);
            }
            catch (ValidationException e)
            {
                throw e;
            }
        }
        #endregion


        #region MapBooksToBooksFromDTO
        private async Task<string> GetPublishingHouseNameAsync(Guid publishingHouseId)
        {
            var publishingHouse = await _unit.PublishingHouseRepository.GetAsync(publishingHouseId);

            if (publishingHouse == null)
            {
                throw new ValidationException("Publishing house not found!", "");
            }
            return publishingHouse.PublishingHouseName;
        }

        private async Task<string> GetAuthorNameAsync(Guid authorId)
        {
            var author = await _unit.AuthorRepository.GetAsync(authorId);

            if (author == null)
            {
                throw new ValidationException("Author not found!", "");
            }

            return author.AuthorName;
        }
        #endregion

    }
}
