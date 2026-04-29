namespace TP1_Voiture.ApiService.Features.Voiture.GetDetail.UpdateAVoiture;

public record UpdateVoitureRequest(
    string OldImmat,
    string NewImmat,
    string NewMarque,
    string NewModele,
    string NewCategorie,
    decimal NewPrixLocationParJour
    );