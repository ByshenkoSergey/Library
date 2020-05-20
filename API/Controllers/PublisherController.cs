using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace API_Laer
{

    /// <summary>
    /// Сlass for working with book publishers
    /// </summary>
    
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]


    public class PublisherController : ControllerBase
    {
        private IPublisherService _service;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="service"></param>

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        /// <summary>
        /// Receiving the publisher by id/ protected / role for access - Moderator, User,
        /// SuperUser, admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PublisherDTO>> GetPublisherAsync(Guid id)
        {
            var publisher = await _service.GetPublisherDTOAsync(id);

            if (publisher == null)
            {
                return NotFound(new ResponseDTO { Message = "Publisher not found" });
            }
            return Ok(new ResponseObjectDTO { ResponseObject = publisher, Message = "Request successful" });
        }


        /// <summary>
        /// Receiving the all publishers/ protected / role for access - Moderator
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<PublisherDTO>>> GetAllPublisherAsync()
        {
            try
            {
                var publisherList = await _service.GetAllPublisherDTOAsync();
                return Ok(new ResponseObjectDTO { ResponseObject = publisherList, Message = "Request successful" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        /// <summary>
        /// Change publisher by id number/ protected / role for access - Moderator
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publisherDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutPublisherDTOAsync(Guid id, PublisherDTO publisherDTO)
        {
            try
            {
                await _service.EditPublisherAsync(id, publisherDTO);
                return Ok(new ResponseDTO { Message = "Publisher is puted" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }

        /// <summary>
        /// Delete publisher by id number/ protected / role for access - Moderator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Authorize(Roles = "Moderator")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePublisherDTOAsync(Guid id)
        {
            try
            {
                await _service.DeletePublisherAsync(id);
                return Ok(new ResponseDTO { Message = "Publisher is delete" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }


    }
}