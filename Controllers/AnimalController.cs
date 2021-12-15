using System;
using System.Collections.Generic;
using LabbAnimal.Entities;
using LabbAnimal.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LabbAnimal.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController: ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalController(IAnimalRepo repo) 
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult GetAnimals()
        {
            List<Animal> animals = _repo.getAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            Animal animal = _repo.GetById(id);

            if (animal == null)
            {
                return NotFound("Couldn't find animal with id " + id + ".");
            }

            return Ok(animal);
        }

        [HttpPost("")]
        public CreatedAtActionResult CreateAnimal([FromBody]Animal animal)
        {
            Animal createdAnimal = _repo.CreateAnimal(animal);

            return CreatedAtAction(
                nameof(GetAnimalById),
                new { id = createdAnimal.Id },
                createdAnimal);
        }

        [HttpPut("")]
        public IActionResult UpdateAnimal([FromBody]Animal animal)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal);

            if (updatedAnimal == null)
            {
                return NotFound("Failed to update animal.");
            }

            return Ok(updatedAnimal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);

            return NoContent();
        }
    }
}
