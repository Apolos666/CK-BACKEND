using AppChiaSeCongThucNauAnBackend.DTOs.ThanhVienNhom;
using AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.CreateThanhVienNhom;
using AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.DeleteThanhVienNhom;
using AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Commands.UpdateThanhVienNhom;
using AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Queries.GetThanhVienNhom;
using AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom.Queries.GetThanhVienNhoms;
using Carter;
using MediatR;

namespace AppChiaSeCongThucNauAnBackend.Features.ThanhVienNhom;

public class ThanhVienNhomEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/thanhviennhom").WithTags("ThanhVienNhom");

        group.MapGet("/", GetThanhVienNhoms)
            .WithName("GetThanhVienNhoms")
            .AllowAnonymous();

        group.MapGet("/{id}", GetThanhVienNhom)
            .WithName("GetThanhVienNhom")
            .AllowAnonymous();

        group.MapPost("/", CreateThanhVienNhom)
            .WithName("CreateThanhVienNhom")
            .AllowAnonymous();

        group.MapPut("/{id}", UpdateThanhVienNhom)
            .WithName("UpdateThanhVienNhom")
            .AllowAnonymous();

        group.MapDelete("/{id}", DeleteThanhVienNhom)
            .WithName("DeleteThanhVienNhom")
            .AllowAnonymous();
    }

    private async Task<IResult> GetThanhVienNhoms(ISender sender)
    {
        var query = new GetThanhVienNhomsQuery();
        var thanhVienNhoms = await sender.Send(query);
        return Results.Ok(thanhVienNhoms);
    }

    private async Task<IResult> GetThanhVienNhom(Guid id, ISender sender)
    {
        var query = new GetThanhVienNhomQuery(id);
        var thanhVienNhom = await sender.Send(query);
        return thanhVienNhom != null ? Results.Ok(thanhVienNhom) : Results.NotFound();
    }

    private async Task<IResult> CreateThanhVienNhom(CreateThanhVienNhomDto dto, ISender sender)
    {
        var command = new CreateThanhVienNhomCommand(dto.Masv, dto.HoVaTen);
        var result = await sender.Send(command);
        return Results.CreatedAtRoute("GetThanhVienNhom", new { id = result.Id }, result);
    }

    private async Task<IResult> UpdateThanhVienNhom(Guid id, UpdateThanhVienNhomDto dto, ISender sender)
    {
        var command = new UpdateThanhVienNhomCommand(id, dto.Masv, dto.HoVaTen);
        var success = await sender.Send(command);
        return success ? Results.NoContent() : Results.NotFound();
    }

    private async Task<IResult> DeleteThanhVienNhom(Guid id, ISender sender)
    {
        var command = new DeleteThanhVienNhomCommand(id);
        var success = await sender.Send(command);
        return success ? Results.NoContent() : Results.NotFound();
    }
} 