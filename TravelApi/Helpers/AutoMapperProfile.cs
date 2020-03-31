using AutoMapper;
using TravelApi.Dtos;
using TravelApi.Models;

namespace WebApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserDto>();
      CreateMap<UserDto, User>();
    }
  }
}