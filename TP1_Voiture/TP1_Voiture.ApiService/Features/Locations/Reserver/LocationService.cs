namespace TP1_Voiture.ApiService.Features.Locations.Reserver;

public class LocationService
{
    public decimal CalculPrix(decimal PrixLocationParJour, DateTime DateDebut, DateTime DateFin)
    {
        if (DateFin <= DateDebut)
            throw new ArgumentException("Mauvaise Date");

        var nbJours = (int)(DateFin.Date - DateDebut.Date).TotalDays;
        return nbJours*PrixLocationParJour;
    }
}