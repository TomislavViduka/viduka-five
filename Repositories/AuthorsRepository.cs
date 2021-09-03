using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using VidukaFiveNews.Extensions;
using System.IO;
using VidukaFiveNews.Models;

namespace VidukaFiveNews.Repositories
{


    public class AuthorsRepository
    {

        public AuthorsRepository()
        {
        }

        public IEnumerable<Author> GetAuthors()
    {
        IEnumerable<Author> authors;

        using (var db = new VidukaFiveNewsContext())
        {
            authors = db.Authors.ToList();
        }

        return authors;
    }



    public Author GetAuthorById(int id)
    {
        Author author;

        using (var db = new VidukaFiveNewsContext())
        {
            author = db.Authors.Single(x => x.Id == id);
        }

        return author;
    }

        /// <summary>
        /// Creates a new instance of Author in DB
        /// </summary>
        /// <param name="author"></param>
        public void PostAuthor(AuthorPostRequest authorPost)
        {
            Author author = new Author();
            using (var db = new VidukaFiveNewsContext())
        {
                author.Name = authorPost.Name;
                author.Email = authorPost.Email;
                author.Password = BCrypt.Net.BCrypt.HashPassword(authorPost.Password);
                db.Authors.Add(author);
                db.SaveChanges();

        }
    }




        public void UpdateAuthor(int id, Author author)
    {
        using (var db = new VidukaFiveNewsContext())
        {
            var authorBefore = db.Authors.Single(x => x.Id == id);
            authorBefore.Name = author.Name;
            authorBefore.Email = author.Email;

            db.SaveChanges();
        }
    }


    public void DeleteAuthor(int id)
    {
        Author author;

        using (var db = new VidukaFiveNewsContext())
        {
            author = db.Authors.Single(x => x.Id == id);
            db.Authors.Remove(author);

            db.SaveChanges();
        }
    }
}
}