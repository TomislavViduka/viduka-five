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
    public class AuthorsController : Controller
    {

        private readonly AuthorsRepository _authorsRepository;


        public AuthorsController(AuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }


        [HttpGet]
        public ActionResult Get()
        {
            var users = _authorsRepository.GetAuthors();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _authorsRepository.GetAuthorById(id);
            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult Post([FromBody] AuthorPostRequest author)
        {
            //_authorsRepository.PostAuthor(author);
            //return Ok();



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {

                _authorsRepository.PostAuthor(author);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            _authorsRepository.UpdateAuthor(id, author);
            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            _authorsRepository.DeleteAuthor(id);
            return Ok();
        }
    }
}