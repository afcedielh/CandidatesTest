using CandidatesTest.Api.Candidates.Model;
using System.Collections.Generic;
using System;

namespace CandidatesTest.Api.Aplication.DTO
{
    public class CandidateDto
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

    }
}
