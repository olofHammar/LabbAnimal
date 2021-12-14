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

        [HttpGet]
        [Route("")]
        public List<Animal> GetAnimals()
        {
            List<Animal> animals = _repo.getAll();
            return animals;
        }

        [HttpGet("{id}")]
        public Animal GetAnimalById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
