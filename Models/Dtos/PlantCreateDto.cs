using System.ComponentModel.DataAnnotations;

namespace HanaGuro2.Models.Dtos;

public class PlantCreateDto
{
    [Required]
    public string Name { get; set; }

    public int Level { get; set; } = 0;

    public int Price { get; set; } = 1;
    
    [Required]
    public int TypeId { get; set; }
    public int BiomeId { get; set; }
    [Required]
    public int OwnerId { get; set; }
}