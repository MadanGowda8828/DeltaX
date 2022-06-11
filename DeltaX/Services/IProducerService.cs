using DeltaX.Models;

namespace DeltaX.Services
{
    /// <summary>
    /// Producer Service Interface
    /// </summary>
    public interface IProducerService
    {
        //Add Producer
        Task<int> AddProducerService(Producer producer);
        //Get Producer service
        Task<IEnumerable<Producer>> GetProducerService();
    }
}
