using AutoMapper;
using CRUD_Mini_Project.Models;
using CRUD_Mini_Project.Models.Viewmodel;

namespace CRUD_Mini_Project.Mappings
{
    public class AutoMapperProfile : Profile // Inherits from AutoMapper.Profile
    {
        // 🔑 FIX: The mapping configuration MUST be defined inside the constructor.
        public AutoMapperProfile()
        {
            // --- Entity to ViewModel Mapping (Read/Display) ---
            CreateMap<Analyse, AnalyseViewModel>()
             .ForMember(dest => dest.sampleType,
                       opt => opt.MapFrom(src => src.sample_type));

            // --- ViewModel to Entity Mapping (Write/Save) ---
            CreateMap<AnalyseViewModel, Analyse>();

            // --- Two-Way Mapping for simpler entities ---
            CreateMap<Method, MethodViewModel>().ReverseMap();
            CreateMap<Parameter, ParameterViewModel>().ReverseMap();
            CreateMap<SampleType, SampleTypeViewModel>().ReverseMap();
        }
    }
}