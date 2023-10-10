using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            public readonly CandidateContext _context;
            private readonly IMapper _mapper;
            public Handler(CandidateContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CandidateDto> Handle(CandidateQuery request, CancellationToken cancellationToken)
            {
                var candidate = await _context.candidates.Where(a => a.IdCandidate == request.Id).FirstOrDefaultAsync() ?? throw new Exception("No se encontró el candidato");
                var candidatesDto = _mapper.Map<Candidate, CandidateDto>(candidate);
                return candidatesDto;
            }
        }
    }
}
