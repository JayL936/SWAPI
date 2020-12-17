using Moq;
using NUnit.Framework;
using SWAPI.Data;
using SWAPI.Logic;
using SWAPI.Models;

namespace SWAPI_Tests
{
    public class Tests
    {
        private Mock<IFilmRepository> _repository;
        private RatingLogic _logic;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IFilmRepository>();
            _logic = new RatingLogic(_repository.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _repository.Invocations.Clear();
        }

        [Test]
        public void RateFilm_Should_Save_Passed_Rating()
        {
            var success = _logic.RateFilm(1, 5);

            Assert.True(success);
            _repository.Verify(r => r.RateFilm(It.Is<Vote>(v => v.EpisodeId == 1 && v.Score == 5)), Times.Once);
            _repository.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}