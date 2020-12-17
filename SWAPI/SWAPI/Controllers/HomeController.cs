using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWAPI.Builders;
using SWAPI.Logic;
using SWAPI.Models;

namespace SWAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiQueriesLogic _apiQueries;
        private readonly IFilmViewModelsBuilder _filmViewModelsBuilder;
        private readonly IRatingLogic _ratingLogic;

        public HomeController(ILogger<HomeController> logger, IApiQueriesLogic apiQueries, IFilmViewModelsBuilder filmViewModelsBuilder, IRatingLogic ratingLogic)
        {
            _logger = logger;
            _apiQueries = apiQueries;
            _filmViewModelsBuilder = filmViewModelsBuilder;
            _ratingLogic = ratingLogic;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _apiQueries.GetFilms();
            var list = _filmViewModelsBuilder.GetFilmListViewModels(movies);

            return View(list);
        }

        public async Task<IActionResult> Details(string url)
        {
            if (url == null || url == string.Empty)
                RedirectToAction("Error");

            var film = await _apiQueries.GetFilm(url);
            if (film == null)
                return RedirectToAction("Error");

            var filmViewModel = _filmViewModelsBuilder.GetFilmViewModel(film);

            return View(filmViewModel);
        }

        public IActionResult Rate(int id, int score)
        {
            if (id <= 0 || score <= 0)
                RedirectToAction("Error");

            var success = _ratingLogic.RateFilm(id, score);

            return new JsonResult(success);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
