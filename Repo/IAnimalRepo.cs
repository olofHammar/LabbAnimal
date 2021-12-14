﻿using System;
using System.Collections.Generic;
using LabbAnimal.Entities;

namespace LabbAnimal.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> getAll();

        Animal GetById(int Id);
    }
}