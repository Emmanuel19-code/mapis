using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class CILTUserAuth
    {
        [Key]
        public string CILTUserId { get; set; }
        public required string Email {get;set;}
        public required string Password {get;set;}
        public DateTime LastPasswordChange {get;set;}
        public DateTime LastLoggedIn {get;set;}
        public CILTUser CILTUser { get; set; }
    }
}