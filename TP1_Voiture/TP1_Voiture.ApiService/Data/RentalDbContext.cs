using Microsoft.EntityFrameworkCore;
using TP1_Voiture.ApiService.Domain;

namespace TP1_Voiture.ApiService.Data;

public class RentalDbContext(DbContextOptions<RentalDbContext> options) : DbContext(options)
{
    public DbSet<Loueur> Loueurs => Set<Loueur>();
    public DbSet<Voiture> Voitures => Set<Voiture>();
    public DbSet<Location> Locations => Set<Location>();
}