using AutoMapper;
using Dtos.DangKyHoc;
using Models;

namespace Profiles;

public class DangKyHocProfile : Profile
{
    public DangKyHocProfile()
    {
        CreateMap<CreateDangKyHocDto, DangKyHoc>();
    }
}
