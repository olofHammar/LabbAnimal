using System;
using System.Collections.Generic;
using System.Linq;
using LabbAnimal.DTOs;
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
            var animals = _repo
                .getAll()
                .Select(a => new AnimalDTO
                {
                    Id = a.Id,
                    Type = a.Type,
                    Name = a.Name,
                })
                .OrderBy(x => x.Type);

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

            AnimalDTO animalDTO = AnimalDTO.MapAnimalToAnimalDTO(animal);

            return Ok(animalDTO);
        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody]CreateAnimalDTO createAnimalDTO)
        {
            Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            AnimalDTO animalDTO = AnimalDTO.MapAnimalToAnimalDTO(createdAnimal);

            return CreatedAtAction(
                nameof(GetAnimalById),
                new { id = animalDTO.Id },
                animalDTO);
        }

        [HttpPut("")]
        public IActionResult UpdateAnimal([FromBody]Animal animal)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal);

            if (updatedAnimal == null)
            {
                return NotFound("Failed to update animal.");
            }

            AnimalDTO animalDTO = AnimalDTO.MapAnimalToAnimalDTO(updatedAnimal);

            return Ok(animalDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            Animal animal = _repo.GetById(id);

            if (animal == null)
            {
                return NotFound("Couldn't find animal with id " + id + ".");
            }

            _repo.DeleteAnimal(id);

            return Ok("Animal with id " + id + " succefully deleted.");
        }
    }
}
