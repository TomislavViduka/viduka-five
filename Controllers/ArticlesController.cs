using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidukaFiveNews.Models;
using VidukaFiveNews.Repositories;

namespace VidukaFiveNews.Controllers
{
   
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {

        private readonly ArticlesRepository _articlesRepository;


        public ArticlesController(ArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }


     
        [HttpGet]
        public ActionResult Get()
        {
            var users = _articlesRepository.GetArticles();
            return Ok(users);
        }


      
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _articlesRepository.GetArticleById(id);
            return Ok(user);
        }


      
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] Article article)
        {
            _articlesRepository.PostArticle(article);
            return Ok();
        }


       
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] ArticlePostRequest article)
        {
            _articlesRepository.UpdateArticle(id, article);
            return Ok();
        }


     
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _articlesRepository.DeleteArticle(id);
            return Ok();
        }
    }
}