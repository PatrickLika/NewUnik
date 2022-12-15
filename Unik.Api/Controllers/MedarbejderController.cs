using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Medarbejder.Commands;
using Unik.Applicaiton.Medarbejder.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/Medarbejder")]
    [ApiController]
    public class MedarbejderController : ControllerBase
    {
        private readonly ICreateMedarbejderCommand _createMedarbejder;
        private readonly IDeleteMedarbejderCommand _deleteMedarbejder;
        private readonly IMedarbejderGetAllQuery _getAllMedarbejder;
        private readonly IEditMedarbejderCommand _editMedarbejderCommand;
        private readonly IMedarbejderGetQuery _getMedarbejder;
        private readonly ICreateMedarbejderKompetenceCommand _createMedarbejderKompetenceCommand;
        private readonly IMedarbejderGetByUserId _medarbejderGetByUserId;

        public MedarbejderController(ICreateMedarbejderCommand createMedarbejder, IDeleteMedarbejderCommand deleteStamdataMedarbejder, IMedarbejderGetAllQuery getAllStamdataMedarbejder, IEditMedarbejderCommand editStamdataMedarbejderCommand, IMedarbejderGetQuery getStamdataMedarbejder, ICreateMedarbejderKompetenceCommand createMedarbejderKompetenceCommand, IMedarbejderGetByUserId medarbejderGetByUserId)
        {
            _createMedarbejder = createMedarbejder;
            _deleteMedarbejder = deleteStamdataMedarbejder;
            _getAllMedarbejder = getAllStamdataMedarbejder;
            _editMedarbejderCommand = editStamdataMedarbejderCommand;
            _getMedarbejder = getStamdataMedarbejder;
            _createMedarbejderKompetenceCommand = createMedarbejderKompetenceCommand;
            _medarbejderGetByUserId = medarbejderGetByUserId;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post([FromBody] MedarbejderCreateRequestDto request)
        {

            try
            {
                _createMedarbejder.Create(request);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Kompetence")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post([FromBody] MedarbejderKompetenceCreateDto dto)
        {

            try
            {
                _createMedarbejderKompetenceCommand.Create(dto);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MedarbejderGetAllQueryDto>> GetAll()
        {
            var result = _getAllMedarbejder.GetAll().ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MedarbejderGetQueryDto> Get(int id)
        {
            var result = _getMedarbejder.Get(id);

            return result;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MedarbejderGetByUserIdDto> Get(string userId)
        {
            var result = _medarbejderGetByUserId.GetByUserId(userId);

            return result;
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] MedarbejderEditRequestDto request)
        {
            try
            {
                _editMedarbejderCommand.Edit(request);
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
                _deleteMedarbejder.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
