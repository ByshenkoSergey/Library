using AutoMapper;
using BLL.DTOModels;
using BLL.Infrastructure.Mapping;
using BLL.Services;
using DAL.Models;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
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

        [SetUp]
        public void Setup()
        {
            _unitMock = new Mock<IUnitOfWork>();
            _repoMock = new Mock<IRepository<Book>>();
            _mapMock = new Mock<IMapConfig>();
        }

        [Test]
        public async Task GetAllBooksFormDTOAsync_map_books_to_booksFormDTO_return_AllBooksFormDTO()
        {
            // Arrange
            _repoMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => GetAllBookTest()));
            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoMock.Object);
            _mapMock.Setup(map => map.GetMapper()).Returns(GetMapTest());
            var bookService = new BookService(_unitMock.Object, _mapMock.Object);

            // Act
            var expected = GetAllBookFormDTOTest();
            var actual = (await bookService.GetAllBooksFormDTOAsync()).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].AuthorName, actual[i].AuthorName);
                    Assert.AreEqual(expected[i].PublisherName, actual[i].PublisherName);
                }
            });
        }


        [Test]
        public async Task GetBookFormDTOAsync_map_books_to_booksFormDTO_return_AllBooksFormDTO()
        {
            // Arrange
            _repoMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => GetAllBookTest()));
            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoMock.Object);
            _mapMock.Setup(map => map.GetMapper()).Returns(GetMapTest());
            var bookService = new BookService(_unitMock.Object, _mapMock.Object);

            // Act
            var expected = GetAllBookFormDTOTest();
            var actual = (await bookService.GetAllBooksFormDTOAsync()).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].AuthorName, actual[i].AuthorName);
                    Assert.AreEqual(expected[i].PublisherName, actual[i].PublisherName);
                }
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
                case var r when (r == new Guid("00000000000000000000000000000011")):
                    authorName = "author1";
                    break;

                case var r when (r == new Guid("00000000000000000000000000000022")):
                    authorName = "author2";
                    break;

                case var r when (r == new Guid("00000000000000000000000000000033")):
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
                case var r when (r == new Guid("00000000000000000000000000000111")):
                    publisherName = "publisher1";
                    break;

                case var r when (r == new Guid("00000000000000000000000000000222")):
                    publisherName = "publisher2";
                    break;

                case var r when (r == new Guid("00000000000000000000000000000333")):
                    publisherName = "publisher3";
                    break;
            }
            return publisherName;

        }
        private IEnumerable<Book> GetAllBookTest()
        {
            var bookList = new List<Book>();

            bookList.Add(new Book
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),
                PublisherId = new Guid("00000000000000000000000000000111"),
                BookName = "book1",
                FilePath = "address1",
                FileType = "text/plain",
                YearOfPublishing = "2001",
                Rating = 1
            });

            bookList.Add(new Book
            {
                BookId = new Guid("00000000000000000000000000000002"),
                AuthorId = new Guid("00000000000000000000000000000022"),
                PublisherId = new Guid("00000000000000000000000000000222"),
                BookName = "book2",
                FilePath = "address2",
                FileType = "text/plain",
                YearOfPublishing = "2002",
                Rating = 2
            });

            bookList.Add(new Book
            {
                BookId = new Guid("00000000000000000000000000000003"),
                AuthorId = new Guid("00000000000000000000000000000033"),
                PublisherId = new Guid("00000000000000000000000000000333"),
                BookName = "book3",
                FilePath = "address3",
                FileType = "text/plain",
                YearOfPublishing = "2003",
                Rating = 3
            });

            return bookList;

        }
        private List<BookFormDTO> GetAllBookFormDTOTest()
        {
            var bookFormDTOList = new List<BookFormDTO>();

            bookFormDTOList.Add(new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),
                PublisherId = new Guid("00000000000000000000000000000111"),
                AuthorName = "author1",
                PublisherName = "publisher1",
                BookName = "book1",
                YearOfPublishing = "2001",
                Rating = 1
            });

            bookFormDTOList.Add(new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000002"),
                AuthorId = new Guid("00000000000000000000000000000022"),
                PublisherId = new Guid("00000000000000000000000000000222"),
                AuthorName = "author2",
                PublisherName = "publisher2",
                BookName = "book2",
                YearOfPublishing = "2002",
                Rating = 2
            });

            bookFormDTOList.Add(new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000003"),
                AuthorId = new Guid("00000000000000000000000000000033"),
                PublisherId = new Guid("00000000000000000000000000000333"),
                AuthorName = "author3",
                PublisherName = "publisher3",
                BookName = "book3",
                YearOfPublishing = "2003",
                Rating = 3
            });

            return bookFormDTOList;
        }
    }
}