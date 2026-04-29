namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.ModifPrixParJour;

public record UpdatePrixLocationWithImmatRequest(
    string Immatriculation,
    decimal NewPrixLocationParJour
);