using TP1_Voiture.ApiService.Data;

namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.UpdateAVoiture;

public static class UpdateVoitureEndpoint
{
    public static void MapUpdateVoitureEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/voitures", async (
                UpdateVoitureRequest req,
                RentalDbContext db
            ) =>
            {
                var voiture = db.Voitures.FirstOrDefault(v => v.Immatriculation == req.OldImmat);
                
                if (voiture == null)
                    return Results.NotFound();

                voiture.Immatriculation = req.NewImmat;
                voiture.Modele = req.NewModele;
                voiture.Marque = req.NewMarque;
                voiture.Categorie = req.NewCategorie;
                voiture.PrixLocationParJour = req.NewPrixLocationParJour;

                await db.SaveChangesAsync();
                
                return Results.Ok($"Voiture : {voiture.Id}, modifié");
            } 
        );
    }
}