namespace AppChiaSeCongThucNauAnBackend.Models;

public class ThanhVienNhom
{
    public Guid Id { get; set; }
    public required string Masv { get; set; }
    public required string HoVaTen { get; set; }
    public DateTime CreatedAt { get; set; }
}