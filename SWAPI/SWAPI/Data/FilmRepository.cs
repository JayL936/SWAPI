using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmContext _context;

        //TODO - separate queries from commands
        public FilmRepository(FilmContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void RateFilm(Vote vote)
        {
            _context.Votes.Add(vote);
        }

        public IQueryable<Vote> GetFilmVotes(int episodeId)
        {
            return _context.Votes.Where(v => v.EpisodeId == episodeId);
        }
    }
}
