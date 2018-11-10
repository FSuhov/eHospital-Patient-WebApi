using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PatientBO.Models;
using PatientBO.ViewModels;

namespace PatientAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PatientInfo, PatientView>();
        }
    }
}
