using System;
using AutoMapper;

namespace Lab4.Mappings
{
	public class DiagnosisProfile : Profile
	{
		public DiagnosisProfile()
		{
            CreateMap<Entities.Diagnosis, Models.DiagnosisDto>();
        }
	}
}

