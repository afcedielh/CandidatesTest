using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Aplication.Candidates
{
    public class CandidateQueriesFilter
    {
        public class CandidateQuery : IRequest<CandidateDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CandidateQuery, CandidateDto>
        {
            private readonly CandidateContext _context;
            private readonly IMapper _mapper;

            public Handler(CandidateContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CandidateDto> Handle(CandidateQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var candidate = await _context.candidates
                        .Where(a => a.IdCandidate == request.Id)
                        .Include(c => c.Experience)
                        .FirstOrDefaultAsync() ?? throw new Exception("Candidato no encontrado.");
                    var candidateDto = _mapper.Map<Candidate, CandidateDto>(candidate);
                    return candidateDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el candidato: " + ex.Message);
                }
            }
        }
    }
}
