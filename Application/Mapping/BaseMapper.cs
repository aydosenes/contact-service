using Application.Dtos;
using Application.Features.Request.Commands;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            CreateMap<Test, TestDto>().ReverseMap();

            CreateMap<Test, AddTestCommand>().ReverseMap();

            CreateMap<Test, DeleteTestCommand>().ReverseMap();

            CreateMap<Test, UpdateTestCommand>().ReverseMap();

        }
    }
}
