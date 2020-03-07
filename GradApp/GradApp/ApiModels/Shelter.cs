using System;
using System.Collections.Generic;

namespace PetAPI.ApiModels
{
    public class ShelterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<AnimalModel> Animals { get; set; }
    }
}
