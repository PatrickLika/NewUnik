using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Projekt.Command;
using Unik.Applicaiton.Projekt.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/Projekt")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly ICreateProjektCommand _createProjektCommand;
        private readonly IDeleteProjektCommand _deleteProjektCommand;
        private readonly IEditProjektCommand _editProjektCommand;
        private readonly IProjektGetAllQuery _projektGetAllQuery;
        private readonly IProjektGetQuery _projektGetQuery;

        public ProjektController(ICreateProjektCommand createProjektCommand, IDeleteProjektCommand deleteProjektCommand, IEditProjektCommand editProjektCommand, IProjektGetAllQuery projektGetAllQuery, IProjektGetQuery projektGetQuery)
        {
            _createProjektCommand = createProjektCommand;
            _deleteProjektCommand = deleteProjektCommand;
            _editProjektCommand = editProjektCommand;
            _projektGetAllQuery = projektGetAllQuery;
            _projektGetQuery = projektGetQuery;
        }

        // POST api/<ProjektController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] ProjektCreateRequestDto request)
        {
            try
            {
                _createProjektCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/<ProjektController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProjektQueryResultDto>> Get()
        {
            var result = _projektGetAllQuery.GetAll().ToList();
            if (!result.Any())
                return NotFound();
            return result;
        }

        // GET api/<ProjektController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjektQueryResultDto> Get(int id)
        {
            var result = _projektGetQuery.Get(id);
            return result;
        }


        // PUT api/<ProjektController>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put([FromBody] ProjektEditRequestDto request)
        {
            try
            {
                _editProjektCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ProjektController>/5
        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteProjektCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
