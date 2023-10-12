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
        public class Command : IRequest<int>
        {
            public int IdCandidate { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthdate { get; set; }
            public string Email { get; set; }
        }

        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Surname).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
            }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly CandidateContext _context;

            public Handler(CandidateContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var candidate = new Candidate
                    {
                        Name = request.Name,
                        Surname = request.Surname,
                        Birthdate = request.Birthdate,
                        Email = request.Email,
                        InsertDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                    };

                    _context.candidates.Add(candidate);
                    var value = await _context.SaveChangesAsync();

                    if (value > 0)
                    {
                        return candidate.IdCandidate;
                    }
                    else
                    {
                        throw new Exception("No se pudo insertar el candidato.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el candidato: " + ex.Message);
                }
            }
        }
    }
}
