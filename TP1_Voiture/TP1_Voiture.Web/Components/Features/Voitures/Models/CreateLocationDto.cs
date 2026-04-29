namespace TP1_Voiture.Web.Components.Features.Voitures;

public class CreateLocationDto
{
    public string Immatriculation { get; set; } = string.Empty;
    public int LoueurId { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
}