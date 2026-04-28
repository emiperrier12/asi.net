namespace TP1_Voiture.ApiService.Features.Locations.Reserver;

public record ReserverResponse(
    int LocationId,
    decimal PrixTotal,
    string Message
);
