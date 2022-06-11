using DeltaX.Models;
using DeltaX.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeltaX.Controllers
{
    /// <summary>
    /// Producer Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        /// <summary>
        /// Add Producer
        /// </summary>
        /// <param name="producer"></param>
        /// <returns>Success or Fail</returns>
        [HttpPost]
        public async Task<ActionResult> AddProducer([FromBody] Producer producer)
        {
            if(producer.Id != 0)
            {
                return BadRequest();
            }
            int res = await _producerService.AddProducerService(producer);
            if(res == 0)
            {
                return Ok("Failed to add the Producer.");
            }
            return Ok("Producer added successfully.");
        }
        /// <summary>
        /// Get Producer List
        /// </summary>
        /// <returns>List of Producer</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducerList()
        {
            var res = await _producerService.GetProducerService();
            if(!res.Any())
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
