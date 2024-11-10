using HanaGuro2.Data;
using HanaGuro2.Models;
using HanaGuro2.Models.Dtos;
using HanaGuro2.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HanaGuro2.Endpoints;

public static class PlantBaseEndpoints
{
    public static RouteGroupBuilder MapPlantBaseEndpoints(this WebApplication app)
    {
        var gr = app.MapGroup("plants");
        
        //GET all
        gr.MapGet("/", 
            async (PlantDbContext db) =>
            {
                var plants = await db.Plants
                    .Include(p => p.Biome)
                    .Include(p => p.Type)
                    .Include(p => p.Owner)
                    .ToListAsync();
                
                var res = plants.Select(p => p.ToReadDto()).ToList();
                
                return res;
            });
        
        //GET id
        gr.MapGet("/{id}",
            async (int id, PlantDbContext db) =>
            {
                var res = await db.Plants
                        .Include(p => p.Biome)
                        .Include(p => p.Type)
                        .Include(p => p.Owner)
                        .FirstOrDefaultAsync(p => p.Id == id);
                    
                    return res is null ? Results.NotFound() : Results.Ok(res.ToReadDto());
            });
        
        //POST
        gr.MapPost("/",
            async (PlantCreateDto dto, PlantDbContext db) =>
            {
                var p = db.Plants.Add(dto.ToEntity(db));
                await db.SaveChangesAsync();
                return Results.Created($"/{p.Entity.Id}", new { Id = p.Entity.Id });
            }
        );
        
        //UPDATE id
        gr.MapPatch("/", async (PlantUpdateDto dto, PlantDbContext db) =>
            {
                var plant = await db.Plants.FindAsync(dto.Id);
                
                if (plant == null)
                {
                    return Results.NotFound();
                }
                
                plant.Level = dto.Level ?? plant.Level;
                plant.Price = dto.Price ?? plant.Price;

                try
                {
                    if (dto.TypeId.HasValue)
                    {
                        plant.TypeId = dto.TypeId.Value;
                        plant.Type = await db.PlantTypes.FirstOrDefaultAsync(x => x.Id == dto.TypeId);
                    }

                    if (dto.BiomeId.HasValue)
                    {
                        plant.BiomeId = dto.BiomeId.Value;
                        plant.Biome = await db.Biomes.FirstOrDefaultAsync(x => x.Id == dto.BiomeId);
                    }

                    if (dto.OwnerId.HasValue)
                    {
                        plant.OwnerId = dto.OwnerId.Value;
                        plant.Owner = await db.Users.FirstOrDefaultAsync(x => x.Id == dto.OwnerId);
                    }
                }
                catch (Exception e)
                {
                    return Results.BadRequest("wrong linked entity id");
                }
 

                await db.SaveChangesAsync();
                
                return Results.Ok();
            }
        );

        return gr;
    }
    
}