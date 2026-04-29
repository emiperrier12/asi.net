using TP1_Voiture.ApiService.Data;

namespace TP1_Voiture.ApiService.Features.Locations.UndoLocation;

public static class UndoLocationEndpoint
{
    public static void MapUndoLocationEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPatch("/location/{idLocation}/annuler", async (
            int idLocation,
            RentalDbContext db) =>
        {
            var location = db.Locations.FirstOrDefault(l => l.Id == idLocation);
            
            if (location == null)
                return Results.NotFound();
            
            location.IsAnnuler = true;
            
            await db.SaveChangesAsync();
            return Results.Ok($"Location : {location.Id} est annulée");
        });
    }
}