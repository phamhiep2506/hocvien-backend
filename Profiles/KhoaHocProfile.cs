using AutoMapper;
using Dtos;
using Models;

namespace Profiles;

public class KhoaHocProfile : Profile
{
    public KhoaHocProfile()
    {
        CreateMap<CreateKhoaHocDto, KhoaHoc>();
        CreateMap<UpdateKhoaHocDto, KhoaHoc>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
    }
}
