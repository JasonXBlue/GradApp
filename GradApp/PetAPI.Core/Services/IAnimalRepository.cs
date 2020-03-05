using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
        public interface IAnimalRepository
        {
            Animal Add(Animal animal);
            Animal Get(int id);
            IEnumerable<Animal> GetAll();
            IEnumerable<Animal> GetAnimalsForShelter(int id);
            void Remove(Animal animal);
            Animal Update(Animal updatedAnimal);
        }
}
