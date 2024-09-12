using AutoMapper;
using Core.DTOs;
using Core.Models;


namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<MontageLetter, MontageLetterDto>().ReverseMap();
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<Part,PartDto>().ReverseMap();
            CreateMap<Pattern, PatternDto>().ReverseMap();
            CreateMap<RootAnalysis, RootAnalysisDto>().ReverseMap();
            CreateMap<Unit, UnitDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();    
            CreateMap<ErrorDetectionLocation, ErrorDetectionLocationDto>().ReverseMap();
            CreateMap<Field, FieldDto>().ReverseMap();
            CreateMap<MoneyType,MoneyTypeDto>().ReverseMap();
            CreateMap<Cost,CostDto>().ReverseMap();
            CreateMap<ErrorDefine,ErrorDefineDto>().ReverseMap();
            CreateMap<SolutionAndStandardizition, SolutionAndStandardizitionDto>().ReverseMap();
            CreateMap<ErrorClosingReason, ErrorClosingReasonDto>().ReverseMap();
            CreateMap<ErrorClass, ErrorClassDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<ErrorMainTitle,ErrorMainTitleDto>().ReverseMap();
            CreateMap<ErrorSubGroup, ErrorSubGroupDto>().ReverseMap();
            CreateMap<ErrorDetailGroup, ErrorDetailGroupDto>().ReverseMap();
            CreateMap<ErrorType, ErrorTypeDto>().ReverseMap();
            CreateMap<ErrorCard,ErrorCardDto>().ReverseMap();
            CreateMap<Media,MediaDto>().ReverseMap();




        }

    }
}
