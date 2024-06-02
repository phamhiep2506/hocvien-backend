using AutoMapper;
using Dtos.QuyenHan;
using Models;

namespace Profiles;

public class QuyenHanProfile : Profile
{
    public QuyenHanProfile()
    {
        CreateMap<CreateQuyenHanDto, QuyenHan>();
        CreateMap<UpdateQuyenHanDto, QuyenHan>();
        CreateMap<QuyenHan, GetQuyenHanDto>();
    }
}
