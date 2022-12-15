using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Kompetence.Commands;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Application.Kompetence.Query.Implementation;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/Kompetence")]
    [ApiController]
    public class KompetenceController : ControllerBase
    {
        private readonly ICreateKompetenceCommand _createKompetenceCommand;
        private readonly IEditKompetenceCommand _editKompetenceCommand;
        private readonly IDeleteKompetenceCommand _deletekompetenceCommand;
        private readonly iKompetenceGetAllQuery _getAllQuery;
        private readonly iKompetenceGetQuery _getQuery;

        public KompetenceController(ICreateKompetenceCommand createKompetenceCommand, IEditKompetenceCommand editKompetenceCommand,
            IDeleteKompetenceCommand deletekompetenceCommand, iKompetenceGetAllQuery getAllQuery, iKompetenceGetQuery getQuery)
        {
            _createKompetenceCommand = createKompetenceCommand;
            _editKompetenceCommand = editKompetenceCommand;
            _deletekompetenceCommand = deletekompetenceCommand;
            _getAllQuery = getAllQuery;
            _getQuery = getQuery;

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public ActionResult Post([FromBody] KompetenceCreateRequestDto request)
        {
            try
            {
                _createKompetenceCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200Ok)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<KompetenceQueryResultDto>> GetAll()
        {
            var result = _getAllQuery.GetAll().ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KompetenceGetQueryResultDto> Get(int id)
        {
            var result = _getQuery.Get(id);
            return result;
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] KompetenceEditRequestDto request)
        {
            try
            {
                _editKompetenceCommand.Edit(request);
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
                _deletekompetenceCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
