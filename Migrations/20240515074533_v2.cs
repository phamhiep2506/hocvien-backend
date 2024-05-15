using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hocvien_backend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_ChuDe_ChuDeId",
                table: "BaiViet");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_TaiKhoan_TaiKhoanId",
                table: "BaiViet");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_HocVien_HocVienId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_KhoaHoc_KhoaHocId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TaiKhoan_TaiKhoanId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_QuyenHan_QuyenHanId",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanId",
                table: "TaiKhoan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocId",
                table: "KhoaHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "HocPhi",
                table: "KhoaHoc",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocId",
                table: "DangKyHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "DangKyHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocId",
                table: "DangKyHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HocVienId",
                table: "DangKyHoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViet",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "BaiViet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeId",
                table: "BaiViet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_ChuDe_ChuDeId",
                table: "BaiViet",
                column: "ChuDeId",
                principalTable: "ChuDe",
                principalColumn: "ChuDeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_TaiKhoan_TaiKhoanId",
                table: "BaiViet",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_HocVien_HocVienId",
                table: "DangKyHoc",
                column: "HocVienId",
                principalTable: "HocVien",
                principalColumn: "HocVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_KhoaHoc_KhoaHocId",
                table: "DangKyHoc",
                column: "KhoaHocId",
                principalTable: "KhoaHoc",
                principalColumn: "KhoaHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TaiKhoan_TaiKhoanId",
                table: "DangKyHoc",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocId",
                table: "DangKyHoc",
                column: "TinhTrangHocId",
                principalTable: "TinhTrangHoc",
                principalColumn: "TinhTrangHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "KhoaHoc",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHoc",
                principalColumn: "LoaiKhoaHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_QuyenHan_QuyenHanId",
                table: "TaiKhoan",
                column: "QuyenHanId",
                principalTable: "QuyenHan",
                principalColumn: "QuyenHanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_ChuDe_ChuDeId",
                table: "BaiViet");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_TaiKhoan_TaiKhoanId",
                table: "BaiViet");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_HocVien_HocVienId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_KhoaHoc_KhoaHocId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TaiKhoan_TaiKhoanId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocId",
                table: "DangKyHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "KhoaHoc");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_QuyenHan_QuyenHanId",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanId",
                table: "TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocId",
                table: "KhoaHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "HocPhi",
                table: "KhoaHoc",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocId",
                table: "DangKyHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "DangKyHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHoc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocId",
                table: "DangKyHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HocVienId",
                table: "DangKyHoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanId",
                table: "BaiViet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeId",
                table: "BaiViet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_ChuDe_ChuDeId",
                table: "BaiViet",
                column: "ChuDeId",
                principalTable: "ChuDe",
                principalColumn: "ChuDeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_TaiKhoan_TaiKhoanId",
                table: "BaiViet",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "TaiKhoanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_HocVien_HocVienId",
                table: "DangKyHoc",
                column: "HocVienId",
                principalTable: "HocVien",
                principalColumn: "HocVienId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_KhoaHoc_KhoaHocId",
                table: "DangKyHoc",
                column: "KhoaHocId",
                principalTable: "KhoaHoc",
                principalColumn: "KhoaHocId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TaiKhoan_TaiKhoanId",
                table: "DangKyHoc",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "TaiKhoanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHoc_TinhTrangHoc_TinhTrangHocId",
                table: "DangKyHoc",
                column: "TinhTrangHocId",
                principalTable: "TinhTrangHoc",
                principalColumn: "TinhTrangHocId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHoc_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "KhoaHoc",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHoc",
                principalColumn: "LoaiKhoaHocId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_QuyenHan_QuyenHanId",
                table: "TaiKhoan",
                column: "QuyenHanId",
                principalTable: "QuyenHan",
                principalColumn: "QuyenHanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
