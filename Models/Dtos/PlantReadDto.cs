namespace HanaGuro2.Models.Dtos;

public class PlantReadDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public decimal Price { get; set; }
    public int BiomeId { get; set; }
    public string? BiomeName { get; set; }
    public int TypeId { get; set; }
    public string? TypeName { get; set; }
    
    public int OwnerId { get; set; }
    public string? OwnerName { get; set; }
    
    public string? ImagePath { get; set; }
}