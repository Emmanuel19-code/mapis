using mapis.Domain;

namespace mapis.Services
{
    public interface IAdminService
    {
        Task<List<ApplicantsInfo>> GetAllApplications();
        Task<UpdateApplicantResponse> ApproveApplication(Guid applicationId);
        Task<AdminLoginResponse> AdminLogin(AdminLoginRequest request);
        Task<ApplicantsResponseInfo<ApplicantsInfo>> GetApplicantsInfo(Guid applicationId);
    }
}