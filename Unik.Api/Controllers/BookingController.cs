using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Booking.Command;
using Unik.Applicaiton.Booking.Queries;
using Unik.Application.Booking.Queries.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICreateBookingCommand _createBookingCommand;
        private readonly IEditBookingCommand _editBookingCommand;
        private readonly IDeleteBookingCommand _deleteBookingCommand;
        private readonly IBookingGetAllQuery _bookingGetAllQuery;
        private readonly IBookingGetQuery _bookingGetQuery;
        private readonly IFindMedarbejder _findMedarbejder;


        public BookingController(ICreateBookingCommand createBookingCommand, IEditBookingCommand editBookingCommand, IDeleteBookingCommand deleteBookingCommand, IBookingGetAllQuery bookingGetAllQuery, IBookingGetQuery bookingGetQuery, IFindMedarbejder findMedarbejder)
        {
            _createBookingCommand = createBookingCommand;
            _editBookingCommand = editBookingCommand;
            _deleteBookingCommand = deleteBookingCommand;
            _bookingGetAllQuery = bookingGetAllQuery;
            _bookingGetQuery = bookingGetQuery;
            _findMedarbejder = findMedarbejder;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] BookingCreateRequestDto request)
        {
            try
            {
                _createBookingCommand.Create(request);
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
        public ActionResult<IEnumerable<BookingResultDto>> GetAll()
        {
            var result = _bookingGetAllQuery.GetAll().ToList();
            if (!result.Any())
                return NotFound();
            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingResultDto> Get(int id)
        {
            var result = _bookingGetQuery.Get(id);

            return result;

        }

        [HttpGet("Type/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FindMedarbejderDto>> Find(string type)
        {
            try
            {
                var result = _findMedarbejder.FindMedarbejder(type).ToList();
                if (!result.Any())
                    return NotFound();
                return result;

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] BookingEditRequestDto request)
        {
            try
            {
                _editBookingCommand.Edit(request);
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
                _deleteBookingCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
