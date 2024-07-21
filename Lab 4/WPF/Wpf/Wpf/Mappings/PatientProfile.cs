using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, Models.PatientDto>();
            CreateMap<Models.PatientCreateDto, Entities.Patient>();
        }
    }
}
