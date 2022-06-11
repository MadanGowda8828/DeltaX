using DeltaX.Models;

namespace DeltaX.Repository
{
    /// <summary>
    /// Actor Repository Interface
    /// </summary>
    public interface IActorRepository
    {
        //Add Actor Aync
        Task<int> AddActorAsync(Actor actor);
        //Get Actors Async
        Task<IEnumerable<Actor>> GetActorsAsync();
    }
}
