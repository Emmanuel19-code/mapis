namespace mapis.Domain
{
    public class Complains
    {
        public Guid Id {get;set;}
        public required string Type {get;set;}
        public required string FullName {get;set;}
        public required string Email {get;set;}
        public required string Issue {get;set;}
        public string Status {get;set;} = "Pending";
        public DateTime CreatedAt {get;set;}
    }
}