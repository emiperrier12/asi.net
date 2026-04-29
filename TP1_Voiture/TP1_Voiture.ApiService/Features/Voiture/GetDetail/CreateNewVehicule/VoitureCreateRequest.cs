namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.CreateNewVehicule;

public record VoitureCreateRequest(
    string Immatriculation,
    string Marque,
    string Modele,
    string Categorie,
    decimal PrixLocationParJour
    );