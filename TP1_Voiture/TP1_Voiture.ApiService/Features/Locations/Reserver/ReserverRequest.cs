namespace TP1_Voiture.ApiService.Features.Locations.Reserver;

public record ReserverRequest(
    string Immatriculation,
    int LoueurId,
    DateTime DateDebut,
    DateTime DateFin
);