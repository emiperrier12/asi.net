using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP1_Voiture.ApiService.Domain;

[Table("t_e_loueur_lou")]
public class Loueur
{
    [Key]
    [Column("lou_id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("lou_nom")]
    public required string Nom { get; set; }

    [MaxLength(100)]
    [Column("lou_prenom")]
    public string? Prenom { get; set; }

    [MaxLength(10)]
    [Column("lou_mobile")]
    public string? Mobile { get; set; }

    [MaxLength(100)]
    [Column("lou_rue")]
    public string? Rue { get; set; }

    [MaxLength(5)]
    [Column("lou_cp")]
    public string? Cp { get; set; }

    [MaxLength(50)]
    [Column("lou_ville")]
    public string? Ville { get; set; }

    [MaxLength(50)]
    [Column("lou_pays")]
    public string? Pays { get; set; } = "France";

    // Navigation
    public ICollection<Location> Locations { get; set; } = [];
}