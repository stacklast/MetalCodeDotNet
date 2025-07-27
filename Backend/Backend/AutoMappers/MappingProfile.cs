using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.AutoMappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            //in, out campos iguales
            CreateMap<BeerInsertDto, Beer>();

            //in, out con un campo diferente
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id, m=> m.MapFrom(beer => beer.BeerID));
        }
    }
}
