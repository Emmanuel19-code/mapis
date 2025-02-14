namespace mapis.Domain
{
    public class ComplainDto
    {
        public required string ComplainType {get;set;}
        public string FullName {get;set;}
        public string Email {get;set;}
        public string Issue {get;set;}
    }
}