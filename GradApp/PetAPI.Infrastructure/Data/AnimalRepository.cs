using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetAPI.Core.Models;
using PetAPI.Core.Services;

namespace PetAPI.Infrastructure.Data
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalContext _animalContext;

        public AnimalRepository(AnimalContext animalContext)
        {
            _animalContext = animalContext;
        }

        public Animal Add(Animal animal)
        {
            _animalContext.Animals.Add(animal);
            _animalContext.SaveChanges();
            return animal;
        }

        public Animal Get(int id)
        {
            return _animalContext.Animals
                .Include(b => b.Shelter)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animalContext.Animals
                .Include(b => b.Shelter)
                .ToList();
        }

        public IEnumerable<Animal> GetAnimalsForShelter(int id)
        {
            return _animalContext.Animals
                .Include(b => b.Shelter)
                .Where(b => b.ShelterId == id)
                .ToList();
        }

        public void Remove(Animal animal)
        {
            _animalContext.Animals.Remove(animal);
            _animalContext.SaveChanges();
        }

        public Animal Update(Animal updatedAnimal)
        {
            var currentAnimal = _animalContext.Animals.Find(updatedAnimal.Id);

            if (currentAnimal == null) return null;

            _animalContext.Entry(currentAnimal)
                .CurrentValues
                .SetValues(updatedAnimal);

            _animalContext.Animals.Update(currentAnimal);
            _animalContext.SaveChanges();
            return currentAnimal;
        }
    }

}
