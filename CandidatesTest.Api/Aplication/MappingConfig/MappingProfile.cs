using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using System.Linq;

namespace CandidatesTest.Api.Aplication.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDto>()
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experience.Select(e => new CandidateExperienceDTO
                {
                    IdCandidateExperience = e.IdCandidateExperience,
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    Begindate = e.Begindate,
                    Enddate = e.Enddate,
                    InsertDate = e.InsertDate,
                    ModifyDate = e.ModifyDate
                })));
        }
    }
}
