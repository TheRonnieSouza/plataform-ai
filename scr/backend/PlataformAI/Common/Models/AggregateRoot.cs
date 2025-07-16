namespace Common.Models
{
    public abstract class AggregateRoot
    {
        public string Id { get; protected set; } = new Guid().ToString();
    }
}
