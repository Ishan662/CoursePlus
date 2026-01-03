using AutoMapper;
using CoursePlus.Application.DTOs;
using CoursePlus.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePlus.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CreateCourseDTO, Course>();
        }
    }
}
