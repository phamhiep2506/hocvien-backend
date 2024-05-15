using AutoMapper;
using Dtos.KhoaHoc;
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
        CreateMap<KhoaHoc, GetKhoaHocDto>();
    }
}
