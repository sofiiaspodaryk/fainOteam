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
}