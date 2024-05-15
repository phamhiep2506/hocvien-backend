using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Models;

namespace Profiles;

public class LoaiKhoaHocProfile : Profile
{
    public LoaiKhoaHocProfile()
    {
        CreateMap<CreateLoaiKhoaHocDto, LoaiKhoaHoc>();
        CreateMap<UpdateLoaiKhoaHocDto, LoaiKhoaHoc>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
        CreateMap<LoaiKhoaHoc, GetLoaiKhoaHocDto>();
    }
}
