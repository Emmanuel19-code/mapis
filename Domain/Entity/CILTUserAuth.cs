using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class CILTUserAuth
    {
        [Key]
        public Guid CILTUserAuthId { get; set; } 
        public required string Email {get;set;}
        public required string Password {get;set;}
        public DateTime LastPassordChange {get;set;}
        public DateTime LastLoggedIn {get;set;}
        public string CILTUserId { get; set; }
        public CILTUser CILTUser { get; set; }
    }
}