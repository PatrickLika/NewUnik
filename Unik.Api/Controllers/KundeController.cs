﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Applicaiton.Kunde.Commands;
using Unik.Applicaiton.Kunde.Query;
using Unik.Application.Kunde.Query;

namespace Unik.Api.KundeControllers
{
    [Route("api/Kunde")]
    [ApiController]
    public class KundeController : ControllerBase
    {
        private readonly ICreateKundeCommand _createKundeCommand;
        private readonly IDeleteKundeCommand _deleteKundeCommand;
        private readonly IEditKundeCommand _editKundeCommand;
        private readonly IKundeGetAllQuery _KundeGetAllQuery;
        private readonly IKundeGetQuery _KundeGetQuery;
        private readonly IKundeGetByUser _getKundeUserId;

        public KundeController(ICreateKundeCommand createKundeCommand,
            IDeleteKundeCommand deleteKundeCommand, IEditKundeCommand editKundeCommand,
            IKundeGetAllQuery KundeGetAllQuery, IKundeGetQuery KundeGetQuery, IKundeGetByUser getUserIdKunde)
        {
            _createKundeCommand = createKundeCommand;
            _deleteKundeCommand = deleteKundeCommand;
            _editKundeCommand = editKundeCommand;
            _KundeGetAllQuery = KundeGetAllQuery;
            _KundeGetQuery = KundeGetQuery;
            _getKundeUserId = getUserIdKunde;
        }
        // POST api/<KundeController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] KundeCreateRequestDto requestDto)
        {
            try
            {
                _createKundeCommand.Create(requestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET: api/<KundeController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<KundeResultDto>> Get()
        {
            var result = _KundeGetAllQuery.GetAll().ToList();
            return result;
        }

        // GET api/<KundeController>/5
        [HttpGet("id/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KundeResultDto> Get(int id)
        {
            var result = _KundeGetQuery.Get(id);
            return result;
        }

        // GET api/<KundeController>/5
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KundeUserResultDto> GetUser(string userId)
        {
            var result = _getKundeUserId.GetUser(userId);
            return result;
        }


        // PUT api/<KundeController>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] KundeEditRequestDto requestDto)
        {
            try
            {
                _editKundeCommand.Edit(requestDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<KundeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteKundeCommand.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
