using AutoMapper;
using BLL.DTOModels;
using BLL.Infrastructure.Mapping;
using BLL.Services;
using DAL.Models;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Test
{
    public class BookServiceTest
    {

        private Mock<IUnitOfWork> _unitMock;
        private Mock<IRepository<Book>> _repoMock;
        private Mock<IMapConfig> _mapMock;
        private Mock<ILogger<BookService>> _loggerMock;
        private List<Book> _booksTestData;


        [SetUp]
        public void Setup()
        {
            _unitMock = new Mock<IUnitOfWork>();
            _repoMock = new Mock<IRepository<Book>>();
            _mapMock = new Mock<IMapConfig>();
            _loggerMock = new Mock<ILogger<BookService>>();
            _booksTestData = GenerateBooksTestData().ToList();
        }

        [Test]
        public async Task GetAllBooksFormDTOAsync_map_books_to_booksFormDTO_return_AllBooksFormDTO()
        {
            // Arrange
            _repoMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Book>)_booksTestData));
            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoMock.Object);
            _mapMock.Setup(map => map.GetMapper()).Returns(GetMapTest());

            var bookService = new BookService(_unitMock.Object, _mapMock.Object, _loggerMock.Object);

            // Act
            var expected = GenerateAllBookFormDTOTest().ToList();
            var actual = (await bookService.GetAllBooksFormDTOAsync()).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].AuthorName, actual[i].AuthorName);
                    Assert.AreEqual(expected[i].PublisherName, actual[i].PublisherName);
                    Assert.AreEqual(expected[i].BookName, actual[i].BookName);
                }
            });
        }

        [Test]
        public async Task GetBookAddDTOAsync_Id_true_return_BookAddDTO()
        {
            // Arrange
            _repoMock.Setup(repo => repo.GetAsync(new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1))).Returns(Task.Run(() => _booksTestData[0]));
            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoMock.Object);
            _mapMock.Setup(map => map.GetMapper()).Returns(GetMapTest());

            var mapConfig = new MapConfig(_unitMock.Object, _mapMock.Object, _loggerMock.Object);
            var bookService = new BookService(_unitMock.Object, _mapMock.Object, _loggerMock.Object);

            // Act
            var expected = GenerateAllBookFormDTOTest().ToList()[0];
            var actual = (await bookService.GetBookAddDTOAsync(new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)));

            // Assert
            Assert.Multiple(() =>
            {
                    Assert.AreEqual(expected.AuthorName, actual.AuthorName);
                    Assert.AreEqual(expected.PublisherName, actual.PublisherName);
                    Assert.AreEqual(expected.BookName, actual.BookName);
                
            });
        }





        private IMapper GetMapTest()
        {
            var _mapper = new MapperConfiguration(cnf =>
            {
                cnf.CreateMap<Book, BookFormDTO>()
                        .ForMember("PublisherName", opt => opt.MapFrom(p => GetPublisherName(p.PublisherId)))
                       .ForMember("AuthorName", opt => opt.MapFrom(a => GetAuthorName(a.AuthorId)));
            }).CreateMapper();
            return _mapper;
        }

        private string GetAuthorName(Guid authorId)
        {

            string authorName = null;
            switch (authorId)
            {
                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11)):
                    authorName = "author1";
                    break;

                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22)):
                    authorName = "author2";
                    break;

                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33)):
                    authorName = "author3";
                    break;
            }
            return authorName;


        }
        private string GetPublisherName(Guid publisherId)
        {

            string publisherName = null;
            switch (publisherId)
            {
                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 111)):
                    publisherName = "publisher1";
                    break;

                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222)):
                    publisherName = "publisher2";
                    break;

                case var r when (r == new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 255)):
                    publisherName = "publisher3";
                    break;
            }
            return publisherName;

        }
        private IEnumerable<Book> GenerateBooksTestData()
        {
            yield return new Book
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 111),
                BookName = "book1",
                FilePath = "address1",
                FileType = "text/plain",
                YearOfPublishing = "2001",
                Rating = 1
            };

            yield return new Book
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222),
                BookName = "book2",
                FilePath = "address2",
                FileType = "text/plain",
                YearOfPublishing = "2002",
                Rating = 2
            };

            yield return new Book
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 255),
                BookName = "book3",
                FilePath = "address3",
                FileType = "text/plain",
                YearOfPublishing = "2003",
                Rating = 3
            };

        }


        private IEnumerable<BookFormDTO> GenerateAllBookFormDTOTest()
        {
            yield return new BookFormDTO
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 111),
                AuthorName = "author1",
                PublisherName = "publisher1",
                BookName = "book1",
                YearOfPublishing = "2001",
                Rating = 1
            };

            yield return new BookFormDTO
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 222),
                AuthorName = "author2",
                PublisherName = "publisher2",
                BookName = "book2",
                YearOfPublishing = "2002",
                Rating = 2
            };

            yield return new BookFormDTO
            {
                BookId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3),
                AuthorId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33),
                PublisherId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 255),
                AuthorName = "author3",
                PublisherName = "publisher3",
                BookName = "book3",
                YearOfPublishing = "2003",
                Rating = 3
            };

        }
    }
}