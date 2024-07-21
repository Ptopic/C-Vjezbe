using AutoMapper;

namespace Lab5_6.Mappings
{
    public class DiagnosisProfile: Profile
    {
        public DiagnosisProfile()
        {
            CreateMap<Entities.Diagnosis, Models.DiagnosisDto>();
        }
    }
}
