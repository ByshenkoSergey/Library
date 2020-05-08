using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTOModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace API_Laer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PublisherDTO>> GetPublisherAsync(Guid id)
        {
            var publisher = await _service.GetPublisherDTOAsync(id);

            if (publisher == null)
            {
                return NotFound(new ResponseDTO { Message = "Publisher not found"});
            }
            return Ok(new ResponseObjectDTO{ ResponseObject = publisher, Message = "Request successful" });
        }



        [Authorize(Roles = "SuperUser")]
        [Authorize(Roles = "Admin")]
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


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult<int>> PostPublisherDTOAsync(PublisherDTO PublisherDTO)
        {
            try
            {
                var id = await _service.AddPublisherAsync(PublisherDTO);
                return Ok(new { requestObject = id, message = "Publisher added" });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutPublisherDTOAsync(Guid id, PublisherDTO PublisherDTO)
        {
            try
            {
                await _service.EditPublisherAsync(id, PublisherDTO);
                return Ok(new ResponseDTO { Message = "Publisher is puted" });
            }
            catch (NullReferenceException e)
            {
                return BadRequest(new ResponseDTO { Message = $"{e.Message}" });
            }

        }

        [Authorize(Roles = "Admin")]
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