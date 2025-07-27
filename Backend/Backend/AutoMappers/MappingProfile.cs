using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.AutoMappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            //in, out
            CreateMap<BeerInsertDto, Beer>();
        }
    }
}
