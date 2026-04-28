using TP1_Voiture.ApiService.Domain;

namespace TP1_Voiture.ApiService.Data;

public class SeedData
{
    public static async Task Initialize(RentalDbContext context)
    {
        if (context.Voitures.Any() || context.Loueurs.Any())
            return;

        var loueurs = new List<Loueur>
        {
            new Loueur
            {
                Nom = "Dupont", Prenom = "Jean", Mobile = "0612345678", Rue = "12 rue de la Paix", Cp = "75001",
                Ville = "Paris", Pays = "France"
            },
            new Loueur
            {
                Nom = "Martin", Prenom = "Sophie", Mobile = "0698765432", Rue = "5 avenue des Fleurs", Cp = "69001",
                Ville = "Lyon", Pays = "France"
            },
            new Loueur
            {
                Nom = "Bernard", Prenom = "Pierre", Mobile = "0745678901", Rue = "8 boulevard Victor Hugo",
                Cp = "13001", Ville = "Marseille", Pays = "France"
            }
        };
        context.Loueurs.AddRange(loueurs);
        await context.SaveChangesAsync();

        var voitures = new List<Voiture>
        {
            new Voiture
            {
                Immatriculation = "AB-123-CD", Marque = "Renault", Modele = "Clio", Categorie = "Citadine",
                PrixLocationParJour = 45.00m
            },
            new Voiture
            {
                Immatriculation = "EF-456-GH", Marque = "Peugeot", Modele = "308", Categorie = "Berline",
                PrixLocationParJour = 60.00m
            },
            new Voiture
            {
                Immatriculation = "IJ-789-KL", Marque = "Citroen", Modele = "C3", Categorie = "Citadine",
                PrixLocationParJour = 40.00m
            },
            new Voiture
            {
                Immatriculation = "MN-012-OP", Marque = "BMW", Modele = "Serie 3", Categorie = "Premium",
                PrixLocationParJour = 120.00m
            }
        };

        context.Voitures.AddRange(voitures);
        await context.SaveChangesAsync();
        
        var locations = new List<Location>
        {
            new Location
            {
                VoitureId = voitures[0].Id,
                LoueurId = loueurs[0].Id,
                DateDebut = DateTime.UtcNow.AddDays(-5),
                DateFin = DateTime.UtcNow.AddDays(-2)
            },
            new Location
            {
                VoitureId = voitures[1].Id,
                LoueurId = loueurs[1].Id,
                DateDebut = DateTime.UtcNow.AddDays(-1),
                DateFin = DateTime.UtcNow.AddDays(3)
            }
        };
        
        context.Locations.AddRange(locations);
        await context.SaveChangesAsync();
    }
}