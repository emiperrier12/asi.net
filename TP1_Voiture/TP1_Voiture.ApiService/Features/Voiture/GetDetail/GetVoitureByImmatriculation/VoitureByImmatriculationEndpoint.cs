using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Features.Voiture.GetCatalogue;

namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.GetVoitureByImmatriculation;

public static class VoitureByImmatriculationEndpoint
{
    public static void MapGetVoitureByImmatriculationEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/voiture_by_immatriculation/{immatriculation}", async (
            string immatriculation,
            RentalDbContext db) =>
        {
            var toDay = DateTime.UtcNow.Date;

            var voiture = await db.Voitures
                .Include(v => v.Locations)
                .FirstOrDefaultAsync(v => v.Immatriculation == immatriculation);

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