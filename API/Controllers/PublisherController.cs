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
            var Publisher = await _service.GetPublisherDTOAsync(id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Ok(Publisher);
        }

        [HttpGet("get")]
        public async Task<ActionResult<PublisherDTO>> GetPublisherByNameAsync([FromBody]string name)
        {
            var Publisher = await _service.GetPublisherByNameAsync(name);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Ok(Publisher);
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<PublisherDTO>>> GetAllPublisherAsync()
        {
            try
            {
                return Ok(await _service.GetAllPublisherDTOAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult<int>> PostPublisherDTOAsync(PublisherDTO PublisherDTO)
        {
            try
            {
                return Ok(await _service.AddPublisherAsync(PublisherDTO));
            }
            catch (Exception e)// to do conkreate error
            {
                return BadRequest(e.Message);
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
                return Ok("Update is complite");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePublisherDTOAsync(Guid id)
        {
            try
            {
                await _service.DeletePublisherAsync(id);
                return Ok("Publishing house is delete");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}