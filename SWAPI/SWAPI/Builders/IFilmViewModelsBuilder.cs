using SWAPI.Models;
using System.Collections.Generic;

namespace SWAPI.Builders
{
    public interface IFilmViewModelsBuilder
    {
        List<FilmListViewModel> GetFilmListViewModels(List<Film> films);
        FilmViewModel GetFilmViewModel(Film film);
    }
}