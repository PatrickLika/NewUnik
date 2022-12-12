using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Sales.Commands;
using Unik.Applicaiton.Sales.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unik.Api.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ICreateSalesCommand _createSales;
        private readonly IDeleteSalesCommand _deleteSalesCommand;
        private readonly ISalesGetAllQuery _salesGetAllQuery;
        private readonly IEditSalesCommand _editSalesCommand;
        private readonly ISalesGetQuery _salesGetQuery;

        public SalesController(ICreateSalesCommand createSales, IDeleteSalesCommand deleteSalesCommand, ISalesGetAllQuery salesGetAllQuery, IEditSalesCommand editSalesCommand, ISalesGetQuery salesGetQuery)
        {
            _createSales = createSales;
            _deleteSalesCommand = deleteSalesCommand;
            _salesGetAllQuery = salesGetAllQuery;
            _editSalesCommand = editSalesCommand;
            _salesGetQuery = salesGetQuery;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SalesGetQueryDto> Get(int id)
        {
            var result = _salesGetQuery.Get(id);

            return result;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<IEnumerable<SalesGetAllQueryDto>> GetAll()
        {
            var result = _salesGetAllQuery.GetAll().ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post([FromBody] SalesCreateRequestDto request)
        {

            try
            {
                _createSales.Create(request);
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
                _deleteSalesCommand.Delete(id);
                return Ok();
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
        public ActionResult Put([FromBody] SalesEditRequestDto request)
        {
            try
            {
                _editSalesCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        #region Read many to many
        //public class dto
        //{
        //    public int id1 { get; set; }
        //    public int id2 { get; set; }


        //}

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //public ActionResult<IEnumerable<dto>> GetAll()
        //{
        //    int input = 1;

        //    var test = _db.MedarbejderEntities.Where(a => a.Id == input).SelectMany(c => c.KompetenceListe);
        //    return Ok(test);
        //}
        #endregion
    }
}
