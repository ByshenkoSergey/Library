using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.FailData
{
    public class AuthorsData
    {
        public static IEnumerable<Author> GetAuthorsData()
        {
            yield return new Author
            {
                AuthorId = new Guid("94c6f17372ed4e9a89f5d61a611de2dd"),
                AuthorName = "Semenov A.P.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("b41d9e9b80ee4fa5bc261098847f622f"),
                AuthorName = "Fedorov Y.I.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("4d0b7f168ea14d62a63a02fec3a8e0aa"),
                AuthorName = "Ivanov I.P.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("37185335bab64d2fb7b48a454327dc21"),
                AuthorName = "Sidorov S.A.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("f13b3ba052eb474eb9f1cd6857771d98"),
                AuthorName = "Logkin A.Z.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("85691dc67a5649c9b310998acab7f9f4"),
                AuthorName = "Vilkin V.A.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("e2134267118342febe170f7e38973b00"),
                AuthorName = "Petrov P.P.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("fb59938230964f33bc61c18eefb9950f"),
                AuthorName = "Smirnov A.A.",
                AuthorBiography = "...Text...",
            };

            yield return new Author
            {
                AuthorId = new Guid("cf6413aaa9084ce0a0fe4afb4ac0d594"),
                AuthorName = "Pavlov P.A.",
                AuthorBiography = "...Text...",
            };


        }
    }
}