using Moq;
using NUnit.Framework;
using SWAPI.Builders;
using SWAPI.Data;
using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAPI_Tests
{
    class BuilderTests
    {
        private Mock<IFilmRepository> _repository;

        private FilmViewModelsBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IFilmRepository>();
            _builder = new FilmViewModelsBuilder(_repository.Object);
        }

        [Test]
        public void GetFilmViewModel_Should_Set_Correct_VotesCount_And_Score()
        {
            var film = new Film();
            var votes = new List<Vote>
            {
                new Vote
                {
                    Score = 5
                },
                new Vote
                {
                    Score = 10
                }
            };

            _repository.Setup(r => r.GetFilmVotes(It.IsAny<int>())).Returns(votes.AsQueryable());

            var result = _builder.GetFilmViewModel(film);

            Assert.AreEqual(2, result.Votes);
            Assert.AreEqual(votes.Average(v => v.Score), result.Score);
        }

        [Test]
        public void GetFilmViewModel_Should_Not_Throw_When_Film_Is_Null()
        {
            Assert.DoesNotThrow(() => _builder.GetFilmViewModel(null));
        }
    }
}
