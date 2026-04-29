namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.CreateNewVehicule;

using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Domain;

public static class CreateVoitureEndpoint
{
    public static void MapCreateNewVehiculeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/create_vehicule", async (
                VoitureCreateRequest req,
                RentalDbContext db) =>
            {
                var voiture = new Voiture
                    {
                    Immatriculation = req.Immatriculation,
                    Marque = req.Marque,
                    Modele = req.Modele,
                    Categorie = req.Categorie,
                    PrixLocationParJour = req.PrixLocationParJour
                    };

                db.Voitures.Add(voiture);
                db.SaveChangesAsync();

                return Results.Ok("Nouvelles voiture sauvegardée"); 
            }
            );
    }
}