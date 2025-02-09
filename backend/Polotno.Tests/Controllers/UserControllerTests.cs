using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polotno.API.Controllers;
using Polotno.API.DTO;
using Polotno.API.Models;
using Polotno.API.Repositories;

namespace Polotno.Tests.Controllers;

[TestFixture]
public class UserControllerTests
{
    private Mock<IUserRepository> _mockRepo = null!;
    private Mock<IMapper> _mockMapper = null!;
    private UserController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new UserController(_mockRepo.Object, _mockMapper.Object);
    }

    [Test]
    public async Task GetUserById_ReturnsOk_WhenUserExists()
    {
        // Arrange
        int validId = 1;

        var existingUser = new User { UserId = validId, Username = "Tester" };
        var expectedDto = new UserDto { UserId = validId, Username = "Tester" };

        _mockRepo
            .Setup(repo => repo.GetByIdAsync(validId))
            .ReturnsAsync(existingUser);

        _mockMapper
            .Setup(mapper => mapper.Map<UserDto>(existingUser))
            .Returns(expectedDto);

        // Act
        var result = await _controller.GetUserById(validId);

        // Assert
        result
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.As<UserDto>().Should().BeEquivalentTo(expectedDto);
    }

    [Test]
    public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        int invalidId = -1;
        var expectedMessage = new { message = "User not found." };

        _mockRepo
            .Setup(repo => repo.GetByIdAsync(invalidId))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _controller.GetUserById(invalidId);

        // Assert
        result
            .Should().BeOfType<NotFoundObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedMessage);
    }

    [Test]
    public async Task AddUser_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var validDto = new AddRequestUserDto
        {
            Username = "testuser",
            Email = "example@gmail.com",
            Password = "123456789"
        };

        _controller.ModelState.AddModelError("Password", "Password is required");

        // Act
        var result = await _controller.AddUser(validDto);

        // Assert
        result
            .Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().BeOfType<SerializableError>();
    }

    [Test]
    public async Task AddUser_ReturnsOk_WhenModelStateIsValid()
    {
        // Arrange
        var validRequestDto = new AddRequestUserDto
        {
            Username = "testuser",
            Email = "example@gmail.com",
            Password = "123456789"
        };

        var user = new User
        {
            Username = validRequestDto.Username,
            Email = validRequestDto.Email,
            PasswordHash = validRequestDto.Password
        };

        var userDto = new UserDto
        {
            Username = validRequestDto.Username,
            Email = validRequestDto.Email
        };

        var expectedMessage = new { message = "User added successfully", userDto };

        _mockMapper
            .Setup(map => map.Map<User>(validRequestDto))
            .Returns(user);

        _mockRepo
            .Setup(repo => repo.AddAsync(user))
            .ReturnsAsync(user);

        _mockMapper
            .Setup(map => map.Map<UserDto>(user))
            .Returns(userDto);

        // Act
        var result = await _controller.AddUser(validRequestDto);

        // Assert
        result
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedMessage);
    }

    [Test]
    public async Task DeleteUserById_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        int invalidId = -1;
        var expectedMessage = new { message = "User not found" };

        _mockRepo
            .Setup(repo => repo.DeleteAsync(invalidId))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _controller.DeleteUserById(invalidId);

        // Assert
        result
            .Should().BeOfType<NotFoundObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedMessage);
    }

    [Test]
    public async Task DeleteUserById_ReturnsOk_WhenUserIsDeleted()
    {
        // Arrange
        int userId = 1;
        var user = new User { UserId = userId, Username = "Tester" };
        var expectedResponse = new { message = "User deleted successfully", user };

        _mockRepo
            .Setup(repo => repo.DeleteAsync(userId))
            .ReturnsAsync(user);

        // Act
        var result = await _controller.DeleteUserById(userId);

        // Assert
        result
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedResponse);
    }

}