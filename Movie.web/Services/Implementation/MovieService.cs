using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Movie.web.Models;
using System.Net.Http;
using Movie.web.Common;
using Movie.web.Models.reqres;
using Newtonsoft.Json;

namespace Movie.web.Services.Implementation
{
    public class MovieService : IMovieService
    {

        public async Task<ResponseCarrier> GetMovieDetail(string movieId)
        {
            ResponseCarrier response;
            string getMovieDetail = string.Format(MovieConfig.WebAPIUrl, "cinemaworld", "movie") + "/" + movieId;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(MovieConfig.RequesetHeader1Key, MovieConfig.RequestHeader1Value);
                var result = await client.GetAsync((getMovieDetail));
                if (result.IsSuccessStatusCode)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<MovieModel>(responseStr);
                    response = new ResponseCarrier() { Status = true, PayLoad = data, ErrorMessage = string.Empty };
                }
                else
                {
                    response = new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Error in fetching movie list from API" };
                }
            }
            return response;
        }

        public async Task<MoviesCollection> GetAllMovieList()
        {
            MoviesCollection mCollection = null;
            string getMovieListUri = string.Format(MovieConfig.WebAPIUrl, "cinemaworld", "movies");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(MovieConfig.RequesetHeader1Key, MovieConfig.RequestHeader1Value);
                var result = await client.GetAsync((getMovieListUri));
                if (result.IsSuccessStatusCode)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    mCollection = JsonConvert.DeserializeObject<MoviesCollection>(responseStr);
                }
            }
            return mCollection;
        }

        public async Task<ResponseCarrier> GetMovieListDetail(ICacheService cacheService)
        {
            try
            {
                if (!cacheService.IsCached("moviedata"))
                {
                    var allMovie = await GetAllMovieList();
                    MoviesCollection mCollection = allMovie as MoviesCollection;
                    if (mCollection != null && mCollection.Movies != null && mCollection.Movies.Count > 0)
                    {
                        List<string> movieList = new List<string>();
                        foreach (BaseMovieModel mModel in mCollection.Movies)
                        {
                            movieList.Add(mModel.ID);
                        }
                        cacheService.WriteCache("moviedata", movieList, MovieConfig.CacheExpirationMinute);
                    }
                }
                List<string> mlist = cacheService.ReadCache<object>("moviedata") as List<string>;
                if (mlist != null)
                {
                    List<MovieModel> result = new List<MovieModel>();
                    if (mlist != null)
                    {
                        var tasks = mlist.Select(i => GetMovieDetail(i));
                        var mColl = await Task.WhenAll(tasks);
                        //var mColl = await Task.WhenAll(mlist.Select(i => result.Add(GetMovieDetail(i))));
                        foreach (ResponseCarrier res in mColl)
                        {
                            result.Add((MovieModel)res.PayLoad);
                        }
                        //result = SortMovieList(result, order, category, orderBy);
                        return new ResponseCarrier() { Status = true, PayLoad = result, ErrorMessage = string.Empty };
                    }
                }
                return new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "No Data Available." };
            }
            catch (Exception ex)
            {
                return new ResponseCarrier() { Status = false, PayLoad = null, ErrorMessage = "Error in fetching movies." };
            }

        }

        private List<MovieModel> SortMovieList(List<MovieModel> result, int order, string category, string orderBy)
        {
            result.Sort();
            return result;
        }
    }
}