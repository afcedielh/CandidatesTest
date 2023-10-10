using CandidatesTest.Api.Candidates.Model;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTest.Api.Persistence
{
    public class CandidateContext : DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options) { }

        public DbSet<Candidate> candidates { get; set; }
        public DbSet<CandidateExperience> candidateExperiences { get; set; }
    }
}
