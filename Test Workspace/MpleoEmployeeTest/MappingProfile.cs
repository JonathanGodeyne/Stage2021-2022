using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MpleoEmployeeTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MpleoEmployee, ArnoEmployee>();
        }
    }
}
