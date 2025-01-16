using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using mapis.Domain;
using mapis.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace mapis.Services
{
    public class AdminServices : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminServices> _logger;
        private readonly IConfiguration _configuration;
        public AdminServices(ApplicationDbContext context, IMapper mapper, ILogger<AdminServices> logger,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<AdminLoginResponse> AdminLogin(AdminLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                
                return new AdminLoginResponse
                {
                    StatusCode = 401,
                    Message = "Please provide the appropriate details",
                    AccessToken = null
                };
            }
            var admin = await _context.Admins.FirstOrDefaultAsync(u=>u.Username == request.Email);
            if(admin == null)
            {
                return new AdminLoginResponse
                {
                    StatusCode = 400,
                    Message = "No Records Found For this Admin",
                };
            }

            return new AdminLoginResponse
            {

            };
        }

        public async Task<UpdateApplicantResponse> ApproveApplication(UpdateAplicantStatus request)
        {
            try
            {
                var applicant = await _context.Applicants.FirstOrDefaultAsync(a => a.ApplicantId == request.ApplicantId);

                if (applicant == null)
                {
                    return new UpdateApplicantResponse
                    {
                        StatusCode = 404,
                        Message = "Application Number Invalid"
                    };
                }

                if (applicant.IsApproved)
                {
                    return new UpdateApplicantResponse
                    {
                        StatusCode = 400,
                        Message = "Application Already Approved"
                    };
                }


                applicant.IsApproved = true;


                var ciltUser = _mapper.Map<CILTUser>(applicant);

                ciltUser.MemberId = GenerateId();
                ciltUser.ProfileImage = "123456";
                await _context.CiltUser.AddAsync(ciltUser);


                await _context.SaveChangesAsync();

                return new UpdateApplicantResponse
                {
                    StatusCode = 200,
                    Message = "Application Approved"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return new UpdateApplicantResponse
                {
                    StatusCode = 500,
                    Message = "An error occurred while processing the request."
                };
            }
        }

        public async Task<List<ApplicantsInfo>> GetAllApplications()
        {
            var applicants = await _context.Applicants.ToListAsync();
            var applicantsInfo = _mapper.Map<List<ApplicantsInfo>>(applicants);
            return applicantsInfo;
        }
        private string CreateToken(Administrators admin)
        {
            var claims = new List<Claim>{
                new Claim("username",admin.Username),
                new Claim(ClaimTypes.Role,admin.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer:_configuration.GetValue<string>(""),
                audience : _configuration.GetValue<string>(""),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials:creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        private string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

    }


}