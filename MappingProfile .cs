using AutoMapper;
using SmartTasksAPI.DTOs;
using SmartTasksAPI.Models;

namespace SmartTasksAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDto, TaskItem>().ReverseMap();
        }
    }
}
