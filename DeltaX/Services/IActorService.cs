using DeltaX.Models;

namespace DeltaX.Services
{
    /// <summary>
    /// Actor Service Interface
    /// </summary>
    public interface IActorService
    {
        //Add Actor Service
        Task<int> AddActorService(Actor actor);
        //Get List Of Actors
        Task<IEnumerable<Actor>> GetActorList();
    }
}
