namespace mapis.Domain
{
    public class ApplicantsInfo
    {
        public Guid ApplicantId {get;set;}
        public string ProfileImage {get;set;}
        public string FirstName {get;set;}
        public string MiddleName {get;set;}
        public string LastName {get;set;}
        public string MemberType {get;set;}
        public string Email {get;set;}
        public string Country {get;set;}
        public string PhoneOne {get;set;}
        public string PhoneTwo {get;set;}
        public string BusinessAddress {get;set;}
        public string CurrentJobTitle {get;set;}
        public string DateJoinedOrganisation {get;set;}
        public int ExperienceInLogistics {get;set;}
        public string CurrentMemberShipBranch {get;set;}
        public int LastPaymentYear {get;set;}
        public string BranchWant {get;set;}
        public bool IsApproved {get;set;}
       public DateTime DateApplied {get;set;}
    }
    public class UserIdentifier
    {
        public Guid ApplicantId {get;set;}
    }
    
    
    public class AdminLoginRequest
    {
        public required string Email {get;set;}
        public required string Password {get;set;}
    }
    
}