using AutoMapper;

namespace Sureze;

public class SurezeApplicationAutoMapperProfile : Profile
{
    public SurezeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Patient, PatientDto>();
        CreateMap<CreateUpdatePatientDto, Patient>();
    }
}
