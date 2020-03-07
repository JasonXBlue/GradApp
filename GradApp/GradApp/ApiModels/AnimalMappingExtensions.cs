using System;
using System.Collections.Generic;
using System.Linq;
using PetAPI.Core.Models;

namespace PetAPI.ApiModels
{
    public static class AnimalMappingExtensions
    {

        public static AnimalModel ToApiModel(this Animal animal)
        {
            return new AnimalModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
                Age = animal.Age,
                ShelterId = animal.ShelterId,
                Shelter = animal.Shelter != null
                    ? animal.Shelter.Name + ", " + animal.Shelter.Address
                    : null
            };
        }

        public static Animal ToDomainModel(this AnimalModel animalModel)
        {
            return new Animal
            {
                Id = animalModel.Id,
                Name = animalModel.Name,
                Type = animalModel.Type,
                Age = animalModel.Age,
                ShelterId = animalModel.ShelterId
            };
        }

        public static IEnumerable<AnimalModel> ToApiModels(this IEnumerable<Animal> animals)
        {
            return animals.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Animal> ToDomainModel(this IEnumerable<AnimalModel> animalModels)
        {
            return animalModels.Select(a => a.ToDomainModel());
        }
    }
}
