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
    public class PublishingHouseController : ControllerBase
    {
        private IPublishingHouseService _service;

        public PublishingHouseController(IPublishingHouseService service)
        {
            _service = service;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PublishingHouseDTO>> GetPublishingHouseAsync(Guid id)
        {
            var publishingHouse = await _service.GetPublishingHouseDTOAsync(id);

            if (publishingHouse == null)
            {
                return NotFound();
            }
            return Ok(publishingHouse);
        }

        [HttpGet("get")]
        public async Task<ActionResult<PublishingHouseDTO>> GetPublishingHouseByNameAsync([FromBody]string name)
        {
            var publishingHouse = await _service.GetPublishingHouseByNameAsync(name);

            if (publishingHouse == null)
            {
                return NotFound();
            }
            return Ok(publishingHouse);
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpGet("gets")]
        public async Task<ActionResult<IEnumerable<PublishingHouseDTO>>> GetAllPublishingHouseAsync()
        {
            try
            {
                return Ok(await _service.GetAllPublishingHouseDTOAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPost("post")]
        public async Task<ActionResult<int>> PostPublishingHouseDTOAsync(PublishingHouseDTO publishingHouseDTO)
        {
            try
            {
                return Ok(await _service.AddPublishingHouseAsync(publishingHouseDTO));
            }
            catch (Exception e)// to do conkreate error
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        [HttpPut("put/{id}")]
        public async Task<ActionResult> PutPublishingHouseDTOAsync(Guid id, PublishingHouseDTO publishingHouseDTO)
        {
            try
            {
                await _service.EditPublishingHouseAsync(id, publishingHouseDTO);
                return Ok("Update is complite");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePublishingHouseDTOAsync(Guid id)
        {
            try
            {
                await _service.DeletePublishingHouseAsync(id);
                return Ok("Publishing house is delete");
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}