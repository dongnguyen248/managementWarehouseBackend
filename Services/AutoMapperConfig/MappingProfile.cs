using AutoMapper;
using Data;
using DTO;

namespace Services.AutoMapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CostAccount, CostAccountDTO>().ReverseMap();
            CreateMap<CostAccountItem, CostAccountItemDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<ExportHistory, ExportHistoryDTO>().ReverseMap();
            CreateMap<ImportHistory, ImportHistoryDTO>().ReverseMap();
            CreateMap<ImportHistory, ImportHistoryDTOUpdate>().ReverseMap();
            CreateMap<Inspection, InspectionDTO>().ReverseMap();
            CreateMap<Line, LineDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<Zone, ZoneDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}