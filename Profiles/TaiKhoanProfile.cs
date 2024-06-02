using AutoMapper;
using Dtos.TaiKhoan;
using Models;

namespace Profiles;

public class TaiKhoanProfile : Profile
{
    public TaiKhoanProfile()
    {
        CreateMap<CreateTaiKhoanDto, TaiKhoan>();
        CreateMap<UpdateTaiKhoanDto, TaiKhoan>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
        ;
        CreateMap<TaiKhoan, GetTaiKhoanDto>();
    }
}
