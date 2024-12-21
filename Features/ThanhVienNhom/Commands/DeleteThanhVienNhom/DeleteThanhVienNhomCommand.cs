using AppChiaSeCongThucNauAnBackend.Data;
using MediatR;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.DeleteThanhVienNhom;

public record DeleteThanhVienNhomCommand(Guid Id) : IRequest<bool>;

public class DeleteThanhVienNhomCommandHandler : IRequestHandler<DeleteThanhVienNhomCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteThanhVienNhomCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteThanhVienNhomCommand request, CancellationToken cancellationToken)
    {
        var thanhVienNhom = await _context.ThanhVienNhoms.FindAsync(new object[] { request.Id }, cancellationToken);

        if (thanhVienNhom == null) return false;

        _context.ThanhVienNhoms.Remove(thanhVienNhom);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
} 