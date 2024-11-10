using Microsoft.EntityFrameworkCore;
using HanaGuro2.Models;

namespace HanaGuro2.Data;

public class PlantDbContext : DbContext 
{
    public DbSet<Biome> Biomes { get; set; }
    public DbSet<PlantType> PlantTypes { get; set; }
    public DbSet<Plant> Plants { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public PlantDbContext(DbContextOptions<PlantDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Biome>().HasData(
            new Biome {Id = 6, Name = "Desert"},
            new Biome {Id = 1, Name = "Grassland"},
            new Biome {Id = 2, Name = "Forest"},
            new Biome {Id = 3, Name = "Mountain"},
            new Biome {Id = 4, Name = "Jungle"},
            new Biome {Id = 5, Name = "Garden"}
        );

        modelBuilder.Entity<PlantType>().HasData(
            new PlantType {Id = 1, Name = "Chlorophytum", ImageKey = "Chlorophytum"},
            new PlantType {Id = 2, Name = "Echeveria", ImageKey = "Echeveria"},
            new PlantType {Id = 3, Name = "Ficus", ImageKey = "Ficus"},
            new PlantType {Id = 4, Name = "Monstera", ImageKey = "Monstera"},
            new PlantType {Id = 5, Name = "Saintpaulia", ImageKey = "Saintpaula"}
        );
    }
}