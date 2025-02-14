using AutoMapper;

namespace mapis.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Applicants,ApplicantsInfo>();
            CreateMap<Applicants,CILTUser>();
            CreateMap<CILTUser,UserInformation>();
        }
    }
}