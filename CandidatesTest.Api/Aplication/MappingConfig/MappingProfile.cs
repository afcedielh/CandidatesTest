using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;

namespace CandidatesTest.Api.Aplication.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
