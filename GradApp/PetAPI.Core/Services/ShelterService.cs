using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
    public class ShelterService : IShelterService
    {
        private readonly IShelterRepository _shelterRepo;

        public ShelterService(IShelterRepository shelterRepo)
        {
            _shelterRepo = shelterRepo;
        }

        public Shelter Add(Shelter shelter)
        {
            _shelterRepo.Add(shelter);
            return shelter;
        }

        public Shelter Get(int id)
        {
            return _shelterRepo.Get(id);
        }

        public IEnumerable<Shelter> GetAll()
        {
            return _shelterRepo.GetAll();
        }

        public void Remove(Shelter shelter)
        {
            _shelterRepo.Remove(shelter);
        }

        public Shelter Update(Shelter updatedShelter)
        {
            var currentShelter = _shelterRepo.Update(updatedShelter);
            return currentShelter;
        }
    }
}
