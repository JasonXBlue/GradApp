using System;
using System.Collections.Generic;
using PetAPI.Core.Models;

namespace PetAPI.Core.Services
{
   
        public interface IAnimalService
        {
            // CRUDL - create (add), read (get), update, delete (remove), list

            // create
            Animal Add(Animal animal);
            // read
            Animal Get(int id);
            // update
            Animal Update(Animal animal);
            // delete
            void Remove(Animal animal);
            // list
            IEnumerable<Animal> GetAll();
        }
    
}
