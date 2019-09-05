using AutoMapper.Configuration;
using Rodolfo.Schmidt.Application.Dto;
using Rodolfo.Schmidt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.Application.Mapping
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {

            CreateMap<PersonDto, Person>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ReverseMap();
                
        }
    }
}
