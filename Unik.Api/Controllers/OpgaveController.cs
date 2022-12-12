using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Opgave.Command;
using Unik.Applicaiton.Opgave.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/opgave")]
    [ApiController]
    public class OpgaveController : ControllerBase
    {
        private readonly ICreateOpgaveCommand _createOpgaveCommand;
        private readonly IEditOpgaveCommand _editOpgaveCommand;
        private readonly IDeleteOpgaveCommand _deleteOpgaveCommand;
        private readonly IOpgaveGetAllQuery _opgaveGetAllQuery;
        private readonly IOpgaveGetQuery _opgaveGetQuery;

        public OpgaveController(ICreateOpgaveCommand createKompetenceCommand, IEditOpgaveCommand editKompetenceCommand,
            IDeleteOpgaveCommand deletekompetenceCommand, IOpgaveGetAllQuery getAllQuery, IOpgaveGetQuery getQuery)
        {
            _createOpgaveCommand = createKompetenceCommand;
            _editOpgaveCommand = editKompetenceCommand;
            _deleteOpgaveCommand = deletekompetenceCommand;
            _opgaveGetAllQuery = getAllQuery;
            _opgaveGetQuery = getQuery;
        }

         [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public ActionResult Post([FromBody] OpgaveCreateRequestDto request)
        {
            try
            {
                _createOpgaveCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<IEnumerable<OpgaveQueryResultDto>> GetAll()
        {
            var result = _opgaveGetAllQuery.GetAll().ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OpgaveQueryResultDto> Get(int id)
        {
            var result = _opgaveGetQuery.Get(id);
            return result;
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] OpgaveEditRequestDto request)
        {
            try
            {
                _editOpgaveCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteOpgaveCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
