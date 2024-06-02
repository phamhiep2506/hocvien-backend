using AutoMapper;
using Dtos.DangKyHoc;
using Models;

namespace Profiles;

public class DangKyHocProfile : Profile
{
    public DangKyHocProfile()
    {
        CreateMap<CreateDangKyHocDto, DangKyHoc>();
        CreateMap<UpdateDangKyHocDto, DangKyHoc>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
        ;
        CreateMap<DangKyHoc, GetDangKyHocDto>();
    }
}
