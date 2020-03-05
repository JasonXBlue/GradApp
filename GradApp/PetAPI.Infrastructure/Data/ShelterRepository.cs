using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetAPI.Core.Models;
using PetAPI.Core.Services;

namespace PetAPI.Infrastructure.Data
{

    public class ShelterRepository : IShelterRepository
    {
        private readonly AnimalContext _animalContext;

        public ShelterRepository(AnimalContext animalContext)
        {
            _animalContext = animalContext;

        }

        public Shelter Add(Shelter shelter)
        {
            _animalContext.Shelters.Add(shelter);
            _animalContext.SaveChanges();
            return shelter;
        }

        public Shelter Get(int id)
        {
            return _animalContext.Shelters
                .Include(b => b.Animals)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Shelter> GetAll()
        {
            return _animalContext.Shelters
                .Include(b => b.Animals)
                .ToList();
        }

        //public IEnumerable<Shelter> GetAnimalsForShelter(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Remove(Shelter shelter)
        {
            _animalContext.Shelters.Remove(shelter);
            _animalContext.SaveChanges();
        }

        public Shelter Update(Shelter updatedShelter)
        {
            var currentShelter = _animalContext.Shelters.Find(updatedShelter);

            if (currentShelter == null) return null;

            _animalContext.Entry(currentShelter)
                .CurrentValues
                .SetValues(updatedShelter);

            _animalContext.Shelters.Update(currentShelter);
            _animalContext.SaveChanges();
            return currentShelter;
        }
    }
}
