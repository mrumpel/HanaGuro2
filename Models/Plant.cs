namespace HanaGuro2.Models;

public class Plant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public decimal Price { get; set; }
    
    public PlantType Type { get; set; }
    public int TypeId { get; set; }
    
    public Biome Biome { get; set; }
    public int BiomeId { get; set; }
    
    public User Owner { get; set; }
    public int OwnerId { get; set; }
}