namespace mapis.Domain
{
    public class BeComeMember
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? MemberId { get; set; }
        public string? MemberType { get; set; }
        public required string Email { get; set; }
        public required string Password {get;set;}
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
    }
    public class AccountLogin 
    {
        public required string Email {get;set;}
        public required string Password {get;set;}
    }
    public class UserDetails
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? MemberId { get; set; }
        public string? MemberType { get; set; }
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
    }
    public class GetUserDetailsInfo
    {
        public string MemberId {get;set;}
    }
}