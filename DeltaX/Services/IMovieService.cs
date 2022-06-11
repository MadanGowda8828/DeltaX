using DeltaX.Models;

namespace DeltaX.Services
{
    /// <summary>
    /// Movie Service Interface
    /// </summary>
    public interface IMovieService 
    {
        //Delete Movie Service
        Task<int> DeleteMovieService(int id);
        //Add Movie Service
        Task<int> AddMovieService(Movie movie);
        //Update Movie Service
        Task<int> UpdateMovieService(Movie movie, int id);
        // Get Movies List Service
        Task<IEnumerable<MovieItem>> GetMoviesService();
    }
}
