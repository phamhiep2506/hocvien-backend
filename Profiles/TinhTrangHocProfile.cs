using AutoMapper;
using Dtos.TinhTrangHoc;
using Models;

namespace Profiles;

public class TinhTrangHocProfile : Profile
{
    public TinhTrangHocProfile()
    {
        CreateMap<CreateTinhTrangHocDto, TinhTrangHoc>();
        CreateMap<UpdateTinhTrangHocDto, TinhTrangHoc>();
        CreateMap<TinhTrangHoc, GetTinhTrangHocDto>();
    }
}
