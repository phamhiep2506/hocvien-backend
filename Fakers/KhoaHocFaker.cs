using Bogus;
using Dtos.KhoaHoc;

namespace Fakers;

public class KhoaHocFaker : Faker<CreateKhoaHocDto>
{
    public KhoaHocFaker()
    {
        var lorem = new Bogus.DataSets.Lorem("vi");

        Rules((f, o) => {
            o.TenKhoaHoc = lorem.Sentence(1, 5);
            o.ThoiGianHoc = f.Random.Int(1, 12);
            o.GioiThieu = lorem.Sentence(20);
            o.NoiDung = lorem.Sentence(20);
            o.HocPhi = f.Random.Float(1, 90000000);
            o.SoHocVien = f.Random.Int(1, 10);
            o.SoLuongMon = f.Random.Int(1, 10);
            o.HinhAnh = f.Image.PicsumUrl();
            o.LoaiKhoaHocId = 6;
        });
    }
}