using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepo;

        public AnimalService(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public Animal Add(Animal animal)
        {
            _animalRepo.Add(animal);
            return animal;
        }

        public Animal Get(int id)
        {
            return _animalRepo.Get(id);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animalRepo.GetAll();
        }

        public void Remove(Animal animal)
        {
            _animalRepo.Remove(animal);
        }

        public Animal Update(Animal updatedAnimal)
        {
            var currentAnimal = _animalRepo.Update(updatedAnimal);
            return currentAnimal;
        }
    }
}
