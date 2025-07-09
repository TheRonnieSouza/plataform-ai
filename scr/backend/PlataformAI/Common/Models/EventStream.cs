using System.Security.Cryptography.X509Certificates;

namespace Common.Models
{
    public  class EventStream
    {
        public EventStream()
        { }

        public EventStream(object content) 
        {
            Content = content;
        }
         public object Content {  get; set; }
        
    }
}
