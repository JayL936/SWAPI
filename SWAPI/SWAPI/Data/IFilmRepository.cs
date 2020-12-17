using SWAPI.Models;
using System.Linq;

namespace SWAPI.Data
{
    public interface IFilmRepository
    {
        IQueryable<Vote> GetFilmVotes(int episodeId);
        void RateFilm(Vote vote);
        void SaveChanges();
    }
}