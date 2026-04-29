using TP1_Voiture.ApiService.Data;

namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.ModifPrixParJour;

public static class UpdatePrixLocationParJourEndpoint
{
    public static void MapUpdatePrixLocationParJourEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPatch("/voiture_prix_location", async (
                UpdatePrixLocationWithImmatRequest req,
                RentalDbContext db
            ) =>
            {
                var voiture = db.Voitures.FirstOrDefault(v => v.Immatriculation == req.Immatriculation);

                if (voiture == null)
                    return Results.NotFound();

                voiture.PrixLocationParJour = req.NewPrixLocationParJour;
                await db.SaveChangesAsync();

                return Results.Ok(
                    $"Prix location modifié à : {voiture.PrixLocationParJour} pour tel voiture : {voiture.Immatriculation}");
            }
        );
    }
}