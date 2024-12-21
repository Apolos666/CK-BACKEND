using AppChiaSeCongThucNauAnBackend.Data;
using AppChiaSeCongThucNauAnBackend.DTOs.ThanhVienNhom;
using MediatR;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Queries.GetThanhVienNhom;

public record GetThanhVienNhomQuery(Guid Id) : IRequest<ThanhVienNhomDto?>;

public class GetThanhVienNhomQueryHandler : IRequestHandler<GetThanhVienNhomQuery, ThanhVienNhomDto?>
{
    private readonly AppDbContext _context;

    public GetThanhVienNhomQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ThanhVienNhomDto?> Handle(GetThanhVienNhomQuery request, CancellationToken cancellationToken)
    {
        var thanhVienNhom = await _context.ThanhVienNhoms.FindAsync(new object[] { request.Id }, cancellationToken);

        if (thanhVienNhom == null) return null;

        return new ThanhVienNhomDto(
            thanhVienNhom.Id,
            thanhVienNhom.Masv,
            thanhVienNhom.HoVaTen,
            thanhVienNhom.CreatedAt
        );
    }
} 