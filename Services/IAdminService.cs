using mapis.Domain;

namespace mapis.Services
{
    public interface IAdminService
    {
        Task<List<ApplicantsInfo>> GetAllApplications();
        Task<UpdateApplicantResponse> ApproveApplication(UpdateAplicantStatus request);
        Task<AdminLoginResponse> AdminLogin(AdminLoginRequest request);
    }
}