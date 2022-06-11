using DeltaX.Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Data;
using System.Data.SqlClient;

namespace DeltaX.Repository
{
    /// <summary>
    /// Movie Repository
    /// </summary>
    public class MovieRepository:IMovieRepository
    {
        private readonly IConfiguration _configuration;
        public MovieRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Delete Movie Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public async Task<int>DeleteMovieAsync(int id)
        {
            int dlt = 0;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MovieDelete";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.Connection = con;
            try
            {
                con.Open();
                dlt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dlt;
        }
        /// <summary>
        /// Add Movie Details
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>moovie Id</returns>
        public async Task<int> AddMovieAsync(MovieInfo movie)
        {
            int movieId = 0;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Movie_Ins";
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
            cmd.Parameters.Add("@Plot", SqlDbType.VarChar).Value = movie.Plot;
            cmd.Parameters.Add("@Actors", SqlDbType.VarChar).Value = movie.Actors;
            cmd.Parameters.Add("@DateOfRelease", SqlDbType.Date).Value = movie.Date;
            cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = movie.Producer;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "User";
            cmd.Parameters.Add("@PosterName", SqlDbType.VarChar).Value = movie.PosterName;
            cmd.Parameters.Add("@PosterData", SqlDbType.VarBinary).Value = movie.PosterData;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@id"].Value.ToString();
                movieId = Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return movieId;
        }
        /// <summary>
        /// Update Movie Async
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>int</returns>
        public async Task<int> UpdateMovieAsync(MovieInfo movie)
        {
            int res = 0;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Movie_Upd";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = movie.Id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = movie.Name;
            cmd.Parameters.Add("@Plot", SqlDbType.VarChar).Value = movie.Plot;
            cmd.Parameters.Add("@Actors", SqlDbType.VarChar).Value = movie.Actors;
            cmd.Parameters.Add("@DateOfRelease", SqlDbType.Date).Value = movie.Date;
            cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = movie.Producer;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "User";
            cmd.Parameters.Add("@PosterName", SqlDbType.VarChar).Value = movie.PosterName;
            cmd.Parameters.Add("@PosterData", SqlDbType.VarBinary).Value = movie.PosterData;
            cmd.Connection = con;
            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return res;
        }
        /// <summary>
        /// Get Movies async
        /// </summary>
        /// <returns>List of Movies</returns>
        public async Task<IEnumerable<MovieItem>> GetMoviesAsync()
        {
            List<MovieItem> movieList = new List<MovieItem>();
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MovieList";
            cmd.Connection = con;
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var movie = new MovieItem();
                    movie.Id = reader.GetInt32("Id");
                    movie.Name = reader.GetString("Name");
                    movie.Plot = reader.GetString("Plot");
                    movie.Actors = JsonConvert.DeserializeObject<List<ActorItem>>(reader.GetString("Actors"));
                    movie.Date = reader.GetDateTime("DateOfRelease").ToString().Substring(0, 10);
                    movie.Producer = reader.GetString("Producer");
                    movie.PosterName = reader.GetString("PosterName");
                    movie.PosterData = (byte[])reader.GetValue(7);
                    movieList.Add(movie);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return movieList;
        }
    }
}
