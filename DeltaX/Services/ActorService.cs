using DeltaX.Models;
using DeltaX.Repository;

namespace DeltaX.Services
{
    //Actor Service
    public class ActorService:IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository; 
        }
        /// <summary>
        /// Add Actor service
        /// </summary>
        /// <param name="actor"></param>
        /// <returns>id</returns>
        public async Task<int> AddActorService(Actor actor)
        {
            var DOB = actor.DOB.Split('-');
            actor.DOB = DOB[2] + "-" + DOB[1] + "-" + DOB[0];
            int res = await _actorRepository.AddActorAsync(actor);
            return res;
        }
        /// <summary>
        /// Get Actor List
        /// </summary>
        /// <returns>List of Actors</returns>
        public async Task<IEnumerable<Actor>> GetActorList()
        {
            var res = await _actorRepository.GetActorsAsync();
            return res;
        }
    }
}
