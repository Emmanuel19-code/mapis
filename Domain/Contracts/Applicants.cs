namespace mapis.Domain
{
    public class ApplyDetails
    {
        public IFormFile ProfileImage {get;set;}
        public required string Title {get;set;}
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateofBirth {get;set;}
        public required string Email { get; set; }
        public required string MemberType {get;set;}
        public required string Country { get; set; }
         public required string HomeAddress {get;set;}
        public required string PhoneOne { get; set; }
        public string? PhoneTwo { get; set; }
        public string CurrentCompany {get;set;}
        public DateTime DateStartedWorking {get;set;}
        public string BusinessAddress { get; set; }
        public string CurrentJobTitle { get; set; }
        public string DateJoinedOrganisation { get; set; }
        public int ExperienceInLogistics { get; set; }
        public string CurrentMemberShipBranch { get; set; }
        public int LastPaymentYear { get; set; }
        public string BranchWant { get; set; }
    }

    

    public class CheckStatus
    {
        public Guid ApplicantId {get;set;}
    }
}