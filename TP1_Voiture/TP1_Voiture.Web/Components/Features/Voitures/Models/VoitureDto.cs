namespace TP1_Voiture.Web.Components.Features.Voitures;

public class VoitureDto
{
    public string Immatriculation { get; set; } = string.Empty;
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public string Categorie { get; set; } = string.Empty;
    public decimal PrixLocationParJour { get; set; }
}