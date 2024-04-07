using Microsoft.AspNetCore.Mvc;
using Group8Project.Models;
using System.Collections.Generic;

namespace Group8Project.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/UserAPI
        [HttpGet]
        public IEnumerable<Models.User> Get() => _userRepository.Users;

        // GET: api/UserAPI/{email}
        [HttpGet("{email}")]
        public ActionResult<Models.User> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email.ToString()))
            {
                return BadRequest("Email cannot be null or empty.");
            }

            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        public Models.User Post([FromBody] Models.User user) =>
            _userRepository.addUser(new Models.User
            {
                FName = user.FName,
                LName = user.LName,
                Email = user.Email,
                PNumber = user.PNumber,
                Password = user.Password,
                RePassword = user.RePassword
            });

        [HttpPut]
        public Models.User Put([FromBody] Models.User user) =>
            _userRepository.UpdateUser(user);

        [HttpDelete("{email}")]
        public void Delete(string email)
        {
            _userRepository.removeUser(email);
        }

    }

}
