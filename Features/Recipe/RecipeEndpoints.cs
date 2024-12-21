
using AppChiaSeCongThucNauAnBackend.Features.Recipe.Queries.GetRecipe;
using AppChiaSeCongThucNauAnBackend.Features.Recipe.Queries.GetRecipes;
using AppChiaSeCongThucNauAnBackend.Features.Recipe.Dtos;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace AppChiaSeCongThucNauAnBackend.Features.Recipe;

public class RecipeEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/recipes").WithTags("Recipes");
        
        group.MapGet("/{id}", GetRecipe)
            .WithName("GetRecipe")
            .AllowAnonymous();

        group.MapGet("/", GetRecipes)
            .WithName("GetRecipes")
            .AllowAnonymous();
    }
    
    private async Task<IResult> GetRecipe(Guid id, HttpContext httpContext, ISender sender)
    {
        Guid? currentUserId = null;
        var query = new GetRecipeQuery(id, currentUserId);
        var recipe = await sender.Send(query);
        return recipe != null ? Results.Ok(recipe) : Results.NotFound();
    }

    private async Task<IResult> GetRecipes(ISender sender)
    {
        var query = new GetRecipesQuery();
        var recipes = await sender.Send(query);
        return Results.Ok(recipes);
    }
}
