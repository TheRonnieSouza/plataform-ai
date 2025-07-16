using Common.Models;

namespace Orchestrator.Conversation.Mensagens
{
    public class Message : AggregateRoot
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public IFormFileCollection Files { get; set; } 

        public Message() { }

        public Message(string question)
        {
            Question = question;
        }

        public IList<Media> GetFilesBytes() 
        {
            var files = new List<Media>();
            foreach (var item in Files)
            {
                var memory = new MemoryStream();
                item.OpenReadStream().CopyToAsync(memory);

                files.Add(new Media(memory.ToArray(), item.ContentType));
            }
            return files;
        }
    }    
}
