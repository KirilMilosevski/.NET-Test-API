using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DATA.Entities;
using Models.DTOs;

namespace Models.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}
