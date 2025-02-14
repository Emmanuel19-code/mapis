using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
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
        public AdminServices(ApplicationDbContext context, IMapper mapper, ILogger<AdminServices> logger, IConfiguration configuration)
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
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Username == request.Email);
            if (admin == null)
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

        public async Task<UpdateApplicantResponse> ApproveApplication(Guid applicationId)
        {
            try
            {
                var applicant = await _context.Applicants.FirstOrDefaultAsync(a => a.ApplicantId == applicationId);

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
                var username = CreateUserName(applicant);
                var ciltUser = _mapper.Map<CILTUser>(applicant);
                ciltUser.MemberId = GenerateUserId();

                var UserCredentials = new CILTUserAuth
                {
                    CILTUserId = ciltUser.MemberId,
                    Email = applicant.Email,
                    Password = CreateUserPassword()
                };
                await _context.CiltUser.AddAsync(ciltUser);
                await _context.CILTUserAuths.AddAsync(UserCredentials);
                await _context.SaveChangesAsync();
                return new UpdateApplicantResponse
                {
                    StatusCode = 200,
                    Message = $"Application Approved {username} "
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

        public async Task<ApplicantsResponseInfo<ApplicantsInfo>> GetApplicantsInfo(Guid applicationId)
        {
            var applicant = await _context.Applicants.FirstOrDefaultAsync(a => a.ApplicantId == applicationId);
            if (applicant == null)
            {
                _logger.LogError("An error Occured");
                return new ApplicantsResponseInfo<ApplicantsInfo>
                {
                    StatusCode = 404,
                    Data = null,
                    Message = "Could not find a User With that Application Id"
                };
            }
            return new ApplicantsResponseInfo<ApplicantsInfo>
            {
                StatusCode = 200,
                Data = _mapper.Map<ApplicantsInfo>(applicant)
            };
        }

        private string CreateToken(Administrators admin)
        {
            var claims = new List<Claim>{
                new Claim("username",admin.Username),
                new Claim(ClaimTypes.Role,admin.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>(""),
                audience: _configuration.GetValue<string>(""),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        private string CreateUserName(Applicants applicants)
        {
            var random = new Random();
            var randomNumber = random.Next(1000, 9999);
            return $"{applicants.FirstName}{randomNumber}";
        }
        private void SaveCounterToFile(int counter)
        {
            File.WriteAllText("counter.txt", counter.ToString());
        }
        public int GetCounterFromFile()
        {
            if (!File.Exists("counter.txt"))
            {
                return 1;
            }
            string counterValue = File.ReadAllText("counter.txt");
            return int.TryParse(counterValue, out int counter) ? counter : 1;
        }
        public string GenerateUserId()
        {
            string yearOfRegistration = DateTime.Now.Year.ToString();
            int counter = GetCounterFromFile();
            string userID = counter.ToString("D4") + yearOfRegistration;
            SaveCounterToFile(counter + 1);
            return userID;
        }
        private string CreateUserPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int passwordLength = 8;
            Random random = new Random();
            var password = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }

        public async Task<List<Notification>> GetNotification()
        {
            var notification = await _context.Notifications.Select(e => new Notification
            {
                Id = e.Id,
                Title = e.Title,
                Message = e.Message,
                CreatedAt = e.Created
            }).ToListAsync();
            return notification;
        }

        public async Task<List<UserInformation>> AllMembers()
        {
            var members = await _context.CiltUser.Select(m => new UserInformation
            {
                Title = m.Title,
                MemberId = m.MemberId,
                Email = m.Email,
                FirstName = m.FirstName,
                MiddleName = m.MiddleName,
                LastName = m.LastName,
                MemberType = m.MemberType,
                Country = m.Country,
                PhoneOne = m.PhoneOne
            }).ToListAsync();
            return members;
        }

    }


}