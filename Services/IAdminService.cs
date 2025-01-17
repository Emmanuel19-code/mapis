using mapis.Domain;

namespace mapis.Services
{
    public interface IAdminService
    {
        Task<List<ApplicantsInfo>> GetAllApplications();
        Task<UpdateApplicantResponse> ApproveApplication(UserIdentifier request);
        Task<AdminLoginResponse> AdminLogin(AdminLoginRequest request);
        Task<ApplicantsResponseInfo<ApplicantsInfo>> GetApplicantsInfo(UserIdentifier request);
    }
}