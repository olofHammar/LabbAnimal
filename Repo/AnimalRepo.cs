using System;
using System.Collections.Generic;
using System.Linq;
using LabbAnimal.Entities;

namespace LabbAnimal.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private static List<Animal> _animals = SetAnimalData();

        public AnimalRepo()
        {
            //_animals = SetAnimalData();
        }

        public List<Animal> getAll()
        {
            return _animals;
        }

        public Animal GetById(int id)
        {
            Animal animal = _animals.Find(x => x.Id == id);

            return animal;
        }

        public Animal CreateAnimal(Animal animal)
        {
            animal.Id = _animals.Max(x => x.Id) + 1;
            animal.Created = DateTime.Now;

            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            Animal existingAnimal = _animals.FirstOrDefault(x => x.Id == animal.Id);

            if(existingAnimal != null)
            {
                existingAnimal.Type = animal.Type;
                existingAnimal.Name = animal.Name;
            }

            return existingAnimal;
        }

        public void DeleteAnimal(int id)
        {
            _animals.Remove(GetById(id));
        }

        private static List<Animal> SetAnimalData()
        {
            return new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Type = "Lejon",
                    Name = "Simba",
                    Created = DateTime.Now,
                },
                new Animal
                {
                    Id = 2,
                    Type = "Vårtsvin",
                    Name = "Pumba",
                    Created = DateTime.Now,
                },
                new Animal
                {
                    Id = 3,
                    Type = "Fisk",
                    Name = "Nemo",
                    Created = DateTime.Now,
                },
                new Animal
                {
                    Id = 4,
                    Type = "Katt",
                    Name = "Gustav",
                    Created = DateTime.Now,
                },
                new Animal
                {
                    Id = 5,
                    Type = "Björn",
                    Name = "Brumbrum",
                    Created = DateTime.Now,
                },
            };
        }

    }
}
