using HanaGuro2.Data;
using HanaGuro2.Models.Dtos;
using Microsoft.VisualBasic;

namespace HanaGuro2.Models.Mappings;

public static class PlantMappings
{
    // Entity -> ReadDto
    public static PlantReadDto ToReadDto(this Plant plant)
    {
        //Image
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "plants", $"{plant.Type.ImageKey}_stage_{plant.Level}.jpeg");
        var url = File.Exists(imagePath) ? 
            $"/images/plants/{plant.Type.ImageKey}_stage_{plant.Level}.jpeg" 
            : "/images/plants/no_image.jpeg";
        
        //Result
        return new PlantReadDto()
        {
            Id = plant.Id,
            Name = plant.Name,
            Level = plant.Level,
            Price = plant.Price,
            BiomeId = plant.BiomeId,
            BiomeName = plant.Biome.Name,
            TypeId = plant.TypeId,
            TypeName = plant.Type.Name,
            OwnerId = plant.OwnerId,
            OwnerName = plant.Owner.Username,
            ImagePath = url,
        };
    }

    //CreateDto -> Entity
    public static Plant ToEntity(this PlantCreateDto dto, PlantDbContext db)
    {
        //TODO default Biome
        return new Plant()
        {
            Name = dto.Name,
            Level = dto.Level,
            Price = dto.Price,
            TypeId = dto.TypeId,
            Type = db.PlantTypes.FirstOrDefault(x => x.Id == dto.TypeId),
            BiomeId = dto.BiomeId,
            Biome = db.Biomes.FirstOrDefault(x => x.Id == dto.BiomeId),
            OwnerId = dto.OwnerId,
            Owner = db.Users.FirstOrDefault(x => x.Id == dto.OwnerId),
        };
    }
    
}