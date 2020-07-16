using AutoMapper;
using BLL.DTOModels;
using BLL.Infrastructure.Exceptions;
using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Mapping
{
    public class MapConfig : IMapConfig
    {
        private readonly ILogger<MapConfig> _logger;
        private readonly IUnitOfWork _unit;
        private IMapper _mapper;

        public MapConfig(IUnitOfWork unit, IMapper mapper, ILogger<MapConfig> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public IMapper GetMapper()
        {
            _mapper = new MapperConfiguration(cnf =>
            {
                cnf.CreateMap<Author, AuthorDTO>();
                cnf.CreateMap<AuthorDTO, Author>();
                cnf.CreateMap<Publisher, PublisherDTO>();
                cnf.CreateMap<PublisherDTO, Publisher>();
                cnf.CreateMap<UserRole, UserRoleDTO>();
                cnf.CreateMap<Book, BookFormDTO>()
                               .ForMember("PublisherName", opt => opt.MapFrom(p => GetPublisherNameAsync(p.PublisherId).Result))
                               .ForMember("AuthorName", opt => opt.MapFrom(a => GetAuthorNameAsync(a.AuthorId).Result));
                cnf.CreateMap<BookAddDTO, Book>()
                               .ForMember("PublisherId", opt => opt.MapFrom(p => GetPublisherIdAsync(p.PublisherName).Result))
                               .ForMember("AuthorId", opt => opt.MapFrom(p => GetAuthorIdAsync(p.AuthorName).Result))
                               .ForMember("Rating", opt => opt.MapFrom(p => 0))
                               .ForMember("BookName", opt => opt.MapFrom(p => p.BookName + ".txt"));
                cnf.CreateMap<Book, BookAddDTO>()
                               .ForMember("PublisherName", opt => opt.MapFrom(p => GetPublisherNameAsync(p.PublisherId).Result))
                               .ForMember("AuthorName", opt => opt.MapFrom(a => GetAuthorNameAsync(a.AuthorId).Result));
                cnf.CreateMap<User, NewUserDTO>()
                                .ForMember("UserRole", opt => opt.MapFrom(p => GetUserRoleName(p.ApplicationUserRoleId).Result));
                cnf.CreateMap<NewUserDTO, User>()
                                .ForMember("ApplicationUserRoleId", opt => opt.MapFrom(p => GetUserRoleId(p.UserRole).Result));
            }).CreateMapper();

            _logger.LogInformation("Return mapper");
            return _mapper;
        }

        private async Task<string> GetUserRoleName(Guid applicationUserRoleId)
        {
            var role = await _unit.UserRoleRepository.GetAsync(applicationUserRoleId);

            if (role == default)
            {
                _logger.LogError("User role not found");
                throw new ValidationException("User role not found", "");
            }
            _logger.LogInformation("Return role name");
            return role.RoleName;
        }

        private async Task<Guid> GetUserRoleId(string applicationUserRoleName)
        {
            var roleId = await _unit.UserRoleRepository.GetModelIdAsync(applicationUserRoleName);
            if (roleId == default)
            {
                _logger.LogError("User role not found");
                throw new ValidationException("User role not found", "");
            }
            _logger.LogInformation("Return role id");
            return roleId;
        }

        private async Task<Guid> GetPublisherIdAsync(string publisherName)
        {
            var publisherList = await _unit.PublisherRepository.GetAllAsync();

            foreach (var publisher in publisherList)
            {
                if (publisherName == publisher.PublisherName)
                {
                    _logger.LogInformation("Return publisher id");
                    return publisher.PublisherId;
                }
            }

            var newPublisher = new Publisher
            {
                PublisherName = publisherName
            };

            _unit.PublisherRepository.Add(newPublisher);
            await _unit.SaveChangeAsync();

            var id = await _unit.PublisherRepository.GetModelIdAsync(newPublisher.PublisherName);

            _logger.LogInformation("Create new publisher and return publisher id");
            return id;
        }

        private async Task<Guid> GetAuthorIdAsync(string authorName)
        {
            var authorList = await _unit.AuthorRepository.GetAllAsync();

            foreach (var author in authorList)
            {
                if (authorName == author.AuthorName)
                {
                    _logger.LogInformation("Return author id");
                    return author.AuthorId;
                }
            }

            var newAuthor = new Author()
            {
                AuthorName = authorName
            };

            _unit.AuthorRepository.Add(newAuthor);
            await _unit.SaveChangeAsync();

            var id = await _unit.AuthorRepository.GetModelIdAsync(newAuthor.AuthorName);

            _logger.LogInformation("Create new author and return publisher id");
            return id;
        }

        private async Task<string> GetPublisherNameAsync(Guid publisherId)
        {
            var publisher = await _unit.PublisherRepository.GetAsync(publisherId);

            if (publisher == null)
            {
                _logger.LogError("Publisher not found");
                throw new ValidationException("Publisher not found", "");
            }

            var name = publisher.PublisherName;
            _logger.LogInformation("Return publisher name");
            return name;
        }

        private async Task<string> GetAuthorNameAsync(Guid authorId)
        {
            var author = await _unit.AuthorRepository.GetAsync(authorId);

            if (author == null)
            {
                _logger.LogError("Author not found");
                throw new ValidationException("Author not found", "");
            }

            var name = author.AuthorName;

            _logger.LogInformation("Return author name");
            return name;
        }
    }
}
