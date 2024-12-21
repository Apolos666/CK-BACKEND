using AppChiaSeCongThucNauAnBackend.Data;
using MediatR;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.UpdateThanhVienNhom;

public record UpdateThanhVienNhomCommand(Guid Id, string Masv, string HoVaTen) : IRequest<bool>;

public class UpdateThanhVienNhomCommandHandler : IRequestHandler<UpdateThanhVienNhomCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateThanhVienNhomCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateThanhVienNhomCommand request, CancellationToken cancellationToken)
    {
        var thanhVienNhom = await _context.ThanhVienNhoms.FindAsync(new object[] { request.Id }, cancellationToken);

        if (thanhVienNhom == null) return false;

        thanhVienNhom.Masv = request.Masv;
        thanhVienNhom.HoVaTen = request.HoVaTen;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
} 