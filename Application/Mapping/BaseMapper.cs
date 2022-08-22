using Application.Dtos;
using Application.Features.Request.Commands;
using Application.Features.Request.Commands.ContactCommands;
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
            CreateMap<Contact, ContactDto>().ReverseMap();

            CreateMap<Contact, AddContactCommand>().ReverseMap();

            CreateMap<Contact, DeleteContactCommand>().ReverseMap();

            CreateMap<Contact, UpdateContactCommand>().ReverseMap();

        }
    }
}
