using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milestone05_WebAPI.Data;
using Milestone05_WebAPI.DTOs;
using Milestone05_WebAPI.Models;
using Milestone05_WebAPI.Security;

namespace Milestone05_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly LibraryDbContext _db;

        public UsersController(LibraryDbContext db)
        {
            _db = db;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(
            UserRegisterDto dto)
        {
            string username = dto.Username.Trim();

            bool exists = await _db.Users.AnyAsync(
                u => u.Username.ToLower() == username.ToLower());

            if (exists)
            {
                return Conflict("Username already exists.");
            }

            User user = new User
            {
                Username = username,
                PasswordHash = PasswordHasher.HashPassword(dto.Password)
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            UserResponseDto result = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return Created($"/api/Users/{user.Id}", result);
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login(
            UserLoginDto dto)
        {
            string username = dto.Username.Trim();

            User? user = await _db.Users.FirstOrDefaultAsync(
                u => u.Username.ToLower() == username.ToLower());

            if (user == null ||
                !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            UserResponseDto result = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(result);
        }
    }
}