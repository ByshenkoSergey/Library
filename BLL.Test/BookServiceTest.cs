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
        private Mock<IRepository<Book>> _repoBooksMock;
        private Mock<IRepository<Author>> _repoAuthorsMock;
        private Mock<IRepository<Publisher>> _repoPublishersMock;
        private Mock<ILogger<BookService>> _bookLogger;
        private Mock<ILogger<MapConfig>> _mapLogger;
        private Mock<IMapper> _mapper;
        private List<Book> _booksTestData;
        private List<Publisher> _publishersTestData;
        private List<Author> _authorsTestData;
        

        [SetUp]
        public void Setup()
        {
            _unitMock = new Mock<IUnitOfWork>();
            _repoBooksMock = new Mock<IRepository<Book>>();
            _repoAuthorsMock = new Mock<IRepository<Author>>();
            _repoPublishersMock = new Mock<IRepository<Publisher>>();
            _bookLogger = new Mock<ILogger<BookService>>();
            _mapLogger = new Mock<ILogger<MapConfig>>();
            _mapper = new Mock<IMapper>();

            _booksTestData = GenerateBooksTestData().ToList();
            _publishersTestData = GeneratePublishersTestData().ToList();
            _authorsTestData = GenerateAuthorsTestData().ToList();

            _repoBooksMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Book>)_booksTestData));
            _repoBooksMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000001"))).Returns(Task.Run(() => _booksTestData[0]));
            _repoBooksMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000002"))).Returns(Task.Run(() => _booksTestData[1]));
            _repoBooksMock.Setup(repo => repo.GetModelIdAsync("book1")).Returns(Task.Run(() => _booksTestData[0].BookId));
            _repoBooksMock.Setup(repo => repo.GetModelIdAsync("book2")).Returns(Task.Run(() => _booksTestData[1].BookId));

            _repoAuthorsMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Author>)_authorsTestData));
            _repoAuthorsMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000011"))).Returns(Task.Run(() => _authorsTestData[0]));
            _repoAuthorsMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000022"))).Returns(Task.Run(() => _authorsTestData[1]));
            _repoAuthorsMock.Setup(repo => repo.GetModelIdAsync("author1")).Returns(Task.Run(() => _authorsTestData[0].AuthorId));
            _repoAuthorsMock.Setup(repo => repo.GetModelIdAsync("author2")).Returns(Task.Run(() => _authorsTestData[1].AuthorId));

            _repoPublishersMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Publisher>)_publishersTestData));
            _repoPublishersMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000111"))).Returns(Task.Run(() => _publishersTestData[0]));
            _repoPublishersMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000222"))).Returns(Task.Run(() => _publishersTestData[1]));
            _repoPublishersMock.Setup(repo => repo.GetModelIdAsync("publisher1")).Returns(Task.Run(() => _publishersTestData[0].PublisherId));
            _repoPublishersMock.Setup(repo => repo.GetModelIdAsync("publisher2")).Returns(Task.Run(() => _publishersTestData[1].PublisherId));

            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoBooksMock.Object);
            _unitMock.Setup(unit => unit.AuthorRepository).Returns(_repoAuthorsMock.Object);
            _unitMock.Setup(unit => unit.PublisherRepository).Returns(_repoPublishersMock.Object);
        }



        [Test]
        public async Task GetAllBooksFormDTOAsync_map_books_to_booksFormDTO_return_AllBooksFormDTO()
        {
            // Arrange
            var mapper = new MapConfig(_unitMock.Object, _mapper.Object, _mapLogger.Object);
            var bookService = new BookService(_unitMock.Object, mapper, _bookLogger.Object);

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
        public async Task GetBookAddDTOAsync_book_id_true_return_BookAddDTO()
        {
            // Arrange
            var mapper = new MapConfig(_unitMock.Object, _mapper.Object, _mapLogger.Object);
            var bookService = new BookService(_unitMock.Object, mapper, _bookLogger.Object);

            // Act
            var expected = GenerateAllBookFormDTOTest().ToList()[0];
            var actual = await bookService.GetBookAddDTOAsync(new Guid("00000000000000000000000000000001"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.AuthorName, actual.AuthorName);
                Assert.AreEqual(expected.PublisherName, actual.PublisherName);
                Assert.AreEqual(expected.BookName, actual.BookName);
            
            });
        }

        [Test]
        public async Task GetBookAddDTOAsync_book_id_false_return_BookAddDTO()
        {
            // Arrange
            var mapper = new MapConfig(_unitMock.Object, _mapper.Object, _mapLogger.Object);
            var bookService = new BookService(_unitMock.Object, mapper, _bookLogger.Object);

            // Act
           var actual = await bookService.GetBookAddDTOAsync(new Guid("00000000000000000000000000005001"));

            // Assert
            Assert.IsNull(actual);
        }






        private IEnumerable<Book> GenerateBooksTestData()
        {
            yield return new Book
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),
                PublisherId = new Guid("00000000000000000000000000000111"),
                BookName = "book1",
                FilePath = "address1",
                FileType = "text/plain",
                YearOfPublishing = "2001",
                Rating = 1
            };

            yield return new Book
            {
                BookId = new Guid("00000000000000000000000000000002"),
                AuthorId = new Guid("00000000000000000000000000000022"),
                PublisherId = new Guid("00000000000000000000000000000222"),
                BookName = "book2",
                FilePath = "address2",
                FileType = "text/plain",
                YearOfPublishing = "2002",
                Rating = 2
            };

        }


        private IEnumerable<BookFormDTO> GenerateAllBookFormDTOTest()
        {
            yield return new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),
                PublisherId = new Guid("00000000000000000000000000000111"),
                AuthorName = "author1",
                PublisherName = "publisher1",
                BookName = "book1",
                YearOfPublishing = "2001",
                Rating = 1
            };

            yield return new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000002"),
                AuthorId = new Guid("00000000000000000000000000000022"),
                PublisherId = new Guid("00000000000000000000000000000222"),
                AuthorName = "author2",
                PublisherName = "publisher2",
                BookName = "book2",
                YearOfPublishing = "2002",
                Rating = 2
            };
                       
        }

        private IEnumerable<Author> GenerateAuthorsTestData()
        {
            yield return new Author
            {
                AuthorName = "author1",
                AuthorBiography = "biography1",
                AuthorId = new Guid("00000000000000000000000000000011")
            };

            yield return new Author
            {
                AuthorName = "author2",
                AuthorBiography = "biography2",
                AuthorId = new Guid("00000000000000000000000000000022")
            };
                      
        }

        private IEnumerable<Publisher> GeneratePublishersTestData()
        {
            yield return new Publisher
            {
                PublisherName = "publisher1",
                PublisherId = new Guid("00000000000000000000000000000111"),
                PublisherInfo = "publisherInfo1",
                PublisherEmail = "email1",
                PublisherTellNumber = "tell1"
            };

            yield return new Publisher
            {
                PublisherName = "publisher2",
                PublisherId = new Guid("00000000000000000000000000000222"),
                PublisherInfo = "publisherInfo2",
                PublisherEmail = "email2",
                PublisherTellNumber = "tell2"
            };
          
        }
    }
}