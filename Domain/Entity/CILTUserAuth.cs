using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class CILTUserAuth
    {
        [Key]
        public Guid CILTUserAuthId { get; set; } 
        public required string Email {get;set;}
        public required string Password {get;set;}
        public DateTime LastLoggedIn {get;set;}
        public Guid CILTUserId { get; set; }
        public CILTUser CILTUser { get; set; }
    }
}