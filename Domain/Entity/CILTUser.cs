using System.ComponentModel.DataAnnotations;


namespace mapis.Domain
{
    public class CILTUser
    {
        [Key]
        public required string MemberId {get;set;}
        public string Title {get;set;}
        public required string FirstName {get;set;}
        public string? MiddleName {get;set;}
        public required string LastName {get;set;}
        public string ProfileImage {get;set;}
        public string? MemberType {get;set;}
        public required string Email {get;set;}
        public required string Country {get;set;}
        public required string PhoneOne {get;set;}
        public string? PhoneTwo {get;set;}
        public string BusinessAddress {get;set;}
        public string CurrentJobTitle {get;set;}
        public string DateJoinedOrganisation {get;set;}
        public int ExperienceInLogistics {get;set;}
        public string CurrentMemberShipBranch {get;set;}
        public int LastPaymentYear {get;set;}
        public string BranchWant {get;set;}
        
        public bool IsApproved { get; set; }  
        public CILTUserAuth CILTUserAuth { get; set; }
    }
}
