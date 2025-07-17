namespace Orchestrator.Conversation.Mensagens
{
    public class Media
    {
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        public Media(byte[] data, string contentType)
        {
            Data = data;
            ContentType = contentType;
        }
    }
}
