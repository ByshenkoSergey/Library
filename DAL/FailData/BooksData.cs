using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.FailData
{
    public class BooksData
    {
        private static List<Publisher> publishings = PublisherData.GetPublishersData().ToList();
        private static List<Author> authors = AuthorsData.GetAuthorsData().ToList();

        public static IEnumerable<Book> GetBooksData()
        {
            yield return new Book
            {
                BookId = new Guid("0201e414a27744b3a67334d59d722c5e"),
                BookName = "Black sea",
                FilePath = "BookLibrary/Black sea.txt",
                YearOfPublishing = "2008",
                PublisherId = publishings[1].PublisherId,
                AuthorId = authors[0].AuthorId,
                Rating = 3,
                FileType = "application/octet-stream"
            };

            yield return new Book
            {
                BookId = new Guid("0183e953f44f42c08ccab0475b1f2218"),
                BookName = "Нello cat",
                FilePath = "BookLibrary/Нello cat.txt",
                YearOfPublishing = "2010",
                PublisherId = publishings[3].PublisherId,
                AuthorId = authors[1].AuthorId,
                Rating = 5,
                FileType = "application/octet-stream"
            };

            yield return new Book
            {
                BookId = new Guid("93345979d3c9425590ef541a8f937a73"),
                BookName = "Black dog",
                FilePath = "BookLibrary/Black dog.txt",
                YearOfPublishing = "2001",
                PublisherId = publishings[2].PublisherId,
                AuthorId = authors[2].AuthorId,
                Rating = 0,
                FileType = "application/octet-stream"

            };

            yield return new Book
            {
                BookId = new Guid("57c42200905e44cf982f7a70fb8d04ff"),
                BookName = "Happy bird",
                FilePath = "BookLibrary/Happy bird.txt",
                YearOfPublishing = "1994",
                PublisherId = publishings[0].PublisherId,
                AuthorId = authors[3].AuthorId,
                Rating = 2,
                FileType = "application/octet-stream"
            };

            yield return new Book
            {
                BookId = new Guid("fd5dd7628765412b83a7c02a27ed858a"),
                BookName = "Little snake",
                FilePath = "BookLibrary/Little snake.txt",
                YearOfPublishing = "2009",
                PublisherId = publishings[2].PublisherId,
                AuthorId = authors[4].AuthorId,
                Rating = 5,
                FileType = "application/octet-stream"

            };

            yield return new Book
            {
                BookId = new Guid("dd0957942af34845b2ee51ab0c151e2c"),
                BookName = "Merry",
                FilePath = "BookLibrary/Merry.txt",
                YearOfPublishing = "2012",
                PublisherId = publishings[0].PublisherId,
                AuthorId = authors[5].AuthorId,
                Rating = 4,
                FileType = "application/octet-stream"
            };

            yield return new Book
            {
                BookId = new Guid("b9c9bcfc2c3747188e16978f06359f43"),
                BookName = "New spring",
                FilePath = "BookLibrary/New spring.txt",
                YearOfPublishing = "2005",
                PublisherId = publishings[3].PublisherId,
                AuthorId = authors[6].AuthorId,
                Rating = 4,
                FileType = "application/octet-stream"

            };

            yield return new Book
            {
                BookId = new Guid("166fd39a0f804efd80bfd7907492222b"),
                BookName = "Square World",
                FilePath = "BookLibrary/Square World.txt",
                YearOfPublishing = "2015",
                PublisherId = publishings[1].PublisherId,
                AuthorId = authors[7].AuthorId,
                Rating = 5,
                FileType = "application/octet-stream"
            };



        }
    }
}