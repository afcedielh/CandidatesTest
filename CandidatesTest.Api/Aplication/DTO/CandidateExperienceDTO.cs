using System;

namespace CandidatesTest.Api.Aplication.DTO
{
    public class CandidateExperienceDTO
    {
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public CandidateDto Candidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public DateTime Begindate { get; set; }
        public DateTime Enddate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
