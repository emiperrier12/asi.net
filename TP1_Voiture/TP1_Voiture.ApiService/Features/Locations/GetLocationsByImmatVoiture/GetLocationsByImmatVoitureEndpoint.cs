using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Features.Locations.GetAll;

namespace TP1_Voiture.ApiService.Features.Locations.GetLocationsByImmatVoiture;

public static class GetLocationsByImmatVoitureEndpoint
{
    public static void MapGetLocationsByImmatVoitureEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/location/{Immat_Voiture}", async (
            string  Immat_Voiture,
            RentalDbContext db) =>
        {
            var voiture = db.Voitures.FirstOrDefault(v => v.Immatriculation == Immat_Voiture );

            if (voiture == null)
                return Results.NotFound();

            var locations = await db.Locations
                .Where(l => l.VoitureId == voiture.Id)
                .Select(l => new LocationDto(
                l.VoitureId,
                l.LoueurId,
                l.DateDebut,
                l.DateFin,
                l.IsAnnuler))
                .ToListAsync();
            
            return Results.Ok(locations);
        });
    }
}