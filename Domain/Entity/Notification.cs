namespace mapis.Domain
{
    public class Notifications
    {
        public Guid Id {get;set;}
        public required string Title {get;set;}
        public required string Message {get;set;}
        public DateTime Created {get;set;}
    }
}