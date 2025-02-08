using Microsoft.AspNetCore.Mvc;
using Polotno.API.Models;
using Polotno.API.Repositories;
using AutoMapper;
using Polotno.API.DTO;

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

    // GET: /fainoteam/getUserById/{user_id}
    [HttpGet("getUserById/{user_id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int user_id)
    {
        var user = await userRepository.GetByIdAsync(user_id);

        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }
        //Map domain model into UserDto
        var userDto = mapper.Map<UserDto>(user);
        return Ok(userDto);
    }

    // POST: /fainoteam/addUser/
    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser([FromBody] AddRequestUserDto addRequestUserDto)
    {
        //Validation of User state
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(addRequestUserDto.Password))
        {
            return BadRequest(new { message = "Password is required" });
        }

        //Map from addRequestUserDto to Domain model
        var user = mapper.Map<User>(addRequestUserDto);

        user = await userRepository.AddAsync(user);

        // Map domain model into dto
        var userDto = mapper.Map<UserDto>(user);
        return Ok(new { message = "User added successfully", userDto });
    }

    // DELETE: /fainoteam/deleteUserById/{user_id}
    [HttpDelete("deleteUserById/{user_id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] int user_id)
    {
        var user = await userRepository.DeleteAsync(user_id);

        if (user == null)
            return NotFound(new { message = "User not found" });

        return Ok(new { message = "User deleted successfully", user });
    }

    // PUT: /fainoteam/updateUserById/
    [HttpPut("updateUserById")]
    public async Task<IActionResult> UpdateUserById([FromBody] UpdateRequestUserDto updatedUser)
    {
        //Map UpdateRequestUserDto into user
        var user = mapper.Map<User>(updatedUser);
        user = await userRepository.UpdateAsync(user);

        if (user == null)
            return NotFound(new { message = "User not found" });

        //Map domain model into UserDto
        var userDto = mapper.Map<User>(user);
        return Ok(new { message = "User updated successfully", userDto });
    }
}
