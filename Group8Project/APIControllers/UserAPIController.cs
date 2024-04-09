// Author: Sebastian Villafane Ramos
// Description: API Controller for the User Entity

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

        // GET: api/UserAPI/{id}
        [HttpGet("{id}")]
        public ActionResult<Models.User> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }

            var user = _userRepository.GetUserById(id);

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
            });

        [HttpPut]
        public Models.User Put([FromBody] Models.User user) =>
            _userRepository.UpdateUser(user);

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.removeUser(id);
        }

    }

}
