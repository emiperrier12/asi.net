using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP1_Voiture.ApiService.Domain;

[Table("t_j_location_loc")]
public class Location
{
    [Key]
    [Column("loc_id")]
    public int Id { get; set; }

    [Column("voi_id")]
    public int VoitureId { get; set; }

    [Column("lou_id")]
    public int LoueurId { get; set; }

    [Column("loc_datedebut")]
    public DateTime DateDebut { get; set; }

    [Column("loc_datefin")]
    public DateTime DateFin { get; set; }

    [Column("loc_annule")]
    public bool  IsAnnuler { get; set; }
    
    // Navigation
    [ForeignKey("VoitureId")]
    public Voiture Voiture { get; set; } = null!;

    [ForeignKey("LoueurId")]
    public Loueur Loueur { get; set; } = null!;
}