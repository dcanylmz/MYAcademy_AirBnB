using AutoMapper;
using MYAcademy_AirBnB.Dtos.CategoryDtos;
using MYAcademy_AirBnB.Dtos.HouseDtos;
using MYAcademy_AirBnB.Entities;

namespace MYAcademy_AirBnB.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


            CreateMap<House, CreateHouseDto>();
            CreateMap<House, UpdateHouseDto>();
            CreateMap<House, ResultHouseDto>().ReverseMap();
            CreateMap<House, GetByIdHouseDto>().ReverseMap();


        }
    }
}
