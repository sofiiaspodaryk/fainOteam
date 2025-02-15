using Microsoft.AspNetCore.Mvc;
using Polotno.API.Controllers;
using Polotno.API.DTO;
using Polotno.API.Repositories;

namespace Polotno.Tests.Controllers;

[TestFixture]
public class GalleryControllerTests
{
    private Mock<IGalleryRepository> _mockRepo = null!;
    private GalleryController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IGalleryRepository>();
        _controller = new GalleryController(_mockRepo.Object);
    }

    [Test]
    public async Task GetPaintingById_ReturnsOk_WhenPaintingExists()
    {
        // Arrange
        var expectedPainting = new PaintingDto
        {
            PaintingId = 1,
            PaintingName = "Starry Night"
        };

        _mockRepo
            .Setup(repo => repo.GetByIdAsync(expectedPainting.PaintingId))
            .ReturnsAsync(expectedPainting);

        // Act
        var result = await _controller.GetPaintingById(expectedPainting.PaintingId);

        // Assert
        result
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedPainting);
    }

    [Test]
    public async Task GetPaintingById_ReturnsNotFound_WhenPaintingDoesNotExists()
    {
        // Arrange
        int invalidId = -1;
        var expectedMessage = new { message = "Painting not found" };

        _mockRepo
            .Setup(repo => repo.GetByIdAsync(invalidId))
            .ReturnsAsync((PaintingDto?)null);

        // Act
        var result = await _controller.GetPaintingById(invalidId);

        // Assert
        result
            .Should().NotBeNull()
            .And.BeOfType<NotFoundObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedMessage);
    }

    [Test]
    public async Task GetAllPaintings_ReturnsOk_WhenThereArePaintings()
    {
        // Arrange
        var expectedPaintings = new List<PaintingDto> {
            new PaintingDto {
                PaintingId = 1,
                PaintingName = "Starry Night"
            }
        };

        _mockRepo
            .Setup(repo => repo.GetAllAsync(null, null, "Night", null, null))
            .ReturnsAsync(expectedPaintings);

        // Act
        var result = await _controller.GetAllPaintings(null, null, "Night", null, null);

        // Assert
        result
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedPaintings);
    }

    [Test]
    public async Task GetAllPaintings_ReturnsNotFiund_WhenFilteringGivesNoResults()
    {
        List<PaintingDto> EmptyGallery = Enumerable.Empty<PaintingDto>().ToList();

        var expectedMessage = new { message = "Paintings not found" };

        _mockRepo
            .Setup(repo => repo.GetAllAsync(-1, 0, null, null, null))
            .ReturnsAsync(EmptyGallery);

        // Act
        var result = await _controller.GetAllPaintings(-1, 0, null, null, null);

        // Assert
        result
            .Should().NotBeNull()
            .And.BeOfType<NotFoundObjectResult>()
            .Which.Value.Should().BeEquivalentTo(expectedMessage);
    }
}