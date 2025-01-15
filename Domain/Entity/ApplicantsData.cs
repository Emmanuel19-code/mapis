using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class Applicants
    {
        public Applicants()
        {
            IsApproved = false;
            ApplicantId = Guid.NewGuid();
        }
        [Key]
        public Guid ApplicantId { get; set; }
        public string ProfileImage {get;set;}
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? MemberType {get;set;}
        public required string Email { get; set; }
        public required string Country { get; set; }
        public required string PhoneOne { get; set; }
        public string? PhoneTwo { get; set; }
        public string BusinessAddress { get; set; }
        public string CurrentJobTitle { get; set; }
        public string DateJoinedOrganisation { get; set; }
        public int ExperienceInLogistics { get; set; }
        public string CurrentMemberShipBranch { get; set; }
        public int LastPaymentYear { get; set; }
        public string BranchWant { get; set; }
        public bool IsApproved { get; set; } 
        public DateTime DateApplied { get; set; } = DateTime.UtcNow;
    }
}
