using AutoMapper;
using Dtos.HocVien;
using Models;

namespace Profiles;

public class HocVienProfile : Profile
{
    public HocVienProfile()
    {
        CreateMap<CreateHocVienDto, HocVien>();
        CreateMap<UpdateHocVienDto, HocVien>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
        ;
        CreateMap<HocVien, GetHocVienDto>();
    }
}
