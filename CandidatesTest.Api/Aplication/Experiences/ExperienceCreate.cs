using CandidatesTest.Api.Candidates.Model;
using CandidatesTest.Api.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Candidates.Aplication.Experiences
{
    public class ExperienceCreate
    {
        public class Command : IRequest<int>
        {
            public int IdCandidateExperience { get; set; }
            public int IdCandidate { get; set; }
            public string Company { get; set; }
            public string Job { get; set; }
            public string Description { get; set; }
            public int Salary { get; set; }
            public DateTime Begindate { get; set; }
            public DateTime Enddate { get; set; }
        }

        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Company).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Job).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Salary).NotEmpty().GreaterThan(0);
                RuleFor(x => x.Begindate).NotEmpty().LessThan(x => x.Enddate);
                RuleFor(x => x.Enddate).NotEmpty();
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

                    var candidate = await _context.candidates
                            .Include(c => c.Experience)
                            .FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate) ?? throw new Exception("Candidato no encontrado.");

                    var experiencie = new CandidateExperience
                    {
                        Begindate = request.Begindate,
                        Enddate = request.Enddate,
                        Company = request.Company,
                        Job = request.Job,
                        Description = request.Description,
                        Salary = request.Salary,
                        IdCandidate = request.IdCandidate,
                        InsertDate = DateTime.UtcNow,
                        ModifyDate = DateTime.UtcNow,
                        Candidate = candidate
                    };
                    _context.candidateExperiences.Add(experiencie);
                    var value = await _context.SaveChangesAsync();

                    if (value > 0)
                    {
                        return candidate.IdCandidate;
                    }
                    else
                    {
                        throw new Exception("No se pudo insertar el candidato.");
                    }
                }catch (Exception ex)
                {
                    throw new Exception("Error al crear el candidato: " + ex.Message);
                }
            }
        }
    }
}
