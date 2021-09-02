using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidukaFiveNews.Models;
using VidukaFiveNews.Repositories;



namespace VidukaFiveNews.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly AuthRepository _authRepository;

        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        // GET: api/values  LOGIN
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var response = _authRepository.Login(loginRequest);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }


        // POST api/values REGISTER
        [HttpPost("register")]
        public ActionResult Register([FromBody] Author author)
        {

            _authRepository.Registration(author);
            return Ok();
        }
    }
}
