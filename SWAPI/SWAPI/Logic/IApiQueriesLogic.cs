using SWAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWAPI.Logic
{
    public interface IApiQueriesLogic
    {
        Task<List<Film>> GetFilms();
        Task<Film> GetFilm(string url);
    }
}