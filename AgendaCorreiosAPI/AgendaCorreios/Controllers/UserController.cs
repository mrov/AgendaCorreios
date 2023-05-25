using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs.Output;
using Repository;

namespace AgendaCorreios.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAddressDTO>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAddressDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userRepository.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(id);
            return Ok();
        }

        // GET: Api/User/ExportToXml
        [HttpGet("ExportToXml")]
        public async Task<IActionResult> ExportUsersToXml()
        {
            var xmlBytes = await _userRepository.ExportUsersToXml();

            return File(xmlBytes, "application/xml", "users.xml");
        }
    }
}
