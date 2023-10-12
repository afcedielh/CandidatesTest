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
        [ProducesResponseType(201)] 
        public async Task<ActionResult<Unit>> CreateCandidate([FromBody] CandidateCreate.Command data)
        {
            var result = await _mediator.Send(data);
            return CreatedAtAction(nameof(GetCandidate), new { id = data.IdCandidate }, result);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<CandidateDto>>>
        GetCandidates()
        {
            var candidates = await _mediator.Send(new CandidateQueries.CandidateListQuery());
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Obtener un candidato por su ID")]
        [ProducesResponseType(200, Type = typeof(CandidateDto))] 
        [ProducesResponseType(404)] 
        public async Task<ActionResult<CandidateDto>> GetCandidate(int id)
        {
            var candidate = await _mediator.Send(new CandidateQueriesFilter.CandidateQuery { Id = id });

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)] 
        public async Task<ActionResult<CandidateDto>> UpdateCandidate(int id, [FromBody] CandidateUpdate.Command data)
        {
            data.IdCandidate = id;
            var updatedCandidate = await _mediator.Send(data);
            return Ok(updatedCandidate);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)] 
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var success = await _mediator.Send(new CandidateDelete.CandidateQuery { Id = id });

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
