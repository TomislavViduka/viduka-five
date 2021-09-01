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

    public IEnumerable<Author> GetAuthorsPaged(int page, int pageSize)
    {
        IEnumerable<Author> authors;

        using (var db = new VidukaFiveNewsContext())
        {
            authors = db.Authors.GetPaged(page, pageSize).Results;
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


    public void PostAuthor(Author author)
    {
        using (var db = new VidukaFiveNewsContext())
        {
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