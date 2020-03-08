using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetAPI.ApiModels;
using PetAPI.Core.Services;

namespace PetAPI.Controllers
{
    public class SheltersController : ControllerBase
    {
        private readonly IShelterService _shelterService;

        public SheltersController(IShelterService shelterService)
        {
            _shelterService = shelterService;
        }

        //GET api/shelters
        [HttpGet]
        public IActionResult Get()
        {
            var shelterModels = _shelterService
                .GetAll()
                .ToApiModels();

            return Ok(shelterModels);
        }

        // Get api/shelters/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shelter = _shelterService.Get(id);
            if (shelter == null) return NotFound();
            return Ok(shelter);
        }

        // POST api/shelters
        [HttpPost]
        public IActionResult Post([FromBody] ShelterModel newShelter)
        {
            try
            {
                _shelterService.Add(newShelter.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddShelter", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newShelter.Id }, newShelter);
        }

        // PUT api/shelters/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShelterModel updatedShelter)
        {
            var shelter = _shelterService.Update(updatedShelter.ToDomainModel());
            if (shelter == null) return NotFound();
            return Ok(shelter);
        }

        // DELETE api/shelters/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shelter = _shelterService.Get(id);
            if (shelter == null) return NotFound();
            _shelterService.Remove(shelter);
            return NoContent();
        }
    }
}
