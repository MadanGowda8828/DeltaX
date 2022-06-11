using DeltaX.Models;
using System.Data;
using System.Data.SqlClient;

namespace DeltaX.Repository
{
    /// <summary>
    /// Actor Repository
    /// </summary>
    public class ActorRepository:IActorRepository
    {
        private readonly IConfiguration _configuration;
        public ActorRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        /// <summary>
        /// Add Actor Async
        /// </summary>
        /// <param name="actor"></param>
        /// <returns>Id</returns>
        public async Task<int> AddActorAsync(Actor actor)
        {
            int actorId = 0;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Actor_Ins";
            cmd.Parameters.Add("@ActorName", SqlDbType.VarChar).Value = actor.Name;
            cmd.Parameters.Add("@Bio", SqlDbType.VarChar).Value = actor.Bio;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = actor.DOB;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = actor.Gender;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "User";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@id"].Value.ToString();
                actorId = Convert.ToInt32(id);
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
            return actorId;
        }
        /// <summary>
        /// Get Actor List
        /// </summary>
        /// <returns>List of Actors</returns>
        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActorList";
            cmd.Connection = con;
            List<Actor> actorList = new List<Actor>();
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var actor = new Actor();
                    actor.Id = reader.GetInt32("Id");
                    actor.Name = reader.GetString("Name");
                    actor.Bio = reader.GetString("Bio");
                    actor.DOB = reader.GetDateTime("DateOfBirth").ToString().Substring(0, 10);
                    actor.Gender = reader.GetString("Gender");
                    actor.IsActive = reader.GetBoolean("IsActive");
                    actor.IsDeleted = reader.GetBoolean("IsDeleted");
                    actorList.Add(actor);
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
            return actorList;
        }
    }
}
