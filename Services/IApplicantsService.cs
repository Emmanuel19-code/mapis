using mapis.Domain;

namespace mapis.Services
{
    public interface IApplicantsService
    {
        Task<ApplyResponse> ApplicantsApply(ApplyDetails request);
        Task<ApplyResponse> CheckApplicationStatus(CheckStatus request);
    }
}