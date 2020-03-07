using System;
using System.Collections.Generic;
using System.Linq;
using PetAPI.Core.Models;

namespace PetAPI.ApiModels
{
    public static class ShelterMappingExtensions
    {

        public static ShelterModel ToApiModel(this Shelter shelter)
        {
            return new ShelterModel
            {
                Id = shelter.Id,
                Name = shelter.Name,
                Address = shelter.Address,
                Phone = shelter.Phone,
            };
        }

        public static Shelter ToDomainModel(this ShelterModel shelterModel)
        {
            return new Shelter
            {
                Id = shelterModel.Id,
                Name = shelterModel.Name,
                Address = shelterModel.Address,
                Phone = shelterModel.Phone
            };
        }

        public static IEnumerable<ShelterModel> ToApiModels(this IEnumerable<Shelter> shelters)
        {
            return shelters.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Shelter> ToDomainModel(this IEnumerable<ShelterModel> shelterModels)
        {
            return shelterModels.Select(a => a.ToDomainModel());
        }
    }
}
