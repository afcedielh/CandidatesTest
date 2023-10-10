using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Aplication.Candidates
{
    public class CandidateCreate
    {
        public class Command : IRequest
        {
            public int IdCandidate { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthdate { get; set; }
            public string Email { get; set; }
            public DateTime InsertDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public ICollection<CandidateExperience> Experiences { get; set; }
        }

        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Surname).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            public readonly CandidateContext _context;

            public Handler(CandidateContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var candidate = new Candidate
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Birthdate = request.Birthdate,
                    Email = request.Email,
                    InsertDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Experience = request.Experiences
                };
                _context.candidates.Add(candidate);
                var value = await _context.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el candidato");
            }
        }
    }
}
