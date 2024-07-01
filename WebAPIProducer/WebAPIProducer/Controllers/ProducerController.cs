using Microsoft.AspNetCore.Mvc;
using WebAPIProducer.Model;
using WebAPIProducer.Services;

namespace WebAPIProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;
        public ProducerController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> PaymentAsync([FromBody] Payment payment)
        {
            if (!ModelState.IsValid) return BadRequest();

            _messageProducer.SendMessageAsync<Payment>(payment);

            return Ok();
        }
    }
}
