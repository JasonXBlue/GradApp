using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
    public interface IShelterRepository
    {
        Shelter Add(Shelter shelter);
        Shelter Get(int id);
        IEnumerable<Shelter> GetAll();
        //IEnumerable<Shelter> GetAnimalsForShelter(int id);
        void Remove(Shelter shelter);
        Shelter Update(Shelter updatedShelter);
    }
}

