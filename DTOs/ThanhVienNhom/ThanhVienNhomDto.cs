namespace AppChiaSeCongThucNauAnBackend.DTOs.ThanhVienNhom;

public record ThanhVienNhomDto(Guid Id, string Masv, string HoVaTen, DateTime CreatedAt);

public record CreateThanhVienNhomDto
{
    public required string Masv { get; set; }
    public required string HoVaTen { get; set; }
}

public record UpdateThanhVienNhomDto
{
    public required string Masv { get; set; }
    public required string HoVaTen { get; set; }
} 