using arfan.Models;
using arfan.Models.Dto.User;
using arfan.Models.Dto.Service;
using arfan.Models.Dto.Reserve;
using arfan.Models.Dto.RelServicesEmployee;
using arfan.Models.Dto.Profile;
using arfan.Models.Dto.Employee;

namespace arfan
{
    public class MappingConfig : AutoMapper.Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceDTO, Service>();
            CreateMap<Service, ServiceCreateDTO>().ReverseMap();
            CreateMap<ServiceUpdateDTO, Service>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Reserve, ReserveDTO>();
            CreateMap<ReserveDTO, Reserve>();
            CreateMap<Reserve, ReserveCreateDTO>().ReverseMap();
            CreateMap<ReserveUpdateDTO, Reserve>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RelServicesEmployee, RelServicesEmployeeDTO>();
            CreateMap<RelServicesEmployeeDTO, RelServicesEmployee>();

            CreateMap<Profile, ProfileDTO>();
            CreateMap<ProfileDTO, Profile>();
            CreateMap<Profile, ProfileCreateDTO>().ReverseMap();
            CreateMap<ProfileUpdateDTO,Profile>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<EmployeeUpdateDTO, Employee>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}




