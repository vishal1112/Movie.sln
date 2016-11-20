using Movie.web.Models;
using Movie.web.Models.reqres;
using System.Threading.Tasks;

namespace Movie.web.Services
{
    public interface IMovieService
    {
        Task<MoviesCollection> GetAllMovieList();
        Task<ResponseCarrier> GetMovieDetail(string movieId);
        Task<ResponseCarrier> GetMovieListDetail(ICacheService cacheService);
    }
}
