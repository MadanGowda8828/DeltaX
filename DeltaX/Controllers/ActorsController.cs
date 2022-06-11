using DeltaX.Models;
using DeltaX.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeltaX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;   
        }
        /// <summary>
        /// Add Actor
        /// </summary>
        /// <param name="actor"></param>
        /// <returns>success or Failure</returns>
        [HttpPost]
        public async Task<ActionResult> AddActor([FromBody] Actor actor)
        {
            if(actor.Id != 0)
            {
                return BadRequest();
            }
            int res = await _actorService.AddActorService(actor);
            if (res == 0)
            {
                return Ok("Failed to add the Actor.");
            }
            return Ok("Actor added successfully.");
        }
        /// <summary>
        /// Get Actor List
        /// </summary>
        /// <returns>List of Actors</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActorsList()
        {
            var res = await _actorService.GetActorList();
            if (!res.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
