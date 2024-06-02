using AutoMapper;
using Dtos.TaiKhoan;
using Models;

namespace Profiles;

public class TaiKhoanProfile : Profile
{
    public TaiKhoanProfile()
    {
        CreateMap<CreateTaiKhoanDto, TaiKhoan>();
    }
}
