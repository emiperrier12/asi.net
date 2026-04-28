using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP1_Voiture.ApiService.Domain;

[Table("t_e_voiture_voi")]
public class Voiture
{
    [Key]
    [Column("voi_id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(9)]
    [Column("voi_immatriculation")]
    public required string Immatriculation { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("voi_marque")]
    public required string Marque { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("voi_modele")]
    public required string Modele { get; set; }

    [MaxLength(20)]
    [Column("voi_categorie")]
    public string? Categorie { get; set; }

    [Column("voi_prixlocationparjour", TypeName = "numeric(5,2)")]
    public decimal PrixLocationParJour { get; set; }

    // Navigation
    public ICollection<Location> Locations { get; set; } = [];
}