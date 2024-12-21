using AppChiaSeCongThucNauAnBackend.Data;
using AppChiaSeCongThucNauAnBackend.DTOs.ThanhVienNhom;
using MediatR;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.CreateThanhVienNhom;

public record CreateThanhVienNhomCommand(string Masv, string HoVaTen) : IRequest<ThanhVienNhomDto>;

public class CreateThanhVienNhomCommandHandler : IRequestHandler<CreateThanhVienNhomCommand, ThanhVienNhomDto>
{
    private readonly AppDbContext _context;

    public CreateThanhVienNhomCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ThanhVienNhomDto> Handle(CreateThanhVienNhomCommand request, CancellationToken cancellationToken)
    {
        var thanhVienNhom = new Models.ThanhVienNhom
        {
            Masv = request.Masv,
            HoVaTen = request.HoVaTen,
            CreatedAt = DateTime.UtcNow
        };

        _context.ThanhVienNhoms.Add(thanhVienNhom);
        await _context.SaveChangesAsync(cancellationToken);

        return new ThanhVienNhomDto(
            thanhVienNhom.Id,
            thanhVienNhom.Masv,
            thanhVienNhom.HoVaTen,
            thanhVienNhom.CreatedAt
        );
    }
} 