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
using System.IO;
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
        private MapConfig _mapConfig;
        private BookService _bookService;


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

            CreateBookTestFile();
            _booksTestData = GenerateBooksTestData().ToList();
            _publishersTestData = GeneratePublishersTestData().ToList();
            _authorsTestData = GenerateAuthorsTestData().ToList();

            BookMoqSetup();
            AuthorMoqSetup();
            PublisherMoqSetup();
            UnitMoqSetup();

            _mapConfig = new MapConfig(_unitMock.Object, _mapper.Object, _mapLogger.Object);
            _bookService = new BookService(_unitMock.Object, _mapConfig, _bookLogger.Object);
        }

        #region GetAll


        [Test]
        public async Task GetAllBooksFormDTOAsync_map_books_to_booksFormDTO_return_AllBooksFormDTO()
        {
            
            // Act
            var expected = GenerateAllBookFormDTOTest().ToList();
            var actual = (await _bookService.GetAllBooksFormDTOAsync()).ToList();

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
            
            // Act
            var expected = GenerateAllBookFormDTOTest().ToList()[0];
            var actual = await _bookService.GetBookAddDTOAsync(new Guid("00000000000000000000000000000001"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.AuthorName, actual.AuthorName);
                Assert.AreEqual(expected.PublisherName, actual.PublisherName);
                Assert.AreEqual(expected.BookName, actual.BookName);

            });
        }

        #endregion


        [Test]
        public async Task GetBookAddDTOAsync_book_id_false_return_BookAddDTO()
        {
           
            // Act
            var actual = await _bookService.GetBookAddDTOAsync(new Guid("00000000000000000000000000005001"));

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public async Task GetBookFileAsync_book_id_true_return_FileDTO()
        {
            
            // Act
            var actual = await _bookService.GetBookFileAsync(new Guid("00000000000000000000000000000001"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(actual.File);
                Assert.AreEqual(actual.FileName, "book1");
                Assert.AreEqual(actual.FileType, "text/plain");
            });
        }

        [Test]
        public async Task GetBookFileAsync_book_id_fail_return_null()
        {
           
            // Act
            var actual = await _bookService.GetBookFileAsync(new Guid("00000000000000000000000000000321"));

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public async Task GetBookFileAsync_book_path_fail_return_null()
        {
           
            // Act
            var actual = await _bookService.GetBookFileAsync(new Guid("00000000000000000000000000000002"));

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public async Task DeleteBookAsync_book_id_true_count_books_minus_one_book()
        {
            
            // Act
            await _bookService.DeleteBookAsync(new Guid("00000000000000000000000000000001"));
            var bookList = await _bookService.GetAllBooksFormDTOAsync();
            var actual = bookList.Count();

            // Assert
            Assert.AreEqual(actual, 1);
        }

        [Test]
        public async Task AddBookAsync_count_books_plus_one_book()
        {
           
            // Act
            await _bookService.AddBookAsync(GetNewBookDTO());
            var bookList = await _bookService.GetAllBooksFormDTOAsync();
            var actual = bookList.Count();

            // Assert
            Assert.AreEqual(actual, 3);
        }


        [Test]
        public async Task AddBookAsync_newAuthorAndNewPublisher_count_books_plus_one_book_and_one_publisher_and_one_author()
        {
            // Act
            await _bookService.AddBookAsync(GetNewBookDTOWithNewAuthorAndNewPublisher());
            var bookList = await _unitMock.Object.BookRepository.GetAllAsync();
            var authorList = await _unitMock.Object.AuthorRepository.GetAllAsync();
            var publisherList = await _unitMock.Object.PublisherRepository.GetAllAsync();
            

            var actualBookCount = bookList.Count();
            var actualAuthorCount = authorList.Count();
            var actualPublisherCount = publisherList.Count();


            // Assert
            Assert.Multiple(() => {
                Assert.AreEqual(actualBookCount, 3);
                Assert.AreEqual(actualAuthorCount, 3);
                Assert.AreEqual(actualPublisherCount, 3);
            });
            
        }

        [Test]
        public async Task EditBookAsync_newAuthorAndNewPublisher_change_book_and_plus_one_publisher_and_plus_one_author()
        {
            // Act
            await _bookService.EditBookAsync(GetChangeBookDTOWithNewAuthorAndNewPublisher(), new Guid("00000000000000000000000000000001"));
            var bookList = await _unitMock.Object.BookRepository.GetAllAsync();
            var authorList = await _unitMock.Object.AuthorRepository.GetAllAsync();
            var publisherList = await _unitMock.Object.PublisherRepository.GetAllAsync();


            var actualBook = bookList.ToList()[0];
            var actualAuthorCount = authorList.Count();
            var actualPublisherCount = publisherList.Count();


            // Assert
            Assert.Multiple(() => {
                Assert.AreEqual(actualAuthorCount, 3);
                Assert.AreEqual(actualPublisherCount, 3);
                Assert.AreEqual(actualBook.BookId,new Guid("00000000000000000000000000000001"));
                Assert.AreEqual(actualBook.BookName, "book1_change.txt");
                Assert.AreEqual(actualBook.YearOfPublishing, "2022");
            });

        }

        private BookAddDTO GetChangeBookDTOWithNewAuthorAndNewPublisher()
        {
            return new BookAddDTO
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorName = "author3",
                PublisherName = "publisher3",
                BookName = "book1_change",
                FilePath = @"E:\project\Library\API\wwwroot\BookLibrary\BookLibraryTest\book1_change.txt",
                FileType = "text/plain",
                YearOfPublishing = "2022",
            };
        }


            private BookAddDTO GetNewBookDTOWithNewAuthorAndNewPublisher()
        {
            return new BookAddDTO
            {
                BookId = new Guid("00000000000000000000000000000003"),
                AuthorName = "author3",
                PublisherName = "publisher3",
                BookName = "book3",
                FilePath = @"E:\project\Library\API\wwwroot\BookLibrary\BookLibraryTest\book3.txt",
                FileType = "text/plain",
                YearOfPublishing = "2003",
            };
        }

        private BookAddDTO GetNewBookDTO()
        {
            return new BookAddDTO
            {
                BookId = new Guid("00000000000000000000000000000003"),
                AuthorName = "author2",
                PublisherName = "publisher1",
                BookName = "book3",
                FilePath = @"E:\project\Library\API\wwwroot\BookLibrary\BookLibraryTest\book3.txt",
                FileType = "text/plain",
                YearOfPublishing = "2003",
            };
        }

        private IEnumerable<Book> GenerateBooksTestData()
        {
            yield return new Book
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),

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
                FilePath = @"E:\project\Library\API\wwwroot\BookLibrary\BookLibraryTest\book2.txt",
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

        private void CreateBookTestFile()
        {
            string filePath = @"E:\project\Library\API\wwwroot\BookLibrary\BookLibraryTest\book1.txt";

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var sw = new StreamWriter(fs);
                sw.WriteLine("book1 test text...");
            }
        }


       


        private void BookMoqSetup()
        {
            _repoBooksMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Book>)_booksTestData));
            _repoBooksMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000001"))).Returns(Task.Run(() => _booksTestData[0]));
            _repoBooksMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000002"))).Returns(Task.Run(() => _booksTestData[1]));
            _repoBooksMock.Setup(repo => repo.GetModelIdAsync("book1")).Returns(Task.Run(() => _booksTestData[0].BookId));
            _repoBooksMock.Setup(repo => repo.GetModelIdAsync("book2")).Returns(Task.Run(() => _booksTestData[1].BookId));
            _repoBooksMock.Setup(repo => repo.Delete(new Guid("00000000000000000000000000000001"))).Callback<Guid>((id) =>
            {
                Book bookRemove = null;
                foreach (var book in _booksTestData)
                {
                    if (book.BookId == id)
                    {
                        bookRemove = book;
                        break;
                    }
                }
                _booksTestData.Remove(bookRemove);
            });
            _repoBooksMock.Setup(repo => repo.Add(It.IsAny<Book>())).Callback<Book>((book) => _booksTestData.Add(book));
            _repoBooksMock.Setup(repo => repo.Edit(It.IsAny<Book>(), It.IsAny<Guid>())).Callback<Book, Guid>((book, id) => 
            {
                int testId;
                if (id == new Guid("00000000000000000000000000000001"))
                    testId = 0;
                else if (id == new Guid("00000000000000000000000000000002"))
                    testId = 1;
                else
                    throw new ArgumentException("Test book not found");
                _booksTestData.RemoveAt(testId);
                _booksTestData.Insert(testId, book);
                });
        }

       
        private void AuthorMoqSetup()
        {
            _repoAuthorsMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Author>)_authorsTestData));
            _repoAuthorsMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000011"))).Returns(Task.Run(() => _authorsTestData[0]));
            _repoAuthorsMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000022"))).Returns(Task.Run(() => _authorsTestData[1]));
            _repoAuthorsMock.Setup(repo => repo.GetModelIdAsync("author1")).Returns(Task.Run(() => _authorsTestData[0].AuthorId));
            _repoAuthorsMock.Setup(repo => repo.GetModelIdAsync("author2")).Returns(Task.Run(() => _authorsTestData[1].AuthorId));
            _repoAuthorsMock.Setup(repo => repo.GetModelIdAsync("author3")).Returns(Task.Run(() => new Guid("00000000000000000000000000000033")));
            _repoAuthorsMock.Setup(repo => repo.Add(It.IsAny<Author>())).Callback<Author>((author) => _authorsTestData.Add(author));
           
        }

        private void PublisherMoqSetup()
        {
            _repoPublishersMock.Setup(repo => repo.GetAllAsync()).Returns(Task.Run(() => (IEnumerable<Publisher>)_publishersTestData));
            _repoPublishersMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000111"))).Returns(Task.Run(() => _publishersTestData[0]));
            _repoPublishersMock.Setup(repo => repo.GetAsync(new Guid("00000000000000000000000000000222"))).Returns(Task.Run(() => _publishersTestData[1]));
            _repoPublishersMock.Setup(repo => repo.GetModelIdAsync("publisher1")).Returns(Task.Run(() => _publishersTestData[0].PublisherId));
            _repoPublishersMock.Setup(repo => repo.GetModelIdAsync("publisher2")).Returns(Task.Run(() => _publishersTestData[1].PublisherId));
            _repoPublishersMock.Setup(repo => repo.GetModelIdAsync("publisher3")).Returns(Task.Run(() => new Guid("00000000000000000000000000000333")));
            _repoPublishersMock.Setup(repo => repo.Add(It.IsAny<Publisher>())).Callback<Publisher>((publisher) => _publishersTestData.Add(publisher));
        }

        private void UnitMoqSetup()
        {
            _unitMock.Setup(unit => unit.BookRepository).Returns(_repoBooksMock.Object);
            _unitMock.Setup(unit => unit.AuthorRepository).Returns(_repoAuthorsMock.Object);
            _unitMock.Setup(unit => unit.PublisherRepository).Returns(_repoPublishersMock.Object);
        }


    }
}