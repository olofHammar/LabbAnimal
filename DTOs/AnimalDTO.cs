using System;
using LabbAnimal.Entities;

namespace LabbAnimal.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public static AnimalDTO MapAnimalToAnimalDTO(Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Type = animal.Type,
                Name = animal.Name
            };
        }
    }
}
