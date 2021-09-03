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


    public class ArticlesRepository
    {

        public ArticlesRepository()
        {
        }

        public IEnumerable<Article> GetArticles()
    {
        IEnumerable<Article> articles;

        using (var db = new VidukaFiveNewsContext())
        {
            articles = db.Articles.ToList();
        }

        return articles;
    }

    public IEnumerable<Article> GetArticlesPaged(int page, int pageSize)
    {
        IEnumerable<Article> articles;

        using (var db = new VidukaFiveNewsContext())
        {
            articles = db.Articles.GetPaged(page, pageSize).Results;
        }

        return articles;
    }

    public Article GetArticleById(int id)
    {
        Article article;

        using (var db = new VidukaFiveNewsContext())
        {
            article = db.Articles.Single(x => x.Id == id);
        }

        return article;
    }


    public void PostArticle(Article article)

    {
        using (var db = new VidukaFiveNewsContext())
        {
            db.Articles.Add(article);
            db.SaveChanges();

        }
    }


    public void UpdateArticle(int id, ArticlePostRequest article)
    {
        using (var db = new VidukaFiveNewsContext())

            {
            var unixTimeSeconds = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var articleBefore = db.Articles.Single(x => x.Id == id);
            articleBefore.Title = article.Title;
            articleBefore.Content = article.Content;
            articleBefore.Image = article.Image;
            articleBefore.Date = Convert.ToInt32(unixTimeSeconds);

                db.SaveChanges();
        }
    }


    public void DeleteArticle(int id)
    {
        Article article;

        using (var db = new VidukaFiveNewsContext())
        {
            article = db.Articles.Single(x => x.Id == id);
            db.Articles.Remove(article);

            db.SaveChanges();
        }
    }
}
}