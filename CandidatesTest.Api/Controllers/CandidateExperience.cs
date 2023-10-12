using CandidatesTest.Api.Aplication.Candidates;
using CandidatesTest.Api.Candidates.Aplication.Experiences;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Operaciones relacionadas con las experiencias")]
    public class CandidateExperience : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateExperience(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Unit>> CreateCandidate([FromBody] ExperienceCreate.Command data)
        {
            var result = await _mediator.Send(data);
            return Unit.Value;
        }
    }
}
