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
    public class AuthorsController : Controller
    {

        private readonly AuthorsRepository _authorsRepository;


        public AuthorsController(AuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }


        // GET: api/users
        [HttpGet]
        public ActionResult Get()
        {
            var users = _authorsRepository.GetAuthors();
            return Ok(users);
        }


        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _authorsRepository.GetAuthorById(id);
            return Ok(user);
        }


        // POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            _authorsRepository.PostAuthor(author);
            return Ok();
        }


        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            _authorsRepository.UpdateAuthor(id, author);
            return Ok();
        }


        // DELETE api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            _authorsRepository.DeleteAuthor(id);
            return Ok();
        }
    }
}