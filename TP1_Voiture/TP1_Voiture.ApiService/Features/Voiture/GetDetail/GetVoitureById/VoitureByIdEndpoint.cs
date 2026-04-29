using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Features.Voiture.GetCatalogue;

namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.GetVoitureById;

public static class VoitureByIdEndpoint
{
    public static void MapGetVoitureByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/voitures/{id}", async (
            int id,
            RentalDbContext db) =>
        {
            var toDay = DateTime.UtcNow.Date;

            var voiture = await db.Voitures
                .Include(v => v.Locations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (voiture == null)
                Results.NotFound();

            var response = new VoitureDto(
                voiture.Immatriculation,
                voiture.Marque,
                voiture.Modele,
                voiture.Categorie,
                voiture.PrixLocationParJour,
                !voiture.Locations.Any(l =>
                    l.DateDebut.Date <= toDay &&
                    l.DateFin.Date >= toDay)
            );

            return Results.Ok(response);
        });
    }
}