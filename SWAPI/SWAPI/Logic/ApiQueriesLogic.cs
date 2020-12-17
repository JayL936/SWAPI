using Newtonsoft.Json;
using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWAPI.Logic
{
    public class ApiQueriesLogic : IApiQueriesLogic
    {
        private IHttpClientFactory _httpClientFactory;

        public ApiQueriesLogic(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Film> GetFilm(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<Film>(responseStream);
                return apiResponse;
            }
            else
            {
                //log error
            }


            return null;
        }

        public async Task<List<Film>> GetFilms()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://swapi.dev/api/films/");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<APIListResponse>(responseStream);
                return apiResponse.Results;
            }
            else
            {
                //log error
            }


            return new List<Film>();
        }
    }
}
