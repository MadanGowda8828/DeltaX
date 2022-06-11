using DeltaX.Models;
using DeltaX.Repository;

namespace DeltaX.Services
{
    /// <summary>
    /// Producer Service
    /// </summary>
    public class ProducerService:IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        /// <summary>
        /// Add Producer Service
        /// </summary>
        /// <param name="producer"></param>
        /// <returns>id</returns>
        public async Task<int>AddProducerService(Producer producer)
        {
            var DOB = producer.DOB.Split('-');
            producer.DOB = DOB[2] + "-" + DOB[1] + "-" + DOB[0];
            int res = await _producerRepository.AddProducerAsync(producer);
            return res;
        }
        /// <summary>
        /// Get Producer Service
        /// </summary>
        /// <returns>List of Producers</returns>
        public async Task<IEnumerable<Producer>> GetProducerService()
        {
            var res = await _producerRepository.GetProducersAsync();
            return res;
        }
    }
}
