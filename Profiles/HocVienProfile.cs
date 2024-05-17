using AutoMapper;
using Dtos.HocVien;
using Models;

namespace Profiles;

public class HocVienProfile : Profile
{
    public HocVienProfile()
    {
        CreateMap<CreateHocVienDto, HocVien>();
    }
}
