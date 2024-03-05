using AutoMapper;
using TestUkrposhta.DTOs;
using TestUkrposhta.Models;

namespace TestUkrposhta.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // dto => read model
            CreateMap<Employee, EmployeeReadModel>()
                .ForMember(model => model.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(model => model.FullName, opt =>
                    opt.MapFrom(dto => dto.FullName))
                .ForMember(model => model.Address, opt =>
                    opt.MapFrom(dto => dto.Address ?? string.Empty))
                .ForMember(model => model.PhoneNumber, opt =>
                    opt.MapFrom(dto => dto.PhoneNumber ?? string.Empty))
                .ForMember(model => model.Salary, opt =>
                    opt.MapFrom(dto => dto.Salary))
                .ForMember(model => model.BirthDate, opt =>
                    opt.MapFrom(dto => dto.BirthDate))
                .ForMember(model => model.HireDate, opt =>
                    opt.MapFrom(dto => dto.HireDate))
                .ForMember(model => model.CompanyName, opt =>
                    opt.MapFrom(dto => dto.CompanyName ?? string.Empty))
                .ForMember(model => model.DepartamentName, opt =>
                    opt.MapFrom(dto => dto.DepartamentName ?? string.Empty))
                .ForMember(model => model.PositionName, opt =>
                    opt.MapFrom(dto => dto.PositionName ?? string.Empty));

            // dto => update model (ReverseMap)
            CreateMap<Employee, EmployeeUpdateModel>()
                .ForMember(model => model.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(model => model.FullName, opt =>
                    opt.MapFrom(dto => dto.FullName))
                .ForMember(model => model.Address, opt =>
                    opt.MapFrom(dto => dto.Address ?? string.Empty))
                .ForMember(model => model.PhoneNumber, opt =>
                    opt.MapFrom(dto => dto.PhoneNumber ?? string.Empty))
                .ForMember(model => model.Salary, opt =>
                    opt.MapFrom(dto => dto.Salary))
                .ForMember(model => model.BirthDate, opt =>
                    opt.MapFrom(dto => dto.BirthDate))
                .ForMember(model => model.HireDate, opt =>
                    opt.MapFrom(dto => dto.HireDate))
                /*.ForMember(model => model.CompanyID, opt =>
                    opt.MapFrom(dto => dto.CompanyID))*/
                .ForMember(model => model.DepartamentID, opt =>
                    opt.MapFrom(dto => dto.DepartamentID))
                .ForMember(model => model.PositionID, opt =>
                    opt.MapFrom(dto => dto.PositionID))
                .ReverseMap();

            // model => dto
            CreateMap<EmployeeFilterModel, EmployeeFilter>()
                .ForMember(dto => dto.FullName, opt =>
                    opt.MapFrom(model => model.FullName))
                .ForMember(dto => dto.MinSalary, opt =>
                    opt.MapFrom(model => model.MinSalary))
                .ForMember(dto => dto.MaxSalary, opt =>
                    opt.MapFrom(model => model.MaxSalary))
                .ForMember(dto => dto.PositionID, opt =>
                    opt.MapFrom(model => model.PositionID))
                .ForMember(dto => dto.DepartamentID, opt =>
                    opt.MapFrom(model => model.DepartamentID));

            // dto => read model
            CreateMap<Company, CompanyReadModel>()
                .ForMember(model => model.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(model => model.Name, opt =>
                    opt.MapFrom(dto => dto.Name))
                .ForMember(model => model.Info, opt =>
                    opt.MapFrom(dto => dto.Info));

            // dto => read model
            CreateMap<Departament, DepartamentReadModel>()
                .ForMember(model => model.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(model => model.Name, opt =>
                    opt.MapFrom(dto => dto.Name));

            // dto => read model
            CreateMap<Position, PositionReadModel>()
                .ForMember(model => model.ID, opt =>
                    opt.MapFrom(dto => dto.ID))
                .ForMember(model => model.Name, opt =>
                    opt.MapFrom(dto => dto.Name));
        }
    }
}
