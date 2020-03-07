using System;
namespace PetAPI.ApiModels
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }

        public int ShelterId { get; set; }
        public string Shelter { get; set; }
    }
}
