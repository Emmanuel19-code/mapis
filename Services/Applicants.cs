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
            Console.WriteLine("hello",request.CurrentMemberShipBranch);
            var existEmail =await _applicationDbContext.Applicants.FirstOrDefaultAsync(a => a.Email == request.Email);
            Console.WriteLine(existEmail);
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
            Console.WriteLine("this is",request.MemberType);
            var ApplicationDetails = new Applicants
            {
                ProfileImage  = image,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                MemberType = request.MemberType,
                DateofBirth = request.DateofBirth,
                Email = request.Email,
                Country = request.Country,
                HomeAddress = request.HomeAddress,
                PhoneOne = request.PhoneOne,
                PhoneTwo = request.PhoneTwo,
                CurrentCompany = request.CurrentCompany,
                DateStartedWorking = request.DateStartedWorking,
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
                Message = $"Application Submitted Successfully.On Approval of Application You will receive access details to the portal",
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