using mapis.Domain;
using mapis.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace mapis.Services
{
    public class ApplicantService : IApplicantsService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicantService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ApplyResponse> ApplicantsApply(ApplyDetails request)
        {
            var existEmail =await _applicationDbContext.Applicants.FirstOrDefaultAsync(a => a.Email == request.Email);
            if (existEmail != null)
            {
                return new ApplyResponse
                {
                    StatusCode = 400,
                    Message = "This Email Has Already Applied"
                };
            }
            var checkNames = await _applicationDbContext.Applicants.FirstOrDefaultAsync(n => n.FirstName == request.FirstName && n.LastName == request.LastName && n.MiddleName == request.MiddleName );
            if(checkNames != null)
            {
                return new ApplyResponse
                {
                    StatusCode = 400,
                    Message = "A User with This Name is Available"
                };
            }
            var image = await UploadFile(request.ProfileImage);
            var ApplicationDetails = new Applicants
            {
                ProfileImage  = image,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Country = request.Country,
                PhoneOne = request.PhoneOne,
                PhoneTwo = request.PhoneTwo,
                BusinessAddress = request.BusinessAddress,
                CurrentJobTitle = request.CurrentJobTitle,
                DateJoinedOrganisation = request.DateJoinedOrganisation,
                ExperienceInLogistics = request.ExperienceInLogistics,
                CurrentMemberShipBranch = request.CurrentMemberShipBranch,
                LastPaymentYear = request.LastPaymentYear,
                BranchWant = request.BranchWant,
            };
            await _applicationDbContext.Applicants.AddAsync(ApplicationDetails);
            await _applicationDbContext.SaveChangesAsync();
            return new ApplyResponse
            {
                StatusCode = 200,
                Message = "Application Submitted Check Your Mail",
                ApplicantId = ApplicationDetails.ApplicantId
            };
        }

        public async Task<ApplyResponse> CheckApplicationStatus(CheckStatus request)
        {
            var applications = await _applicationDbContext.Applicants.FirstOrDefaultAsync(a=>a.ApplicantId == request.ApplicantId);
            if(applications == null)
            {
                return new ApplyResponse
                {
                    StatusCode = 404,
                    Message =  "ApplicationId Was Not Found"
                };
            }
          if(applications.IsApproved == false)
          {
            return new ApplyResponse
            {
                StatusCode = 200,
                Message = "Application Not Approved "
            };
          }
            return new ApplyResponse
            {
                StatusCode = 200,
                Message = "Application Approved"
            };
        }

        private async Task<string> UploadFile(IFormFile profileImage)
        {
            string filePath = string.Empty;
            if(profileImage != null)
            {
                var imageFolderPath = Path.Combine("Upload","images");
                Directory.CreateDirectory(imageFolderPath);
                var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(profileImage.FileName);
                filePath = Path.Combine(imageFolderPath,imageFileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await profileImage.CopyToAsync(stream);
                }
            }
            return filePath;
        }
    }
}