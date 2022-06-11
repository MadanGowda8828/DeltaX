using DeltaX.Models;
using System.Data;
using System.Data.SqlClient;

namespace DeltaX.Repository
{
    /// <summary>
    /// Producer Repository
    /// </summary>
    public class ProducerRepository:IProducerRepository
    {
        private readonly IConfiguration _configuration;
        public ProducerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Add Producer
        /// </summary>
        /// <param name="producer"></param>
        /// <returns>id</returns>
        public async Task<int> AddProducerAsync(Producer producer)
        {
            int producerId=0;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Producer_Ins";
            cmd.Parameters.Add("@ProducerName", SqlDbType.VarChar).Value = producer.Name;
            cmd.Parameters.Add("@Bio", SqlDbType.VarChar).Value = producer.Bio;
            cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = producer.Company;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = producer.DOB;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = producer.Gender;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "User";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@id"].Value.ToString();
                producerId = Convert.ToInt32(id);
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
            return producerId;
        }
        /// <summary>
        /// Get Producer List
        /// </summary>
        /// <returns>List of Producers</returns>
        public async Task<IEnumerable<Producer>> GetProducersAsync()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProducerList";
            cmd.Connection = con;
            List<Producer> producerList = new List<Producer>();
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var producer = new Producer();
                    producer.Id = reader.GetInt32("Id");
                    producer.Name = reader.GetString("Name");
                    producer.Bio = reader.GetString("Bio");
                    producer.Company = reader.GetString("Company");
                    producer.DOB = reader.GetDateTime("DateOfBirth").ToString().Substring(0,10);
                    producer.Gender = reader.GetString("Gender");
                    producer.IsActive = reader.GetBoolean("IsActive");
                    producer.IsDeleted = reader.GetBoolean("IsDeleted");
                    producerList.Add(producer);
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
            return producerList;
        }
    }
}
