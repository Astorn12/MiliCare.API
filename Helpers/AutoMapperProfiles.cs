using AutoMapper;
using MiliCare.DTOs;
using MiliCare.Model;

namespace MiliCare.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        

         public AutoMapperProfiles(){
            CreateMap<UserForRegisterDto,User>();//
            CreateMap<SensorMeasurmenToAddDto,SensorMeasurment>();
            CreateMap<SensorMeasurmentToReturnDto,SensorMeasurment>();
            CreateMap<SensorMeasurment,SensorMeasurmentToReturnDto>();
        }
    }
}