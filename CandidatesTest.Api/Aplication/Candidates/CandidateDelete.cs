using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTest.Api.Aplication.Candidates
{
    public class CandidateDelete
    {
        public class CandidateQuery : IRequest<bool>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CandidateQuery, bool>
        {
            public readonly CandidateContext _context;
            private readonly IMapper _mapper;
            public Handler(CandidateContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CandidateQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var candidate = await _context.candidates
                        .Include(c => c.Experience)
                        .SingleOrDefaultAsync(c => c.IdCandidate == request.Id);

                    if (candidate == null)
                    {
                        throw new Exception("Candidato no encontrado.");
                    }

                    if (candidate.Experience.Any())
                    {
                        _context.candidateExperiences.RemoveRange(candidate.Experience);
                    }

                    _context.candidates.Remove(candidate);

                    await _context.SaveChangesAsync();

                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Error al eliminar el candidato y sus experiencias: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado: " + ex.Message);
                }
            }
        }
    }
}
