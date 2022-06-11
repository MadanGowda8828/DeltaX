using DeltaX.Models;

namespace DeltaX.Repository
{
    /// <summary>
    /// Producer Repository Interface
    /// </summary>
    public interface IProducerRepository
    {
        // Add Producer
        Task<int> AddProducerAsync(Producer producer);
        // Get List of Producer
        Task<IEnumerable<Producer>> GetProducersAsync();
    }
}
