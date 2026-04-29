namespace TP1_Voiture.Web.Components.Features.Voitures;

public class LocationDto
{
    public int VoitureId { get; set; }
    public int LoueurId { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public bool IsAnnuler { get; set; }
}