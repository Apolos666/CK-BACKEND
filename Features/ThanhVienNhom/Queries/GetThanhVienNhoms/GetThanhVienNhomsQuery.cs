using AppChiaSeCongThucNauAnBackend.Data;
using AppChiaSeCongThucNauAnBackend.DTOs.ThanhVienNhom;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Queries.GetThanhVienNhoms;

public record GetThanhVienNhomsQuery : IRequest<List<ThanhVienNhomDto>>;

public class GetThanhVienNhomsQueryHandler : IRequestHandler<GetThanhVienNhomsQuery, List<ThanhVienNhomDto>>
{
    private readonly AppDbContext _context;

    public GetThanhVienNhomsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ThanhVienNhomDto>> Handle(GetThanhVienNhomsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ThanhVienNhoms
            .Select(t => new ThanhVienNhomDto(
                t.Id,
                t.Masv,
                t.HoVaTen,
                t.CreatedAt
            ))
            .ToListAsync(cancellationToken);
    }
} 