using System;
using System.Collections.Generic;

namespace CandidatesTest.Api.Aplication.DTO
{
    public class CandidateDto
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public List<CandidateExperienceDTO> Experiences { get; set; }

    }
}
