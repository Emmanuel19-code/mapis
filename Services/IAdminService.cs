using mapis.Domain;

namespace mapis.Services
{
    public interface IAdminService
    {
        Task<List<ApplicantsInfo>> GetAllApplications();
        Task<UpdateApplicantResponse> ApproveApplication(Guid applicationId);
        Task<AdminLoginResponse> AdminLogin(AdminLoginRequest request);
        Task<ApplicantsResponseInfo<ApplicantsInfo>> GetApplicantsInfo(Guid applicationId);
        Task<List<Notification>> GetNotification();
        Task<List<UserInformation>> AllMembers(); 
    }
}