using Microsoft.AspNetCore.Mvc;
using Polotno.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Polotno.API.Controllers;

[ApiController]
[Route("fainoteam")]
public class UserController : ControllerBase
{
    private readonly PolotnoContext _context;

    public UserController(PolotnoContext context)
    {
        _context = context;
    }

    // GET: /fainoteam/getUserById/{user_id}
    [HttpGet("getUserById/{user_id}")]
    public async Task<IActionResult> GetUserById(int user_id)
    {
        var user = await _context.Users
            .Where(u => u.UserId == user_id)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        return Ok(new
        {
            user_id = user.UserId,
            username = user.Username,
            email = user.Email,
            password_hash = user.PasswordHash,
            created_at = user.CreatedAt
        });
    }

    // POST: /fainoteam/addUser/
    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(user.PasswordHash))
        {
            return BadRequest(new { message = "PasswordHash is required" });
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "User added successfully",
            user_id = user.UserId
        });
    }

    // DELETE: /fainoteam/deleteUserById/{user_id}
    [HttpDelete("deleteUserById/{user_id}")]
    public async Task<IActionResult> DeleteUserById(int user_id)
    {
        var user = await _context.Users.FindAsync(user_id);
        if (user == null)
            return NotFound(new { message = "User not found" });

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User deleted successfully" });
    }

    // PUT: /fainoteam/updateUserById/
    [HttpPut("updateUserById")]
    public async Task<IActionResult> UpdateUserById([FromBody] User updatedUser)
    {
        var user = await _context.Users.FindAsync(updatedUser.UserId);
        if (user == null)
            return NotFound(new { message = "User not found" });

        user.Username = updatedUser.Username;
        user.Email = updatedUser.Email;
        user.PasswordHash = updatedUser.PasswordHash;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User updated successfully" });
    }
}
