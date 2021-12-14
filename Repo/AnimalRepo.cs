using System;
using System.Collections.Generic;
using LabbAnimal.Entities;

namespace LabbAnimal.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private List<Animal> _animals;

        public AnimalRepo()
        {
            _animals = SetAnimalData();
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

        private List<Animal> SetAnimalData()
        {
            return new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Type = "Lejon",
                    Name = "Simba",
                },
                new Animal
                {
                    Id = 2,
                    Type = "Vårtsvin",
                    Name = "Pumba",
                },
                new Animal
                {
                    Id = 3,
                    Type = "Fisk",
                    Name = "Nemo",
                },
                new Animal
                {
                    Id = 4,
                    Type = "Katt",
                    Name = "Gustav",
                },
                new Animal
                {
                    Id = 5,
                    Type = "Björn",
                    Name = "Brumbrum",
                },
            };
        }
    }
}
