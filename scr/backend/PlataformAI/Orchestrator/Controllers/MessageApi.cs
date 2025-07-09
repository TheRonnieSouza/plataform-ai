using Microsoft.AspNetCore.Mvc;
using Orchestrator.Conversation.Ask;

namespace Orchestrator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Message : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromServices] CreateMessageCommandHandler handler, CreateMessageCommand command)
        {
           var result = await handler.Handle(command, CancellationToken.None);

            return Ok(result);
        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateMessage(Guid id)
        {
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            return NoContent();
        }
    }
}
