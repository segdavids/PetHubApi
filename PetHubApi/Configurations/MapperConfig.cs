using AutoMapper;
using PetHubApi.Data;
using PetHubApi.Dto.Breed;
using PetHubApi.Dto.Country;
using PetHubApi.Dto.Pet;

namespace PetHubApi.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Country,CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Pet, PetDto>().ReverseMap();
            CreateMap<Breed, BreedDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
