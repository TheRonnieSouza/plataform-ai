using Common.CommandHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
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
            await handler.Handle(command, CancellationToken.None);

            return NoContent();
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
