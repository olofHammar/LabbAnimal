using System;
using System.Collections.Generic;
using LabbAnimal.DTOs;
using LabbAnimal.Entities;

namespace LabbAnimal.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> getAll();

        Animal GetById(int Id);

        Animal CreateAnimal(CreateAnimalDTO animalDTO);

        Animal UpdateAnimal(Animal animal);

        void DeleteAnimal(int id);
    }
}
