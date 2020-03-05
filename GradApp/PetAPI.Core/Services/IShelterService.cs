using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
    public interface IShelterService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        Shelter Add(Shelter shelter);
        // read
        Shelter Get(int id);
        // update
        Shelter Update(Shelter shelter);
        // delete
        void Remove(Shelter shelter);
        // list
        IEnumerable<Shelter> GetAll();
    }
}
