using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hocvien_backend.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    HocVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TinhThanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhuongXa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoNha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.HocVienId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBaiViet",
                columns: table => new
                {
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViet", x => x.LoaiBaiVietId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhoaHoc",
                columns: table => new
                {
                    LoaiKhoaHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhoaHoc", x => x.LoaiKhoaHocId);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHan",
                columns: table => new
                {
                    QuyenHanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan", x => x.QuyenHanId);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangHoc",
                columns: table => new
                {
                    TinhTrangHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangHoc", x => x.TinhTrangHocId);
                });

            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    ChuDeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.ChuDeId);
                    table.ForeignKey(
                        name: "FK_ChuDe_LoaiBaiViet_LoaiBaiVietId",
                        column: x => x.LoaiBaiVietId,
                        principalTable: "LoaiBaiViet",
                        principalColumn: "LoaiBaiVietId");
                });

            migrationBuilder.CreateTable(
                name: "KhoaHoc",
                columns: table => new
                {
                    KhoaHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThoiGianHoc = table.Column<int>(type: "int", nullable: false),
                    GioiThieu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    HocPhi = table.Column<float>(type: "real", nullable: false),
                    SoHocVien = table.Column<int>(type: "int", nullable: false),
                    SoLuongMon = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    LoaiKhoaHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHoc", x => x.KhoaHocId);
                    table.ForeignKey(
                        name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocId",
                        column: x => x.LoaiKhoaHocId,
                        principalTable: "LoaiKhoaHoc",
                        principalColumn: "LoaiKhoaHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenHanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TaiKhoanId);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuyenHan_QuyenHanId",
                        column: x => x.QuyenHanId,
                        principalTable: "QuyenHan",
                        principalColumn: "QuyenHanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    BaiVietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiViet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenTacGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NoiDungNgan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ChuDeId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.BaiVietId);
                    table.ForeignKey(
                        name: "FK_BaiViet_ChuDe_ChuDeId",
                        column: x => x.ChuDeId,
                        principalTable: "ChuDe",
                        principalColumn: "ChuDeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKyHoc",
                columns: table => new
                {
                    DangKyHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    HocVienId = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangHocId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHoc", x => x.DangKyHocId);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_HocVien_HocVienId",
                        column: x => x.HocVienId,
                        principalTable: "HocVien",
                        principalColumn: "HocVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_KhoaHoc_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "KhoaHoc",
                        principalColumn: "KhoaHocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocId",
                        column: x => x.TinhTrangHocId,
                        principalTable: "TinhTrangHoc",
                        principalColumn: "TinhTrangHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_ChuDeId",
                table: "BaiViet",
                column: "ChuDeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_TaiKhoanId",
                table: "BaiViet",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDe_LoaiBaiVietId",
                table: "ChuDe",
                column: "LoaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_HocVienId",
                table: "DangKyHoc",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_KhoaHocId",
                table: "DangKyHoc",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_TaiKhoanId",
                table: "DangKyHoc",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_TinhTrangHocId",
                table: "DangKyHoc",
                column: "TinhTrangHocId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_LoaiKhoaHocId",
                table: "KhoaHoc",
                column: "LoaiKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenHanId",
                table: "TaiKhoan",
                column: "QuyenHanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "DangKyHoc");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "KhoaHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TinhTrangHoc");

            migrationBuilder.DropTable(
                name: "LoaiBaiViet");

            migrationBuilder.DropTable(
                name: "LoaiKhoaHoc");

            migrationBuilder.DropTable(
                name: "QuyenHan");
        }
    }
}
