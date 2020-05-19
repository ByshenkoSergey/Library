using NUnit.Framework;
using Moq;
using BLL.Services.Interfaces;
using System.Collections;
using BLL.DTOModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Hosting;
using API_Laer;

namespace API.Test
{
    public class BookContrllerTest
    {
        private Mock<IBookService> _moq;
        private Mock<IWebHostEnvironment> _moqHost;

        [SetUp]
        public void Setup()
        {
            _moq = new Mock<IBookService>();
            _moqHost = new Mock<IWebHostEnvironment>();
           
        }

        private IEnumerable<BookFormDTO> GetAllBook()
        {
            yield return new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000001"),
                AuthorId = new Guid("00000000000000000000000000000011"),
                PublisherId = new Guid("00000000000000000000000000000111"),
                AuthorName = "author1",
                PublisherName = "publisher1",
                BookName = "book1",
                BookFileAddress = "address1",
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
                BookFileAddress = "address2",
                YearOfPublishing = "2002",
                Rating = 2
            };

            yield return new BookFormDTO
            {
                BookId = new Guid("00000000000000000000000000000003"),
                AuthorId = new Guid("00000000000000000000000000000033"),
                PublisherId = new Guid("00000000000000000000000000000333"),
                AuthorName = "author3",
                PublisherName = "publisher3",
                BookName = "book3",
                BookFileAddress = "address3",
                YearOfPublishing = "2003",
                Rating = 3
            };
        }

        [Test]
        public void GetAllBookFormDTO_GetAllBook()
        {
            // Arrange
            _moq.Setup(service => service.GetAllBooksFormDTOAsync()).Returns(new Task<IEnumerable<BookFormDTO>>(() => GetAllBook()));
            var bookController = new BookController(_moq.Object, _moqHost.Object);

            // Act
            var result = bookController.GetBooksFormAsync();


            // Assert

            Assert.Pass();
        }
    }
}