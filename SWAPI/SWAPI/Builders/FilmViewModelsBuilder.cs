using SWAPI.Data;
using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Builders
{
    public class FilmViewModelsBuilder : IFilmViewModelsBuilder
    {
        private readonly IFilmRepository _repository;

        public FilmViewModelsBuilder(IFilmRepository repository)
        {
            _repository = repository;
        }

        public List<FilmListViewModel> GetFilmListViewModels(List<Film> films)
        {
            if (films == null || !films.Any())
                return new List<FilmListViewModel>();

            var viewModels = films.Select(f => new FilmListViewModel(f)).ToList();
            return viewModels;
        }

        public FilmViewModel GetFilmViewModel(Film film)
        {
            if (film == null)
                return null;

            var filmVotes = _repository.GetFilmVotes(film.EpisodeId).ToList();
            var filmScore =  filmVotes.Any() ? (float) filmVotes.Average(f => f.Score) : 0;
            var viewModel = new FilmViewModel(film)
            {
                Score = filmScore,
                Votes = filmVotes.Count(),
            };

            return viewModel;
        }
    }
}
