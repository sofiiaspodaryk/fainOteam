using Microsoft.AspNetCore.Mvc;
using Polotno.API.Models;
using Polotno.API.Repositories;
using AutoMapper;
using Polotno.API.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Polotno.API.Controllers;

[ApiController]
[Route("fainoteam")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    // GET: /fainoteam/users/{id}
    [Authorize]
    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
            return NotFound(new { message = "User not found." });

        //Map domain model into UserDto
        var userDto = mapper.Map<UserDto>(user);
        return Ok(userDto);
    }

    // POST: /fainoteam/users/
    [HttpPost("users")]
    public async Task<IActionResult> AddUser([FromBody] UserRequestDto addRequestUserDto)
    {
        //Validation of User state
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //Map from UserRequestDto to Domain model
        var user = mapper.Map<User>(addRequestUserDto);

        user = await userRepository.AddAsync(user);

        // Map domain model into dto
        var userDto = mapper.Map<UserDto>(user);
        return Ok(new { message = "User added successfully", userDto });
    }

    // DELETE: /fainoteam/users/{id}
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] int id)
    {
        var user = await userRepository.DeleteAsync(id);

        if (user == null)
            return NotFound(new { message = "User not found" });

        return Ok(new { message = "User deleted successfully", user });
    }

    // PUT: /fainoteam/users/{id}
    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUserById([FromRoute] int id, [FromBody] UserRequestDto updatedUser)
    {
        var existingUser = await userRepository.GetByIdAsync(id);
        if (existingUser == null)
            return NotFound(new { message = "User not found" });

        //Update existing model
        mapper.Map(updatedUser, existingUser);
        var updatedEntity = await userRepository.UpdateAsync(existingUser);

        // Map domain model into dto
        var userDto = mapper.Map<UserDto>(updatedEntity);
        return Ok(new { message = "User updated successfully", userDto });
    }
}
