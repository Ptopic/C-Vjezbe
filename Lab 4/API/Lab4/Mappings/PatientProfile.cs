
using System;
using AutoMapper;

namespace Lab4.Mappings
{
	public class PatientProfile : Profile
	{
		public PatientProfile()
		{
            CreateMap<Entities.Patient, Models.PatientDto>();
            CreateMap<Models.PatientCreationDto, Entities.Patient>();
        }
	}
}

