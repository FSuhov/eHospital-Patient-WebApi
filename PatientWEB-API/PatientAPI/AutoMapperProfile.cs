using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PatientBO.Models;
using PatientBO.ViewModels;

namespace PatientAPI
{
    /// <summary>
    /// Class that configures Automapper
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes new instance of AutoMapperProfile,
        /// setting mapping configuration for PatientInfo=>PatientView
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<PatientInfo, PatientView>();
        }
    }
}
