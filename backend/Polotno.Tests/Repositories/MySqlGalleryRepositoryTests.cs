using Microsoft.EntityFrameworkCore;
using Polotno.API.Models;
using Polotno.API.Repositories;

namespace Polotno.Tests.Repositories
{
    [TestFixture]
    public class MySqlGalleryRepositoryTests
    {
        private PolotnoContext _context = null!;
        private MySqlGalleryRepository _repo = null!;

        [SetUp]
        public void SetUp()
        {
            _context = new PolotnoContext
                            (new DbContextOptionsBuilder<PolotnoContext>()
                            .UseInMemoryDatabase(databaseName: "TestDb")
                            .Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();


            var ukrainianRomanticism = new ArtMovement
            {
                MovementId = 1,
                MovementName = "Український романтизм",
                MovementDescription = "1",
            };

            var ukrainianRealism = new ArtMovement
            {
                MovementId = 2,
                MovementName = "Український реалізм",
                MovementDescription = "2",
            };

            var contemporaryArt = new ArtMovement
            {
                MovementId = 3,
                MovementName = "Сучасне українське мистецтво",
                MovementDescription = "3",
            };

            var historicalGenre = new Genre
            {
                GenreId = 1,
                GenreName = "Історичний",
                GenreDescription = "1",
            };

            var genrePainting = new Genre
            {
                GenreId = 2,
                GenreName = "Жанровий",
                GenreDescription = "2",
            };

            var abstractGenre = new Genre
            {
                GenreId = 3,
                GenreName = "Абстрактний",
                GenreDescription = "3",
            };



            var shevchenko = new Artist
            {
                ArtistId = 1,
                FirstName = "Тарас",
                LastName = "Шевченко",
                DateOfBirth = 1814,
                DateOfDeath = 1861,
                Movement = ukrainianRomanticism,
                Genre = historicalGenre,
            };

            var pymonenko = new Artist
            {
                ArtistId = 2,
                FirstName = "Микола",
                LastName = "Пимоненко",
                DateOfBirth = 1844,
                DateOfDeath = 1909,
                Movement = ukrainianRealism,
                Genre = genrePainting,
            };

            var marchuk = new Artist
            {
                ArtistId = 3,
                FirstName = "Іван",
                LastName = "Марчук",
                DateOfBirth = 1936,
                Movement = contemporaryArt,
                Genre = abstractGenre,
            };



            var painting1 = new Painting
            {
                PaintingId = 1,
                PaintingName = "Портрет Шевченка",
                YearCreated = 1840,
                Artist = shevchenko,
                Genre = historicalGenre,
                Style = ukrainianRomanticism
            };

            var painting2 = new Painting
            {
                PaintingId = 2,
                PaintingName = "Жнива",
                YearCreated = 1880,
                Artist = pymonenko,
                Genre = genrePainting,
                Style = ukrainianRealism
            };

            var painting3 = new Painting
            {
                PaintingId = 3,
                PaintingName = "Містика сучасності",
                YearCreated = 1985,
                Artist = marchuk,
                Genre = abstractGenre,
                Style = contemporaryArt
            };

            _context.ArtMovements.AddRange(ukrainianRomanticism, ukrainianRealism, contemporaryArt);
            _context.Genres.AddRange(historicalGenre, genrePainting, abstractGenre);
            _context.Artists.AddRange(shevchenko, pymonenko, marchuk);
            _context.Paintings.AddRange(painting1, painting2, painting3);
            _context.SaveChanges();

            _repo = new MySqlGalleryRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllPaintings_WhenNoFiltersProvided()
        {
            // Act
            var result = await _repo.GetAllAsync();

            // Assert
            result.Should().HaveCount(3);
        }

        [Test]
        public async Task GetAllAsync_FiltersByYearRange()
        {
            // Act
            var result = await _repo.GetAllAsync(1800, 1900);

            // Assert
            result
                .Should().HaveCount(2)
                .And.Subject.Select(p => p.PaintingId).Should().Contain([1, 2]);
        }

        [Test]
        public async Task GetAllAsync_FiltersByPaintingName()
        {
            // Act
            var result = await _repo.GetAllAsync(null, null, "Портрет");

            // Assert
            result
                .Should().HaveCount(1)
                .And.Subject.First().PaintingName.Should().Be("Портрет Шевченка");
        }

        [Test]
        public async Task GetAllAsync_FiltersByMovementName()
        {
            // Act
            var result = await _repo.GetAllAsync(null, null, null, "Український реалізм");

            // Assert
            result
                .Should().HaveCount(1)
                .And.Subject.First().PaintingId.Should().Be(2);
        }

        [Test]
        public async Task GetAllAsync_FiltersByGenreName()
        {
            // Act
            var result = await _repo.GetAllAsync(null, null, null, null, "Жанровий");

            // Assert
            result
                .Should().HaveCount(1)
                .And.Subject.First().PaintingId.Should().Be(2);
        }

        [Test]
        public async Task GetAllAsync_FiltersByMultipleParameters()
        {
            // Act
            var result = await _repo.GetAllAsync(1800, 1900, "Портрет");

            // Assert
            result
                .Should().HaveCount(1)
                .And.Subject.First().PaintingName.Should().Be("Портрет Шевченка");
        }
    }
}