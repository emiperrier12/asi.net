using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Domain;

namespace TP1_Voiture.ApiService.Features.Locations.Reserver;

public static class ReserverEnpoint
{
    public static void MapReserver(this IEndpointRouteBuilder app)
    {
        app.MapPost("/locations", async (
                ReserverRequest req,
                RentalDbContext db,
                LocationService locService) =>
            {
                var voiture = await db.Voitures
                    .Include(v => v.Locations)
                    .FirstOrDefaultAsync(v => v.Immatriculation == req.Immatriculation);

                if (voiture == null)
                    return Results.NotFound();

                var loueur = await db.Loueurs.FindAsync(req.LoueurId);
                if (loueur == null)
                    return Results.NotFound();

                var estDisponible = !voiture.Locations.Any(l =>
                    l.DateDebut < req.DateFin &&
                    l.DateFin > req.DateDebut);

                if (!estDisponible)
                    return Results.Conflict();
            
                var prix = locService.CalculPrix(voiture.PrixLocationParJour, req.DateDebut, req.DateFin);

                var location = new Location
                {
                    VoitureId = voiture.Id,
                    LoueurId = req.LoueurId,
                    DateDebut = req.DateDebut,
                    DateFin = req.DateFin
                };
            
                db.Locations.Add(location);
                await db.SaveChangesAsync();
            
                return Results.Ok(new ReserverResponse(
                    location.Id,
                    prix,
                    "Reservation Confirmée"));
            })
            .WithName("ReserverEnpoint_Reserve");
    }
    
}