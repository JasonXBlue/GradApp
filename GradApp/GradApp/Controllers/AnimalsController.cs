using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetAPI.ApiModels;
using PetAPI.Core.Services;

namespace GradApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            var animalModels = _animalService
                .GetAll()
                .ToApiModels();

            return Ok(animalModels);
        }


        // GET api/animals/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = _animalService.Get(id);
            if (animal == null) return NotFound();
            return Ok(animal.ToApiModel());
               
        }

        // POST api/animals
        [HttpPost]
        public IActionResult Post([FromBody] AnimalModel newAnimal)
        {
            try
            {
                _animalService.Add(newAnimal.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddAnimal", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newAnimal.Id }, newAnimal);
        }

        // PUT api/animals/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnimalModel updatedAnimal)
        {
            var animal = _animalService.Update(updatedAnimal.ToDomainModel());
            if (animal == null) return NotFound();
            return Ok(animal.ToApiModel());
        }

        // DELETE api/animals/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = _animalService.Get(id);
            if (animal == null) return NotFound();
            _animalService.Remove(animal);
            return NoContent();
        }
    }
}
