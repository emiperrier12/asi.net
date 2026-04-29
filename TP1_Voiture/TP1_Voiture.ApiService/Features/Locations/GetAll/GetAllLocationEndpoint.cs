using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;

namespace TP1_Voiture.ApiService.Features.Locations.GetAll;

public static class GetAllLocationEndpoint
{
    public static void MapGetAllLocationEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/locations", async (
            RentalDbContext db) =>
        {
            var locations = await db.Locations
                .Select(l => new LocationDto(
                    l.VoitureId,
                    l.LoueurId,
                    l.DateDebut,
                    l.DateFin,
                    l.IsAnnuler
                )).ToListAsync();
            
            return Results.Ok(locations);
        });
    }
}