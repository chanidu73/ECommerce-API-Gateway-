using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service= service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetUserById(int id )
        {
            var user = await _service.GetUserByIdAsync(id);
            if(user == null)return NotFound();
            return Ok(user);
        }
        // GET: api/User/username/{username}
        [HttpGet("username/{username}")]
        public async Task<ActionResult<UserModel>> GetUserByUsername(string username)
        {
            var user = await _service.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: api/User/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserModel>> GetUserByEmail(string email)
        {
            var user = await _service.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            try
            {
                await _service.RegisterUserAsync(registerModel);
                return CreatedAtAction(nameof(GetUserByUsername), new { username = registerModel.Username }, registerModel);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _service.DeleteUserAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}