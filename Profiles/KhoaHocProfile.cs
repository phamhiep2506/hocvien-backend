using AutoMapper;
using Dtos;
using Models;

namespace Profiles;

public class KhoaHocProfile : Profile
{
    public KhoaHocProfile()
    {
        CreateMap<CreateKhoaHocDto, KhoaHoc>();
    }
}
