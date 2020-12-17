using SWAPI.Data;
using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Logic
{
    public class RatingLogic : IRatingLogic
    {
        private readonly IFilmRepository _repository;

        public RatingLogic(IFilmRepository repository)
        {
            _repository = repository;
        }

        public bool RateFilm(int id, int score)
        {
            //possible validation i.e. if film exists

            var vote = new Vote
            {
                EpisodeId = id,
                Score = score
            };

            _repository.RateFilm(vote);
            _repository.SaveChanges();

            return true;
        }
    }
}
