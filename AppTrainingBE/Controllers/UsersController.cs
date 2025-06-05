using AppTrainingBE.Context;
using AppTrainingBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppTrainingBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //api/users
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Include(u => u.Profile)
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser
            (int id, [FromBody] User updateUser)
        {
            var existingUser = await _context.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
                return NotFound();

            //Actualizar los datos
            existingUser.UserName = updateUser.UserName;
            existingUser.Profile.FullName = updateUser.Profile.FullName;
            existingUser.Profile.DateOfBirth = updateUser.Profile.DateOfBirth;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
