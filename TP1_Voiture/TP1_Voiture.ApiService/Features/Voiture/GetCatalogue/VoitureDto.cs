namespace TP1_Voiture.ApiService.Features.Voiture.GetCatalogue;

public record VoitureDto(
    string Immatriculation,
    string Marque,
    string Modele,
    string Categorie,
    decimal PrixLocationParJour,
    bool EstDisponible
);