namespace mapis.Domain
{
    public class Administrators
    {
        public Guid Id {get;set;}
        public required string Username {get;set;}
        public required string Password {get;set;}
        public required string Role {get;set;}
    }
}