namespace TP1_Voiture.ApiService.Features.Locations.GetAll;

public record LocationDto(
    int VoitureId,
    int LouerId,
    DateTime DateDebut,
    DateTime DateFin,
    bool IsAnnuler
);