using AutoMapper;

namespace Lab5_6.Mappings
{
    public class PatientProfile: Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, Models.PatientDto>();
            CreateMap<Models.PatientCreationDto, Entities.Patient>();
        }
    }
}
