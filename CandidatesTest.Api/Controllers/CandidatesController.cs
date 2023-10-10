using CandidatesTest.Api.Aplication.Candidates;
using CandidatesTest.Api.Aplication.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Operaciones relacionadas con los candidatos")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateCandidate([FromBody] CandidateCreate.Command data)
        {
            var result = await _mediator.Send(data);
            return CreatedAtAction(nameof(GetCandidate), new { id = data.IdCandidate }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CandidateDto>>> GetCandidates()
        {
            return await _mediator.Send(new CandidateQueries.CandidateListQuery());
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Obtener un candidato por su ID")]
        [ProducesResponseType(typeof(CandidateDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CandidateDto>> GetCandidate(int id)
        {
            return await _mediator.Send(new CandidateQueriesFilter.CandidateQuery { Id = id });
        }
    }
}
