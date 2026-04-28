using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;

namespace TP1_Voiture.ApiService.Features.Voiture.GetCatalogue;

public static class ListVoituresEndpoint
{
    public static void MapListVoitures(this IEndpointRouteBuilder app)
    {
        app.MapGet("/voitures", async (RentalDbContext db, string? categorie) =>
            {
                //Define date
                var toDay = DateTime.UtcNow.Date;
    
                var query = db.Voitures
                    .Include(v => v.Locations)
                    .AsQueryable();
    
                var voitures = await query
                    .Select(v => new VoitureDto(
                        v.Immatriculation,
                        v.Marque,
                        v.Modele,
                        v.Categorie,
                        v.PrixLocationParJour,
                        !v.Locations.Any(l =>
                            l.DateDebut.Date <= toDay &&
                            l.DateFin.Date >= toDay)
                    ))
                    .ToListAsync();
    
                return Results.Ok(voitures);
            })
            .WithName("GetVoitures");
    }
}