using AutoMapper;
using CandidatesTest.Api.Aplication.DTO;
using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Aplication.Candidates
{
    public class CandidateUpdate
    {
        public class Command : IRequest<CandidateDto>
        {
            public int IdCandidate { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthdate { get; set; }
            public string Email { get; set; }
            public DateTime InsertDate { get; set; }
            public DateTime ModifyDate { get; set; }
        }

        public class Handler : IRequestHandler<Command, CandidateDto>
        {
            private readonly CandidateContext _context;
            private readonly IMapper _mapper;

            public Handler(CandidateContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CandidateDto> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var candidate = await _context.candidates
                        .Include(c => c.Experience)
                        .FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate) ?? throw new Exception("Candidato no encontrado.");
                    if (candidate.ModifyDate != request.ModifyDate)
                    {
                        throw new Exception("El candidato ha sido modificado por otro usuario. Actualiza y vuelve a intentar.");
                    }

                    candidate.Name = request.Name;
                    candidate.Surname = request.Surname;
                    candidate.Birthdate = request.Birthdate;
                    candidate.ModifyDate = DateTime.Now;
                    candidate.ModifyDate = DateTime.Now;
                    var value = await _context.SaveChangesAsync();

                    if (value > 0)
                    {
                        var candidateDto = _mapper.Map<Candidate, CandidateDto>(candidate);
                        return candidateDto;
                    }
                    else
                    {
                        throw new Exception("No se pudo actualizar el candidato.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el candidato: " + ex.Message);
                }
            }          
        }
    }
}
