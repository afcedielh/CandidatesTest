using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Aplication.Candidates
{
    public class CandidateQueries
    {
        public class CandidateListQuery : IRequest<List<CandidateDto>> { }

        public class Handler : IRequestHandler<CandidateListQuery, List<CandidateDto>>
        {
            private readonly CandidateContext _context;
            private readonly IMapper _mapper;

            public Handler(CandidateContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CandidateDto>> Handle(CandidateListQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var candidates = await _context.candidates.Include(c => c.Experience).ToListAsync();
                    var candidatesDto = _mapper.Map<List<Candidate>, List<CandidateDto>>(candidates);
                    return candidatesDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de candidatos: " + ex.Message);
                }
            }
        }
    }
}
