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
   
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {

        private readonly ArticlesRepository _articlesRepository;


        public ArticlesController(ArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }


        // GET: api/users
        [HttpGet]
        public ActionResult Get()
        {
            var users = _articlesRepository.GetArticles();
            return Ok(users);
        }


        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _articlesRepository.GetArticleById(id);
            return Ok(user);
        }


        // POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            _articlesRepository.PostArticle(article);
            return Ok();
        }


        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Article article)
        {
            _articlesRepository.UpdateArticle(id, article);
            return Ok();
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            _articlesRepository.DeleteArticle(id);
            return Ok();
        }
    }
}